using System.Drawing.Configuration;
using TestTaskWinForm.Entity;

namespace TestTaskWinForm
{
    public partial class InputCityForm : Form
    {
        public InputCityForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку
        /// </summary>
        private async void FindWeatherButton_Click(object sender, EventArgs e)
        {
            if (Controls.ContainsKey("ErrorMessageLabel"))
            {
                Controls.RemoveByKey("ErrorMessageLabel");
            }

            string nameCity = NameCityTextBox.Text;
            if (nameCity is null || nameCity.Equals(string.Empty))
            {
                CreateErrorLabel("Введите город");
                return;
            }

            // Находим геопозицию с название города с API
            City city = await RequestApi
                .GetCityGeocodingApiOrNull(nameCity);

            if (city is null)
            {
                CreateErrorLabel("Такого городе не существует");
                return;
            }

            // Получаем все характеристики погоды
            WeatherAll weatherAll = await RequestApi
                .GetWeatherInCityOrNull(city);

            if (weatherAll is null)
            {
                CreateErrorLabel("Погоду не нашлось найти " +
                    "попробуйте снова");
                return;
            }

            // Получаем температуру
            double temp;
            weatherAll.Main.TryGetValue("temp", out temp);

            Weather weather = weatherAll.Weather
                .FirstOrDefault(x => x is not null);

            string description = string.Empty;
            if (weather != null)
            {
                // Получаем описание погоды
                description = weather.Description ?? string.Empty;
            }

            // Получаем скорость ветра
            double speedWind;
            weatherAll.Wind.TryGetValue("speed", out speedWind);

            string answer = $"Город:\t{city.Name} \n " +
                $"Температура:\t{Math.Round(temp - 273, 2)} в Цельсиях \n" +
                $"Описание:\t{description} \n" +
                $"Скорость ветра:\t{speedWind} м/c";

            // Вывод на экран с помощью MessageBox
            MessageBox.Show(answer, "погода", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Обнуляем пользовательский ввод
            NameCityTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Добавление ошибки на экран
        /// </summary>
        /// <param name="message"> Сообщение ошибки</param>
        private void CreateErrorLabel(string message)
        {
            Label label = new Label()
            {
                Name = "ErrorMessageLabel",
                Text = message,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                Location = new Point(FindWeatherButton.Location.X, 
                    FindWeatherButton.Location.Y + 80),
                ForeColor = Color.Red,
            };

            this.Controls.Add(label);
        }

        
    }
}
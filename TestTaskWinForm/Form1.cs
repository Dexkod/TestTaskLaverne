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
        /// ���������� ������� ������� �� ������
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
                CreateErrorLabel("������� �����");
                return;
            }

            // ������� ���������� � �������� ������ � API
            City city = await RequestApi
                .GetCityGeocodingApiOrNull(nameCity);

            if (city is null)
            {
                CreateErrorLabel("������ ������ �� ����������");
                return;
            }

            // �������� ��� �������������� ������
            WeatherAll weatherAll = await RequestApi
                .GetWeatherInCityOrNull(city);

            if (weatherAll is null)
            {
                CreateErrorLabel("������ �� ������� ����� " +
                    "���������� �����");
                return;
            }

            // �������� �����������
            double temp;
            weatherAll.Main.TryGetValue("temp", out temp);

            Weather weather = weatherAll.Weather
                .FirstOrDefault(x => x is not null);

            string description = string.Empty;
            if (weather != null)
            {
                // �������� �������� ������
                description = weather.Description ?? string.Empty;
            }

            // �������� �������� �����
            double speedWind;
            weatherAll.Wind.TryGetValue("speed", out speedWind);

            string answer = $"�����:\t{city.Name} \n " +
                $"�����������:\t{Math.Round(temp - 273, 2)} � �������� \n" +
                $"��������:\t{description} \n" +
                $"�������� �����:\t{speedWind} �/c";

            // ����� �� ����� � ������� MessageBox
            MessageBox.Show(answer, "������", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // �������� ���������������� ����
            NameCityTextBox.Text = string.Empty;
        }

        /// <summary>
        /// ���������� ������ �� �����
        /// </summary>
        /// <param name="message"> ��������� ������</param>
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
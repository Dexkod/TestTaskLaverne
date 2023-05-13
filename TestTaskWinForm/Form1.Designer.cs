namespace TestTaskWinForm
{
    partial class InputCityForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            InfoLabel = new Label();
            NameCityTextBox = new TextBox();
            FindWeatherButton = new Button();
            SuspendLayout();
            // 
            // InfoLabel
            // 
            InfoLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            InfoLabel.Location = new Point(246, 93);
            InfoLabel.Margin = new Padding(4, 0, 4, 0);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(336, 55);
            InfoLabel.TabIndex = 0;
            InfoLabel.Text = "Введите свой город";
            InfoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NameCityTextBox
            // 
            NameCityTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NameCityTextBox.Location = new Point(269, 164);
            NameCityTextBox.Margin = new Padding(4);
            NameCityTextBox.Name = "NameCityTextBox";
            NameCityTextBox.Size = new Size(286, 34);
            NameCityTextBox.TabIndex = 1;
            NameCityTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // FindWeatherButton
            // 
            FindWeatherButton.Location = new Point(343, 227);
            FindWeatherButton.Margin = new Padding(4);
            FindWeatherButton.Name = "FindWeatherButton";
            FindWeatherButton.Size = new Size(156, 55);
            FindWeatherButton.TabIndex = 2;
            FindWeatherButton.Text = "Узнать погоду";
            FindWeatherButton.UseVisualStyleBackColor = true;
            FindWeatherButton.Click += FindWeatherButton_Click;
            // 
            // InputCityForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 399);
            Controls.Add(FindWeatherButton);
            Controls.Add(NameCityTextBox);
            Controls.Add(InfoLabel);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "InputCityForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label InfoLabel;
        private TextBox NameCityTextBox;
        private Button FindWeatherButton;
    }
}
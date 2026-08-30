using System;
using System.ComponentModel.Design.Serialization;
namespace OsuruktanDertButton
{
    public partial class MainForm : Form
    {
        private Language _currentLanguage = Language.Turkish;

        private ComboBox _languageComboBox = null!;
        private Label _languageLabel = null!;
        private Label _promptLabel = null!;
        private TextBox _complantTextBox = null!;
        private Button _solveButton = null!;
        private Button _historyButton = null!;
        private Label _resultLabel = null!;

        public MainForm()
        {
            InitializeUi();
            ApplyLanguage();
        }

        private void InitializeUi()
        {
            Text = Localization.Get(Localization.WindowTitle, _currentLanguage);  //Percerenin başlık çubuğunda gözüke yazı
            Width = 480;
            Height = 380;
            StartPosition = FormStartPosition.CenterScreen; //Percere açılınca ekranın ortasında çıksın
            FormBorderStyle = FormBorderStyle.FixedDialog; //Percere sabit boyutlu.
            MaximizeBox = false; //Sabit boyut - Sağ üsteki pencere büyütücü inaktif

            _languageLabel = new Label
            {
                Left = 20,
                Top = 15,
                Width = 50,
                AutoSize = true, //Label'ın genişliği/yüksekliği, içindeki yazıya göre kendini otomatik ayarlasın
            };

            _languageComboBox = new ComboBox
            {
                Left = 80,
                Top = 12,
                Width = 150,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            _languageComboBox.Items.Add("Türkçe"); //0
            _languageComboBox.Items.Add("English"); //1
            _languageComboBox.Items.Add("Deutsch"); //2
            _languageComboBox.SelectedIndex = 0;
            _languageComboBox.SelectedIndexChanged += OnLanguageChanged; // kullanıcı listeden birşey seçtiğinde OnLanguageChanged metodu çalışacak





        }





        private void ApplyLanguage()
        {
            throw new NotImplementedException();
        }

    }
}

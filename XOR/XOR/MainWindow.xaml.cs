using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XOR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _text;
        private string _codedText;
        private string _shift;

        private bool _isLetter = true;
        private bool _isCorrect = false;
        private bool _isEnglishShift = false;
        private bool _isEnglishText = false;
        private bool _encrypt;
        public string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public string EnglishAlphabetWithNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public string RussianAlphabetWithNumbers = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
        public string CapitalEnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public string LowercaseEnglishAlphabet = "abcdefghijklmnopqrstuvwxyz";
        public string CapitalRussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ0123456789";
        public string LowercaseRussianAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public string Symbols = "~`!@#$%^&*()-+=[]{}|;:',.<>?№/";
        public int CaPowerOfEA = 36;
        public int LoPowerOfEA = 26;
        public int CaPowerOfRA = 43;
        public int LoPowerOfRA = 33;
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            var WE = new WindowExplanation();
            WE.ShowDialog();
        }

        private void XOR_Cipher(bool encrypt)
        {

        }
        private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            _encrypt = true;
            XOR_Cipher(_encrypt);
        }

        private void ButtonDecrypt_Click(object sender, RoutedEventArgs e)
        {
            _encrypt = false;
            XOR_Cipher(_encrypt);
        }

        private void TextBoxKey_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBoxKey.Text = "";
            TextBoxKey.Style = Application.Current.Resources["TextBoxStyle"] as Style;
        }

        private void TextBoxInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBoxInput.Text = "";
            TextBoxInput.Style = Application.Current.Resources["TextBoxStyle"] as Style;
        }

        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetData(DataFormats.UnicodeText, (object)TextBoxOutput.Text);
        }
    }
}

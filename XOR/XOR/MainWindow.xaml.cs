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
        private int _type;

        private bool _isLetter = true;
        private bool _isCorrect = false;
        private bool _isEnglishShift = false;
        private bool _isEnglishText = false;
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
            WE.ReturnData(out var type);
            _type = type;
        }

        private void XOR_Cipher()
        {
            if (_type == 1) //реализовать различные типы
            {
                if (TextBoxInput.Text == "" || TextBoxKey.Text == "")
                    MessageBox.Show("Пожалуйста, введите и текст для шифрования, и ключ шифрования", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    for (int i = 0; i < TextBoxKey.Text.Length; i++)
                    {
                        if (!(EnglishAlphabet.Contains(TextBoxKey.Text[i]) ||
                              RussianAlphabetWithNumbers.Contains(TextBoxKey.Text[i])))
                            _isLetter = false;
                        if (_isLetter == false)
                        {
                            MessageBox.Show("Пожалуйста, введите корректный ключ", "Ошибка!", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                            _isLetter = true;
                            TextBoxKey.Text = "";
                            break;
                        }

                        var index = 0;

                        while (TextBoxKey.Text[index] > 47 && TextBoxKey.Text[index] < 58)
                        {
                            if (index == TextBoxKey.Text.Length - 1)
                                break;
                            index++;
                        }

                        if ((TextBoxKey.Text[index] > 64 && TextBoxKey.Text[index] < 91) ||
                            (TextBoxKey.Text[index] > 96 && TextBoxKey.Text[index] < 123))
                            _isEnglishShift = true;
                        else
                            _isEnglishShift = false;



                        for (int j = 0; j < TextBoxKey.Text.Length; j++)
                        {
                            if ((!IsCorrect(TextBoxKey.Text[i], _isEnglishShift)) && ((EnglishAlphabet.Contains(TextBoxKey.Text[i]) ||
                                RussianAlphabet.Contains(TextBoxKey.Text[i]))))
                            {
                                MessageBox.Show("Ключ можно вводить только на одном языке!", "Ошибка!",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                                TextBoxKey.Text = "";
                                break;
                            }

                        }

                        if (i == TextBoxKey.Text.Length - 1)
                            _isCorrect = true;
                    }
                }
                if (_isCorrect != true) return;
                var index2 = 0;
                _text = TextBoxInput.Text;
                _shift = TextBoxKey.Text;
                _text = _text.Replace(" ", "");
                for (int i = 0; i < Symbols.Length; i++)
                {
                    _text = _text.Replace(Symbols[i].ToString(), "");
                }
                while (_text[index2] > 47 && _text[index2] < 58)
                {
                    if (index2 == _text.Length - 1)
                        break;
                    index2++;
                }

                if ((_text[index2] > 64 && _text[index2] < 91) || (_text[index2] > 96 && _text[index2] < 123))
                    _isEnglishText = true;
                _codedText = Code(_text, _shift, _isEnglishText, _isEnglishShift);
                TextBoxOutput.Style = Application.Current.Resources["TextBoxStyle"] as Style;
                _isCorrect = false;
                _isEnglishText = false;
                TextBoxOutput.Text = _codedText;
            }
            else
            {
                if (TextBoxInput.Text == "")
                    MessageBox.Show("Пожалуйста, введите текст для шифрования", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    _isCorrect = true;
                if (_isCorrect != true) return;
                var index2 = 0;
                _text = TextBoxInput.Text;
                _shift = RandomKey(_text.Length);
                _text = _text.Replace(" ", "");
                for (int i = 0; i < Symbols.Length; i++)
                {
                    _text = _text.Replace(Symbols[i].ToString(), "");
                }
                while (_text[index2] > 47 && _text[index2] < 58)
                {
                    if (index2 == _text.Length - 1)
                        break;
                    index2++;
                }

                if ((_text[index2] > 64 && _text[index2] < 91) || (_text[index2] > 96 && _text[index2] < 123))
                    _isEnglishText = true;
                _codedText = Code(_text, _shift, _isEnglishText, _isEnglishShift);
                TextBoxOutput.Style = Application.Current.Resources["TextBoxStyle"] as Style;
                _isCorrect = false;
                _isEnglishText = false;
                MessageBox.Show(String.Format("{0} - Ваш ключ к данному шифру", _shift), "Ключ шифра", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                TextBoxOutput.Text = _codedText;
            }
        }

        private bool IsCorrect(char letter, bool identifier)
        {
            bool isCorrect;
            if (identifier)
            {
                isCorrect = EnglishAlphabetWithNumbers.Contains(letter);
                return isCorrect;
            }
            else
            {
                isCorrect = RussianAlphabetWithNumbers.Contains(letter);
                return isCorrect;
            }
        }

        private string RandomKey(int length)
        {
            var key = "";
            var rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < length; i++)
            {
                key += rand.Next(0, 2).ToString();
            }
            return key;
        }

        private string Code(string text, string shift, bool isEnglish, bool isEnglishShift)
        {
            var fullShift = "";
            var codedText = "";
            var textLength = text.Length;
            var shiftLength = shift.Length;
            var difference = textLength / shiftLength;
            for (int i = 0; i < difference; i++)
            {
                fullShift += shift;
            }

            if (textLength % shiftLength != 0)
            {
                var remainder = textLength % shiftLength;
                for (int i = 0; i < remainder; i++)
                {
                    fullShift += shift[i];
                }
            }
            for (int i = 0; i < text.Length; i++)
            {
                if (!IsCorrect(text[i], isEnglish))
                {
                    MessageBox.Show("Текст можно вводить только на одном языке!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    TextBoxInput.Text = "";
                    return "";
                }
                codedText += Shift_letter(text[i], fullShift[i]);
            }
            return codedText;
        }

        private char Shift_letter(char letter, char letterShift) //доделать преобразования
        {
            var intermediate = "";

            var binarLetter = ConvertToBinary(letter.ToString());
            var binarShift = ConvertToBinary(letterShift.ToString());

            for (int i = 0; i < 8; i++)
            {
                intermediate += Convert.ToString(Convert.ToInt32(binarLetter[i]) ^ Convert.ToInt32(binarShift[i]));
            }


            var newLetter = 'A';
            return newLetter;
        }

        private string ConvertToBinary(string text)
        {
            return Encoding.ASCII.GetBytes(text).Aggregate("", (current, b) => current + (Convert.ToString(b, 2).PadLeft(8, '0')));
        }

        
        private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            XOR_Cipher();
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

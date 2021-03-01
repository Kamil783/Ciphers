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

namespace Vigenere
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

        private void Vigenere_Cipher(bool encrypt)
        {
            if (TextBoxInput.Text == "" || TextBoxKey.Text == "")
                MessageBox.Show("Пожалуйста, введите и текст для шифрования, и ключ шифрования", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                for (int i = 0; i < TextBoxKey.Text.Length; i++)
                {
                    if (!(EnglishAlphabet.Contains(TextBoxKey.Text[i]) || RussianAlphabet.Contains(TextBoxKey.Text[i])))
                        _isLetter = false;
                    if (_isLetter == false)
                    {
                        MessageBox.Show("Пожалуйста, введите корректный ключ", "Ошибка!", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        _isLetter = true;
                        TextBoxKey.Text = "";
                        break;
                    }

                    if ((TextBoxKey.Text[0] > 64 && TextBoxKey.Text[0] < 91) ||
                        (TextBoxKey.Text[0] > 96 && TextBoxKey.Text[0] < 123))
                        _isEnglishShift = true;
                    else
                        _isEnglishShift = false;



                    for (int j = 0; j < TextBoxKey.Text.Length; j++)
                    {
                        if (!IsCorrect(TextBoxKey.Text[i], _isEnglishShift))
                        {
                            MessageBox.Show("Ключ можно вводить только на одном языке!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            TextBoxKey.Text = "";
                            break;
                        }

                    }
                    if (i == TextBoxKey.Text.Length - 1)
                        _isCorrect = true;
                }
            }

            if (_isCorrect != true) return;
            var index = 0;
            _text = TextBoxInput.Text;
            _shift = TextBoxKey.Text;
            _text = _text.Replace(" ", "");
            for (int i = 0; i < Symbols.Length; i++)
            {
                _text = _text.Replace(Symbols[i].ToString(), "");
            }
            while (_text[index] > 47 && _text[index] < 58)
            {
                if (index == _text.Length - 1)
                    break;
                index++;
            }

            if ((_text[index] > 64 && _text[index] < 91) || (_text[index] > 96 && _text[index] < 123))
                _isEnglishText = true;
            _codedText = Code(_text, _shift, _isEnglishText, _isEnglishShift, encrypt);
            TextBoxOutput.Style = Application.Current.Resources["TextBoxStyle"] as Style;
            _isCorrect = false;
            _isEnglishText = false;
            TextBoxOutput.Text = _codedText;
        }
        private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            _encrypt = true;
            Vigenere_Cipher(_encrypt);
        }

        private void ButtonDecrypt_Click(object sender, RoutedEventArgs e)
        {
            _encrypt = false;
            Vigenere_Cipher(_encrypt);
        }

        private string Code(string text, string shift, bool isEnglish, bool isEnglishShift, bool isEncrypt)
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
                codedText += Shift_letter(text[i], fullShift[i], isEnglish, isEnglishShift, isEncrypt);
            }
            return codedText;
        }

        private char Shift_letter(char letter, char letterShift, bool isEnglish, bool isEnglishShift, bool isEncrypt)
        {
            char newLetter;
            var letterValue = 0;
            var shift = 0;

            if (isEnglishShift)
            {
                if (CapitalEnglishAlphabet.Contains(letterShift))
                {
                    while (letterShift != CapitalEnglishAlphabet[shift])
                    {
                        shift++;
                    }
                }
                else
                {
                    while (letterShift != LowercaseEnglishAlphabet[shift])
                    {
                        shift++;
                    }
                }

            }
            else
            {
                if (CapitalRussianAlphabet.Contains(letterShift))
                {
                    while (letterShift != CapitalRussianAlphabet[shift])
                    {
                        shift++;
                    }
                }
                else
                {
                    while (letterShift != LowercaseRussianAlphabet[shift])
                    {
                        shift++;
                    }
                }
            }

            shift += 1;
            if (!isEncrypt)
                shift = -1 * shift;
            if (isEnglish)
            {
                if (CapitalEnglishAlphabet.Contains(letter))
                {
                    while (letter != CapitalEnglishAlphabet[letterValue])
                    {
                        letterValue++;
                    }

                    letterValue = (letterValue + shift) % CaPowerOfEA;
                    if (letterValue < 0)
                        letterValue += CaPowerOfEA;
                    newLetter = CapitalEnglishAlphabet[letterValue];
                }
                else
                {
                    while (letter != LowercaseEnglishAlphabet[letterValue])
                    {
                        letterValue++;
                    }

                    letterValue = (letterValue + shift) % LoPowerOfEA;
                    if (letterValue < 0)
                        letterValue += LoPowerOfEA;
                    newLetter = LowercaseEnglishAlphabet[letterValue];
                }

            }
            else
            {
                if (CapitalRussianAlphabet.Contains(letter))
                {
                    while (letter != CapitalRussianAlphabet[letterValue])
                    {
                        letterValue++;
                    }

                    letterValue = (letterValue + shift) % CaPowerOfRA;
                    if (letterValue < 0)
                        letterValue += CaPowerOfRA;
                    newLetter = CapitalRussianAlphabet[letterValue];
                }
                else
                {
                    while (letter != LowercaseRussianAlphabet[letterValue])
                    {
                        letterValue++;
                    }

                    letterValue = (letterValue + shift) % LoPowerOfRA;
                    if (letterValue < 0)
                        letterValue += LoPowerOfRA;
                    newLetter = LowercaseRussianAlphabet[letterValue];
                }
            }
            return newLetter;
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

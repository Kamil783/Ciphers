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
        private bool _type;

        private bool _isLetter = true;
        private bool _isFirst = true;
        private bool _isCorrect = false;
        private bool _isEnglishShift = false;
        public string EnglishAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public string RussianAlphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        public string EnglishAlphabetWithNumbers = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public string RussianAlphabetWithNumbers = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789";
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
            if (_type)
                ButtonNewShift.Visibility = Visibility.Hidden;
            if (!_type)
            {
                TextBoxKey.Visibility = Visibility.Hidden;
                TextBoxCheck.Margin = new Thickness(0, 600, 0, 0);
            }
        }

        private void XOR_Cipher(bool enc)
        {
            if (_type)
            {
                if (TextBoxInput.Text == "" || TextBoxKey.Text == "")
                    MessageBox.Show("Пожалуйста, введите и текст для шифрования, и ключ шифрования", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    for (int i = 0; i < TextBoxKey.Text.Length; i++)
                    {
                        if (!(EnglishAlphabet.Contains(TextBoxKey.Text[i]) ||
                              RussianAlphabet.Contains(TextBoxKey.Text[i])))
                            _isLetter = false;
                        if((EnglishAlphabet.Contains(TextBoxInput.Text[0]) &&
                            RussianAlphabet.Contains(TextBoxKey.Text[i]) || 
                            (RussianAlphabet.Contains(TextBoxInput.Text[0]) &&
                             EnglishAlphabet.Contains(TextBoxKey.Text[i]))))
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
                            if ((!IsCorrect(TextBoxKey.Text[i], _isEnglishShift)))
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
                _shift = TextBoxKey.Text;
                _text = enc == true ? TextBoxInput.Text : TextBoxOutput.Text;
                while (_text[index2] > 47 && _text[index2] < 58)
                {
                    if (index2 == _text.Length - 1)
                        break;
                    index2++;
                }

                if ((_text[index2] > 64 && _text[index2] < 91) || (_text[index2] > 96 && _text[index2] < 123))
                    _codedText = Code(_text, _shift);
                TextBoxOutput.Style = Application.Current.Resources["TextBoxStyle"] as Style;
                if (enc == false)
                    TextBoxCheck.Style = Application.Current.Resources["TextBoxStyle"] as Style;
                _isCorrect = false;
                if (enc == true)
                {
                    TextBoxOutput.Text = _codedText;
                }
                else
                {
                    TextBoxCheck.Text = _codedText;
                }
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
                _text = enc == true ? TextBoxInput.Text : TextBoxOutput.Text;
                if (_isFirst)
                    _shift = RandomShift(_text.Length);
                while (_text[index2] > 47 && _text[index2] < 58)
                {
                    if (index2 == _text.Length - 1)
                        break;
                    index2++;
                }

                _codedText = Code(_text, _shift);
                TextBoxOutput.Style = Application.Current.Resources["TextBoxStyle"] as Style;
                if (enc == false)
                    TextBoxCheck.Style = Application.Current.Resources["TextBoxStyle"] as Style;
                if (_isFirst)
                    MessageBox.Show(String.Format("{0} - Ваш ключ к данному шифру", _shift), "Ключ шифра", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                _isCorrect = false;
                _isFirst = false;
                if (enc == true)
                {
                    TextBoxOutput.Text = _codedText;
                }
                else
                {
                    TextBoxCheck.Text = _codedText;
                }
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

        private string RandomShift(int length)
        {
            var key = "";
            var help = "";
            //var rand = new Random(Guid.NewGuid().GetHashCode());
            //for (int i = 0; i < length; i++)
            //{
            //    key += rand.Next(0, 2).ToString();
            //}


            var Count0 = 0;
            var Count1 = 0;
            for (int i = 0; i < length; i++)
            {
                help = "";
                Count0 = 0;
                Count1 = 0;
                while (help.Length < 8)
                {
                    var rnd = new Random(Guid.NewGuid().GetHashCode());
                    var _key = rnd.Next(0, 2);
                    switch (_key)
                    {
                        case 0:
                            Count0++;
                            break;
                        case 1:
                            Count1++;
                            break;
                    }

                    if (Count0 < 5 && _key == 0)
                        help += _key.ToString();
                    if (Count1 < 5 && _key == 1)
                        help += _key.ToString();
                }

                key += help;
            }

            return key;
        }

        private string Code(string text, string shift)
        {
            var index = 0;
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

            if (!_type)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    codedText += Shift_letter(text[i], fullShift[i], shift.Substring(index, 8));
                    index += 8;
                }
            }
            else
            {
                for (int i = 0; i < text.Length; i++)
                {
                    codedText += Shift_letter(text[i], fullShift[i], "");
                }
            }

            return codedText;
        }

        private string Shift_letter(char letter, char letterShift, string shift)
        {
            //Encoding _default = Encoding.Default;
            //Encoding unicode = Encoding.Unicode;
            //var intermediate = "";
            //var binarLetter = ConvertToBinary(letter.ToString());

            //var binarShift = ConvertToBinary(letterShift.ToString());


            //for (int i = 0; i < 8; i++)
            //{
            //    intermediate += Convert.ToString(Convert.ToInt32(binarLetter[i]) ^ Convert.ToInt32(binarShift[i]));
            //}

            //int _intermediate = Convert.ToInt32(intermediate, 2);

            //var newLetter = Convert.ToChar(_intermediate);
            //byte[] unicodeBytes = unicode.GetBytes(newLetter.ToString());

            //byte[] defaultBytes = Encoding.Convert(unicode, _default, unicodeBytes);
            //char[] asciiChars = new char[_default.GetCharCount(defaultBytes, 0, defaultBytes.Length)];
            //_default.GetChars(defaultBytes, 0, defaultBytes.Length, asciiChars, 0);
            //string asciiString = new string(asciiChars);

            //return newLetter;
            var binaryShift = _type ? ConvertToBinary(letterShift.ToString()) : shift;
            
            var binaryLetter = ConvertToBinary(letter.ToString());
            
            var bytes = new byte[1];

            var _binaryLetter = Convert.ToByte(binaryLetter, 2);
            var _binaryKey = Convert.ToByte(binaryShift, 2);
            var _binaryResult = (byte)(_binaryLetter ^ _binaryKey);

            bytes[0] = _binaryResult;

            var newLetter = Encoding.Default.GetString(bytes);

            return newLetter;
        }

        private string ConvertToBinary(string text)
        {
            return Encoding.Default.GetBytes(text).Aggregate("", (current, b) => current + (Convert.ToString(b, 2).PadLeft(8, '0')));
        }


        private void ButtonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            XOR_Cipher(true);
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

        private void ButtonEnc_Click(object sender, RoutedEventArgs e)
        {
            XOR_Cipher(false);
        }

        private void ButtonNewShift_Click(object sender, RoutedEventArgs e)
        {
            _isFirst = true;
        }
    }
}

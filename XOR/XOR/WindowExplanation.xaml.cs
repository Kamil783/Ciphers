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
using System.Windows.Shapes;

namespace XOR
{
    /// <summary>
    /// Логика взаимодействия для WindowExplanation.xaml
    /// </summary>
    public partial class WindowExplanation : Window
    {
        public WindowExplanation()
        {
            InitializeComponent();
        }

        public void ReturnData(out int type)
        {
            type = 0;

            if (ManualBinShift.IsChecked == true)
                type = 1;

            if (ManualShift.IsChecked == true)
                type = 2;

        }

        private void ButtonOkExplonation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

﻿using System;
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

        public void ReturnData(out bool type)
        {
            type = AutoShift.IsChecked != true;
        }

        private void ButtonOkExplonation_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

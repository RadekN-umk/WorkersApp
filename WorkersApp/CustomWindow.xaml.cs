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

namespace WorkersApp
{
    /// <summary>
    /// Logika interakcji dla klasy CustomWindow.xaml
    /// </summary>
    public partial class CustomWindow : Window
    {
        public CustomWindow()
        {
            InitializeComponent();
        }
        public string CustomWindowResultFirstName
        {
            get { return ImieTextBox.Text; }
            set { ImieTextBox.Text = value; }
        }
        public string CustomWindowResultLastName
        {
            get { return NazwiskoTextBox.Text; }
            set { NazwiskoTextBox.Text = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

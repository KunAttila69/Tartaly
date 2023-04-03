using System;
using System.Collections.Generic;
using System.IO;
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
using Osztályok;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Tartaly> tartalyok = new List<Tartaly>();

        public MainWindow()
        {
            InitializeComponent();
            rdoTeglatest.IsChecked = true;
        }

        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            rdoTeglatest.IsChecked = true;
            txtAel.Text = "";
            txtBel.Text = "";
            txtCel.Text = "";

            txtAel.IsEnabled = true;
            txtBel.IsEnabled = true;
            txtCel.IsEnabled = true;
        }

        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            rdoKocka.IsChecked = true;
            txtAel.Text = "10";
            txtBel.Text = "10";
            txtCel.Text = "10";

            
            txtAel.IsEnabled = false;
            txtBel.IsEnabled = false;
            txtCel.IsEnabled = false;
        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            Tartaly tartaly = new Tartaly(txtNev.Text, Convert.ToInt32(txtAel.Text), Convert.ToInt32(txtBel.Text), Convert.ToInt32(txtCel.Text));
            tartalyok.Add(tartaly);
            lbTartalyok.Items.Add(tartaly.Info());
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("tartalyok.txt"))
            {
                foreach (Tartaly tartaly in tartalyok)
                {
                    sw.WriteLine(tartaly.Info());
                }
            }
        }


        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
            tartalyok[lbTartalyok.SelectedIndex].aEl *= 2;
            lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
        }

        private void btnLeenged_Click(object sender, RoutedEventArgs e)
        {
            tartalyok[lbTartalyok.SelectedIndex].AktLiter = 0;
            lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
        }

        private void btntolt_Click(object sender, RoutedEventArgs e)
        {
            tartalyok[lbTartalyok.SelectedIndex].AktLiter += Convert.ToInt32(txtMennyitTolt.Text);
            lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
        }
    }
}

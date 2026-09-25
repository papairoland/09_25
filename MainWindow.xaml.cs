using Microsoft.Win32;
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

namespace _09_25_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SzinBeallito()
        {
            byte red, green, blue;
            red = Convert.ToByte(sliRed.Value);
            blue = Convert.ToByte(sliBlue.Value);
            green = Convert.ToByte(sliGreen.Value);
            rctTeglalap.Fill = new SolidColorBrush(Color.FromRgb(red, green, blue));
        }

        private void sliRed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinBeallito();
            lblRed.Content = sliRed.Value;
        }

        private void sliGreen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinBeallito();
            lblGreen.Content = sliGreen.Value;
        }

        private void sliBlue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SzinBeallito();
            lblBlue.Content = sliBlue.Value;
        }

        private void btnUres_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztos törölni akarod?", "Figyelem!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            lbLista.Items.Clear();
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            byte red, green, blue;
            red = Convert.ToByte(sliRed.Value);
            blue = Convert.ToByte(sliBlue.Value);
            green = Convert.ToByte(sliGreen.Value);
            string sor = $"RGB({red},{blue},{green})";
            lbLista.Items.Add(sor);
        }

        private void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream)
                {
                    lbLista.Items.Add(sr.ReadLine());
                }
                sr.Close();
            }
        }

        private void btnElmentes_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                this.Title = sfd.FileName;
                StreamWriter sw = new StreamWriter(sfd.FileName);
                for (int i = 0; i < lbLista.Items.Count; i++)
                {
                    sw.WriteLine(lbLista.Items[i]);
                }
                sw.Close();
            }
        }

        private void lbLista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string rgbSzinkod = lbLista.Items[lbLista.SelectedIndex].ToString();
            string szinkod = rgbSzinkod.Substring(4, rgbSzinkod.Length - 5);
            string[] szamok = szinkod.Split(',');
            sliRed.Value = Convert.ToByte(szamok[0]);
            sliGreen.Value = Convert.ToByte(szamok[1]);
            sliBlue.Value = Convert.ToByte(szamok[2]);
        }
    }
}
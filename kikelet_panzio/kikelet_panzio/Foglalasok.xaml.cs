using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace kikelet_panzio
{
    public partial class Foglalasok : Page
    {
        public Foglalasok()
        {
            InitializeComponent();
            elokeszit();
        }

        private void modositas_Click(object sender, RoutedEventArgs e)
        {

        }
        private void elokeszit()
        {
            for (int i = 0; i < MainWindow.foglalasok.Count; i++)
            {
                foglalasSorszam.Items.Add(i + 1);
            }
            for (int i = 0; i < MainWindow.szobak.Count; i++)
            {
                szobaId.Items.Add(MainWindow.szobak[i].Szobaszam);
            }
            for (int i = 0; i < MainWindow.ugyfelek.Count; i++)
            {
                ugyfelId.Items.Add(MainWindow.ugyfelek[i].Azon);


            }
            allapot.Items.Add("előjegyzett");
            allapot.Items.Add("teljesült");
            allapot.Items.Add("lemondott");
            muvelet.Items.Add("Módosítás");
            muvelet.Items.Add("Hozzáadás");
            muvelet.SelectedIndex = 1;
        }

        private void foglalasSorszam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = foglalasSorszam.SelectedIndex;
            szobaId.SelectedIndex = MainWindow.foglalasok[index].Szobaszam - 1;
            ugyfelId.SelectedItem = MainWindow.foglalasok[index].UgyfelAzon;


            fo.Text = MainWindow.foglalasok[index].Fo.ToString();

            bool kedvezmenyes = MainWindow.ugyfelek.Where(x => x.Azon == MainWindow.foglalasok[index].UgyfelAzon).First().Vip;

            //ar.Text = kedvezmenyes ? MainWindow.szobak[Convert.ToInt32(szobaId.SelectedItem)].Kedvezmenyes(Convert.ToInt32(fo.Text)).ToString() : MainWindow.szobak[Convert.ToInt32(szobaId.SelectedItem)].Ar(Convert.ToInt32(fo.Text)).ToString();

            allapot.SelectedItem = MainWindow.foglalasok[foglalasSorszam.SelectedIndex].Allapot;
        }

        private void fo_TextChanged(object sender, TextChangedEventArgs e)
        {
            szamitAr();
        }
        private void szamitAr()
        {
            int fok = 0;
            if (fo.Text == "" || !int.TryParse(fo.Text, out fok) || szobaId.SelectedIndex == -1 || ugyfelId.SelectedIndex == -1)
            {
                if (fo.Text != "")
                {
                    MessageBox.Show("Nincs minden szükséges adat megadva!");
                }
                return;
            }
            int ferohely = MainWindow.szobak[Convert.ToInt32(szobaId.SelectedItem) - 1].Ferohely;
            if (fok < 1 || ferohely < fok)
            {
                MessageBox.Show("Túl sok vagy túl kevés a fők száma!");
                return;
            }
            bool kedvezmenyes = MainWindow.ugyfelek.Where(x => x.Azon == ugyfelId.SelectedItem.ToString()).First().Vip;
            MessageBox.Show(string.Join("\n", MainWindow.ugyfelek.Select(x => x.Vip)));
            ar.Text = kedvezmenyes ? MainWindow.szobak[Convert.ToInt32(szobaId.SelectedItem) - 1].Kedvezmenyes(Convert.ToInt32(fo.Text)).ToString() : MainWindow.szobak[Convert.ToInt32(szobaId.SelectedItem) - 1].Ar(Convert.ToInt32(fo.Text)).ToString();
        }

        private void ugyfelId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            szamitAr();
        }

        private void szobaId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            szamitAr();
        }

        private void vegrehajtas_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
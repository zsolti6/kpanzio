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
using System.IO;

namespace kikelet_panzio
{
    public partial class MainWindow : Window
    {
        internal static List<Szoba> szobak = new List<Szoba>();
        internal static List<Ugyfel> ugyfelek = new List<Ugyfel>();
        internal static List<Foglalas> foglalasok = new List<Foglalas>();
        bool sotetTema;
        public MainWindow()
        {
            InitializeComponent();
            //ablak.NavigationService.Navigate(new Kezdooldal());
            temaBeallit();
            Beolvas();
        }
        public static DateOnly Datumba(string datum)
        {
            int[] datumS = datum.Split('-').Select(x => Convert.ToInt32(x)).ToArray();
            return new DateOnly(datumS[0], datumS[1], datumS[2]);
        }
        public static string Datumbol(DateOnly datum)
        {
            return datum.ToString();
        }
        public static void BeolvasSzobak()
        {
            string[] sorok = File.ReadAllLines("szobak.txt");
            foreach (var sor in sorok)
            {
                szobak.Add(new Szoba(sor));
            }
        }
        public static void BeolvasUgyfelek()
        {
            string[] sorok = File.ReadAllLines("ugyfelek.txt");
            foreach (var sor in sorok)
            {
                ugyfelek.Add(new Ugyfel(sor));
            }
        }
        public static void BeolvasFoglalasok()
        {
            string[] sorok = File.ReadAllLines("foglalasok.txt");
            foreach (var sor in sorok)
            {
                foglalasok.Add(new Foglalas(sor));
            }
        }
        public void Beolvas()
        {
            BeolvasSzobak();
            BeolvasUgyfelek();
            BeolvasFoglalasok();
        }
        private void kezdooldal_Click(object sender, RoutedEventArgs e)
        {
            ablak.NavigationService.Navigate(new Kezdooldal());
        }
        private void adminSzoba_Click(object sender, RoutedEventArgs e)
        {

        }
        private void adminUgyfel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void adminFoglalas_Click(object sender, RoutedEventArgs e)
        {

        }
        private void adminStatisztika_Click(object sender, RoutedEventArgs e)
        {

        }
        private void tema_Click(object sender, RoutedEventArgs e)
        {
            sotetTema = !sotetTema;
            File.WriteAllText("tema.txt", sotetTema ? "1" : "0");
            temaBeallit();
        }
        private void kilep_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void temaBeallit()
        {
            sotetTema = File.ReadAllLines("tema.txt")[0] == "1";
            ablak.Background = sotetTema ? Brushes.Black : Brushes.White;
            //ablak.NavigationService.CurrentSource. = !sotetTema ? Brushes.Black : Brushes.White;
        }
    }
}
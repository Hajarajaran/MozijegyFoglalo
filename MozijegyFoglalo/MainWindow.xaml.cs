using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MozijegyFoglalo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string nev;
        int kor;
        string film;
        string jegytipus;
        int jegyekSzama;
        int jegytipusAr;
        int ar;
        List<string> extrak = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            extrak.Clear();
            ar = 0;
            nev = nevTxt.Text;
            if (nev == "" || nev.Length < 3)
            {
                MessageBox.Show("A név nem lehet üres és legalább 3 karakter hosszúnak kell lennie!", "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            } 
            
            
            try
            {
                kor = Convert.ToInt32(korTxt.Text);
                if (kor <= 0 || kor > 120)
                {
                    MessageBox.Show("Az életkor minimum 1 és maximum 120 év lehet!", "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            } catch (FormatException)
            {
                MessageBox.Show("Az életkor nem lehet üres és csak számot tartalmazhat!", "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            if (filmek.SelectedItem == null)
            {
                MessageBox.Show("Válassz ki egy filmet!", "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            } film = ((ComboBoxItem)filmek.SelectedItem).Content.ToString();

            if (normalJegyOpcio.IsChecked == true)
            {
                jegytipus = "Normál";
                jegytipusAr = 2500;
            }
            else if (diakJegyOpcio.IsChecked == true)
            {
                jegytipus = "Diák";
                jegytipusAr = 1900;
            }
            else if (vipJegyOpcio.IsChecked == true)
            {
                jegytipus = "VIP";
                jegytipusAr = 4000;
            }
            else
            {
                MessageBox.Show("Válassz ki egy jegytípust!", "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                jegyekSzama = Convert.ToInt32(jegyekSzamaTxt.Text);
                ar += jegytipusAr * jegyekSzama;
                if (jegyekSzama <= 0 || jegyekSzama > 10)
                {
                    MessageBox.Show("A jegyek száma minimum 1 és maximum 10 darab lehet!", "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("A jegyek számához számot adj meg!", "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (popcornOpcio.IsChecked == true)
            {
                extrak.Add("Popcorn");
                ar += 1200;
            }

            if (uditoOpcio.IsChecked == true)
            {
                extrak.Add("Üdítő");
                ar += 800;
            }

            if (szemuvegOpcio.IsChecked == true)
            {
                extrak.Add("3D szemüveg");
                ar += 500;
            }

            if (feltetelekOpcio.IsChecked == false)
            {
                MessageBox.Show("Fogadd el a vásárlási feltételeket!", "Hibás adat", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string foglalas = $"Sikeres foglalás!\n\nNév: {nev}\nÉletkor: {kor}\nFilm: {film}\nJegytípus: {jegytipus}\nJegyek száma: {jegyekSzama}\nExtrák: {string.Join(", ", extrak)}\n\nFizetendő: {ar} Ft";

            MessageBox.Show(foglalas, "Foglalás", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
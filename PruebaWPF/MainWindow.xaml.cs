using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PruebaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TranslateTransform trans = new TranslateTransform();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Ficha_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txt.Text = "Se hizo click en la ficha"; 
        }

        private void Casilla_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            txt.Text = "Se hizo click en la casilla";

            Point position = Casilla.TranslatePoint(new Point(10, 10), Ficha);

            txt.Text = $"{position.X}{position.Y}";


            trans.Y = position.Y;
            trans.X = position.X;
            Ficha.RenderTransform = trans;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
        }

        //private void Ficha_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    txt.Text = "Se hizo click en la ficha";
        //}
    }
}
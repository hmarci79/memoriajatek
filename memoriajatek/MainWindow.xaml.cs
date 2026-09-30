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

namespace memoriajatek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int kivalasztottMeret;
        private int kivalasztottTema;
        public MainWindow()
        {
            InitializeComponent();
            lbox_meret.ItemsSource = new List<Int32>() { 2, 4, 6 };
            lbox_tema.ItemsSource = new List<String>() { "123", "🐶🐱🐷", "🍕🍔🌭" };
        }

        private void btn_kezdes_Click(object sender, RoutedEventArgs e)
        {
            Leosztas(kivalasztottMeret, kivalasztottTema);
        }

        private void lbox_meret_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kivalasztottMeret = Convert.ToInt32(lbox_meret.SelectedItem);
        }

        private void lbox_tema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kivalasztottTema = lbox_tema.SelectedIndex;
        }

        private void Leosztas(int meret, int tema)
        {
            for (int i = 0; i < meret; i++)
            {
                grid_kartyak.RowDefinitions.Add(new RowDefinition());
                grid_kartyak.ColumnDefinitions.Add(new ColumnDefinition());
                for (int j = 0; j < meret; j++)
                {
                    Button btn = new Button
                    {
                        Name = $"a{i}{j}",
                        FontSize = 360/meret/4,
                        Margin = new Thickness(2),
                        Height = 360 / meret,
                        Width = 360 / meret
                    };
                    btn.Click += Buttton_Click;
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    grid_kartyak.Children.Add(btn);
                }
            }
        }

        private void Buttton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int x = Convert.ToInt32(Convert.ToString(btn.Name[1]));
            int y = Convert.ToInt32(Convert.ToString(btn.Name[2]));
        }
    }
}
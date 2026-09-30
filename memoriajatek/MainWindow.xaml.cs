using System.DirectoryServices;
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
        private List<string> tema1 = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18" };
        private List<string> tema2 = new List<string>() { "🐶", "🐱", "🐷", "🐵", "🐺", "🦁", "🐯", "🦊", "🦝", "🐮", "🐻", "🐻‍❄️", "🐨", "🐼", "🐸", "🐭", "🐹", "🐰" };
        private List<string> tema3 = new List<string>() { "🍕", "🍔", "🌭", "🥐", "🍞", "🥨", "🧇", "🥞", "🥗", "🥙", "🥪", "🍖", "🍱", "🍜", "🍦", "🍩", "🍪", "🎂" };
        private List<int> sorrend = new List<int>();
        private bool masodik = false;
        private Button elso;
        private int pontszam = 0;
        private int probalkozasok = 0;
        public MainWindow()
        {
            InitializeComponent();
            lbox_meret.ItemsSource = new List<Int32>() { 2, 4, 6 };
            lbox_tema.ItemsSource = new List<String>() { "123", "🐶🐱🐷", "🍕🍔🌭" };
        }

        private void btn_kezdes_Click(object sender, RoutedEventArgs e)
        {
            if ((kivalasztottMeret != 0) && (kivalasztottTema != 0))
            {
                Leosztas(kivalasztottMeret, kivalasztottTema);
            }
        }

        private void lbox_meret_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kivalasztottMeret = Convert.ToInt32(lbox_meret.SelectedItem);
        }

        private void lbox_tema_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kivalasztottTema = lbox_tema.SelectedIndex+1;
        }

        private void Leosztas(int meret, int tema)
        {
            int index = 0;
            for (int i = 0; i < meret; i++)
            {
                grid_kartyak.RowDefinitions.Add(new RowDefinition());
                grid_kartyak.ColumnDefinitions.Add(new ColumnDefinition());
                for (int j = 0; j < meret; j++)
                {
                    Button btn = new Button
                    {
                        Name = $"btn_{index}",
                        FontSize = 360/meret/4,
                        Margin = new Thickness(2),
                        Height = 360 / meret,
                        Width = 360 / meret,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                    };
                    btn.Click += Buttton_Click;
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    grid_kartyak.Children.Add(btn);
                    index++;
                }
            }
            Random rnd = new Random();
            for (int i = 0; i < meret * meret; i++)
            {
                bool jo = false;
                while (!jo)
                {
                    int a = rnd.Next(0, meret * meret / 2);
                    int b = 0;
                    foreach (var item in sorrend)
                    {
                        if (item == a)
                        {
                            b++;
                        }
                    }
                    if (b < 2)
                    {
                        jo = true;
                        sorrend.Add(a);
                    }
                }
            }
        }

        private void Buttton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(Convert.ToString(btn.Name.Remove(0,4)));
            if (masodik)
            {
                if (elso.Name != btn.Name)
                {
                    btn.Content = GetContent(index);
                    if (elso.Content == btn.Content)
                    {
                        pontszam++;
                    }
                    else
                    {
                        Thread.Sleep(5000);
                        btn.Content = "";
                        elso.Content = "";
                    }
                    masodik = false;
                    probalkozasok++;
                }
            }
            else
            {
                btn.Content = GetContent(index);
                elso = btn;
                masodik = true;
            }
        }

        private string GetContent(int index)
        {
            return kivalasztottTema switch
            {
                1 => tema1[sorrend[index]],
                2 => tema2[sorrend[index]],
                3 => tema3[sorrend[index]]
            };
        }
    }
}
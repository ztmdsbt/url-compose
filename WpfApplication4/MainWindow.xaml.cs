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
using CsvHelper;
using System.IO;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LanguageSymbols = new List<LanguageSymbol>();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var reader = File.OpenText("language.csv");
            var csv = new CsvReader(reader);
            while(csv.Read())
            {
                var symbol = new LanguageSymbol();
                symbol.LanguageName = csv.GetField<string>(0);
                symbol.Region = csv.GetField<string>(1);
                symbol.Symbol = csv.GetField<string>(2);
                LanguageSymbols.Add(symbol);
            }

            lbLanguageSymbol.ItemsSource = LanguageSymbols;
        }

        public List<LanguageSymbol> LanguageSymbols { get; set; }

        public List<string> Urls { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((lbLanguageSymbol.SelectedItem as LanguageSymbol).LanguageName);
        }
       
    }
}

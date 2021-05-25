using System;
using System.Collections.Generic;
using System.Configuration;
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
using ItemsLibrary;


namespace WpfBalieMedewerkers
{
    /// <summary>
    /// Logique d'interaction pour Items.xaml
    /// </summary>
    public partial class Items : Page
    {
        string connString = ConfigurationManager.AppSettings["connString"];
        public Items()
        {
            ReloadEmployees(null);
            InitializeComponent();
            string[] files = Directory.GetFiles("../../Image", "*.jpg"); // startfolder = bin/Debug/
            for (int i = 0; i < files.Length; i++)
            {
                // get file url
                string filename = files[i];
                FileInfo fi = new FileInfo(filename);

                // create image and label
                Image img = new Image();
                img.Width = 80;
                img.Source = new BitmapImage(new Uri(filename, UriKind.Relative));
                Label lbl = new Label();
                lbl.Content = $"photo {i + 1}";

                // create stackpanel
                StackPanel pnl = new StackPanel();
                pnl.Margin = new Thickness(0, 0, 20, 20);
                pnl.Children.Add(img);
                pnl.Children.Add(lbl);

                // add stackpanel to wrappanel
                wrpPanel.Children.Add(pnl);
            }
        }

        public void Reload(int? selectedId)
        {
            // wis lijst en labels
            lbxResults.Items.Clear();

            // laad alle werknemers in
            List<Items> allEmps = new List<Items>();
            foreach (Items emp in allEmps)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = emp.ToString();
                item.Tag = emp.Id;
                item.IsSelected = selectedId == emp.Id;
                lbxResults.Items.Add(item);
            }
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lbxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

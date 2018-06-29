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
using ClassLibrary;

namespace WPF
{
    /// <summary>
    /// Interaction logic for Owners.xaml
    /// </summary>
    public partial class Owners : Page
    {
        APIClient client;
        List<OwnerClass> owner;
        OwnerClass ownerssssss;
        public Owners()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            owner = await client.GetOwners();

            ownersDG.ItemsSource = owner;
        }

        private void Procedures1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Procedures.xaml", UriKind.Relative));
        }

        private void OwnerBt_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Owners.xaml", UriKind.Relative));
        }


        private async void ownersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            client = new APIClient();

            ownerssssss = (OwnerClass)ownersDG.SelectedItem;
            if (ownerssssss != null)
            { 
                SurnameTb.Text = ownerssssss.Surname;
                GivenNameTb.Text = ownerssssss.GivenName;
                PhoneTb.Text = ownerssssss.Phone.ToString();
            }

            CreateBt.IsEnabled = false;
            DeleteBt.IsEnabled = true;
            UpdateBt.IsEnabled = true;

            //owner = await client.GetOwners();
        }

        private async void CreateBt_Click(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            OwnerClass newOwner = new OwnerClass()
            {
                OwnerID = await client.GetOwnerID(),

                Surname = SurnameTb.Text,
                GivenName = GivenNameTb.Text,
                Phone = Int32.Parse(PhoneTb.Text)
            };

            await client.CreateOwner(newOwner);

            SurnameTb.Text = null;
            GivenNameTb.Text = null;
            PhoneTb.Text = null;

            owner = await client.GetOwners();

            ownersDG.ItemsSource = owner;
        }

        private async void UpdateBt_Click(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            OwnerClass updateOwner = new OwnerClass()
            {
                OwnerID = ownerssssss.OwnerID,
                Surname = SurnameTb.Text,
                GivenName = GivenNameTb.Text,
                Phone = Int32.Parse(PhoneTb.Text)

            };

            await client.UpdateOwner(updateOwner);

            owner = await client.GetOwners();

            ownersDG.ItemsSource = owner;
        }

        private async void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            client = new APIClient();

            await client.DeleteOwner(ownerssssss);

            owner = await client.GetOwners();

            ownersDG.ItemsSource = owner;

        }
    }
}

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
    /// Interaction logic for Procedures.xaml
    /// </summary>
    public partial class Procedures : Page
    {
        APIClient client;
        List<ProcedureClass> proceduresClassssss;
        List<TreatmentClass> treatmentClassssss;
        ProcedureClass selectedpt;
        List<ProceduresTreatments> ptt;


        public Procedures()
        {
            InitializeComponent();
            DataContext = this;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            client = new APIClient();
           proceduresClassssss = await client.GetProcedures();
          treatmentClassssss = await client.GetTreatments();

            procedureDG.ItemsSource = proceduresClassssss;
        }

        private async void procedureDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            client = new APIClient();

            selectedpt = (ProcedureClass)procedureDG.SelectedItem;

            proceduresClassssss = await client.GetProcedures();
            treatmentClassssss = await client.GetTreatments();
            ptt = (from p in proceduresClassssss
                       join t in treatmentClassssss
                       on p.ProcedureID equals t.ProcedureID
                       where selectedpt.ProcedureID == t.ProcedureID
                       select new ProceduresTreatments
                       {
                           PetName = t.PetName,
                           OwnerID = t.OwnerID,
                           ProcedureID = p.ProcedureID,
                           Description = p.Description,
                           Date = t.Date,
                           Notes = t.Notes,
                           Price = p.Price
                       }).ToList();

           treatmentsDG.ItemsSource = ptt;
        }

        private void OwnerBt_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Owners.xaml", UriKind.Relative));
        }

        private void Procedures1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Procedures.xaml", UriKind.Relative));
        }
    }
}

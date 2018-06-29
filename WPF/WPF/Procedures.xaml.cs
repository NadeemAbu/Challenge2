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

        public Procedures()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            client = new APIClient();
            List<ProcedureClass> allProcedures = await client.GetProcedures();

            var proceduresList = from c in allProcedures
        }

        private void procedureDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

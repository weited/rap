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
using System.Windows.Shapes;
using RAP.Control;
/*adding for button <cumulative count> */
using RAP.Research;

namespace RAP.View
{
    /// <summary>
    /// Interaction logic for CumulativePublicationsView.xaml
    /// </summary>
    public partial class CumulativePublicationsView : Window
    {
        public CumulativePublicationsView()
        {
            InitializeComponent();
            //Displaypublicationlist();
            Count_publications.ItemsSource = PublicationsController.CumulativeCount();
        }

        
        /*adding for button <cumulative count> */
        /*
        private void Displaypublicationlist()
        {
            List<Publication> publications = (List<Publication>)(App.Current.Properties["ShowPublicationList"]);

            /*reorder data
            var newPublicationCount_list = (from p in publications orderby p.Year select p).ToList();
            Count_publications.ItemsSource = newPublicationCount_list;
        }
        */
    }
}

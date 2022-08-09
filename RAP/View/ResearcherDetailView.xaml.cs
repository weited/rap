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
using RAP.Research;
using RAP.Control;
using System.Net;

namespace RAP.View
{
    /// <summary>
    /// Interaction logic for ResearcherDetailView.xaml
    /// </summary>
    public partial class ResearcherDetailView : UserControl
    {
        private Researcher currentResearchers;
        private ResearcherController ResearcherCtrl = new ResearcherController();
        private PublicationDetailsView PubDetailsView = new PublicationDetailsView();

        public ResearcherDetailView()
        {
            InitializeComponent();
            
        }
        internal void SetDetails(Researcher researcher)
        {
            if (researcher != null)
            {
                currentResearchers = researcher;
                ResearcherDetails.DataContext = researcher;
            }
        }
        /*add button for <show me> */
        private void Show_Studentname_Click(object sender, RoutedEventArgs e)
        {
            Staff not_student = currentResearchers as Staff;
            if (not_student != null)
            /*if (not_student.Supervisions != 0)*/
            {
                List<Researcher> researcherList = ResearcherCtrl.fetchSupervisions(currentResearchers);
                string message = string.Join("\n", researcherList);
                MessageBox.Show(message, "Student name");


            }

        }
        /* add button for <cumulayiveCount> */
        private void Publication_Count_Click(object sender, RoutedEventArgs e)
        {
            if (currentResearchers != null)
                if (currentResearchers.publications.Count != 0)
                {
                    App.Current.Properties["ShowPublicationList"] = currentResearchers.publications;

                    CumulativePublicationsView Count_PublicationsWindow = new CumulativePublicationsView();
                    Count_PublicationsWindow.Show();
                }

        }

        private void showPublicationDetail(object sender, SelectionChangedEventArgs e)
        {
            Publication publication = e.AddedItems.Count == 0 ? null : (Publication)e.AddedItems[0];

            if (publication != null)
            {
                App.Current.Properties["PublicationDetail"] = publication;
                PubDetailsView.Show();
                PubDetailsView.DisplayYearTitle();
            }

        }
    }
}

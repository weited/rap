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
using RAP.Database;
namespace RAP.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ResearcherController ResearcherCtrl = new ResearcherController();
        public MainWindow()
        {
            InitializeComponent();
            ResearcherCtrl = (ResearcherController)Application.Current.FindResource("ResearcherController");
            ResearcherListPanel.LoadResearcherDetailsEvent += LoadResearcherDetails;
        }

        private void LoadResearcherDetails(object sender, EventArgs e)
        {
            var selectedRes = (SelectionChangedEventArgs)e;
            //var researcherAsset = selectedRes.AddedItems.Count == 0 ? null : (Researcher)selectedRes.AddedItems[0];
            if (selectedRes.AddedItems.Count > 0)
            {
                var researcherList=(Researcher)selectedRes.AddedItems[0];
                var researcher = researcherList == null ? null : ResearcherCtrl.LoadResearcherDetails(researcherList.id);
                ResearcherDetailPanel.SetDetails(researcher);
            }

            
        }
    }
}

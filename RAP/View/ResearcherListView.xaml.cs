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

namespace RAP.View
{
    /// <summary>
    /// Interaction logic for ResearcherListView.xaml
    /// </summary>
    public partial class ResearcherListView : UserControl
    {
        //private ResearcherController researcher;
        //private const string RESEARCHER_LIST_KEY = "researcherList";
        private ResearcherController ResearcherCtrl = new ResearcherController();
        public event EventHandler LoadResearcherDetailsEvent;
        public ResearcherListView()
        {
            InitializeComponent();
            //researcher = (ResearcherController)(Application.Current.FindResource(RESEARCHER_LIST_KEY) as ObjectDataProvider).ObjectInstance;
            ResearcherCtrl = (ResearcherController)Application.Current.FindResource("ResearcherController");
        }

        private void FilterByName(object sender, TextChangedEventArgs e)
        {
            string searchName = FilterName.Text;
            ResearcherCtrl.FilterByName(searchName);
        }



        
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadResearcherDetailsEvent?.Invoke(sender, e);
        }

        private void setEmpLevel(object sender, SelectionChangedEventArgs e)
        {
            switch (emp_Level.SelectedIndex)
            {
                case 0:
                    ResearcherCtrl.FilterByEmpLevel("All");
                    break;
                case 1:
                    ResearcherCtrl.FilterByEmpLevel("Student");
                    break;
                case 2:
                    ResearcherCtrl.FilterByEmpLevel("A");
                    break;
                case 3:
                    ResearcherCtrl.FilterByEmpLevel("B");
                    break;
                case 4:
                    ResearcherCtrl.FilterByEmpLevel("C");
                    break;
                case 5:
                    ResearcherCtrl.FilterByEmpLevel("D");
                    break;
                case 6:
                    ResearcherCtrl.FilterByEmpLevel("E");
                    break;
            }

        }

        private void Generate_Report_Click(object sender, RoutedEventArgs e)
        {
            ReportView ReportWindow = new ReportView();
            ReportWindow.Show();
        }
    }
}

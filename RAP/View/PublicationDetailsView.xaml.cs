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
using RAP.Research;

namespace RAP.View
{
    /// <summary>
    /// Interaction logic for PubDetailsView.xaml
    /// </summary>
    public partial class PublicationDetailsView : Window
    {
        public PublicationDetailsView()
        {
            InitializeComponent();
            
        }
        public void DisplayYearTitle()

        {
            Publication publication = (Publication)App.Current.Properties["PublicationDetail"];
            PubDetailsLB.DataContext = publication;

        }
        //closing window after exit
        private void Window_closing(object sender, System.ComponentModel.CancelEventArgs e)

        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }
    }
}

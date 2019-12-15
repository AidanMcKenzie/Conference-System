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

namespace Coursework
{
    // AUTHOR: Aidan McKenzie
    // DATE LAST MODIFIED: 22/10/2016
    // CLASS DESCRIPTION: Invoice is a window activated when the 'Invoice' button is pressed. It contains labels
            // which include the data the user entered for first name, last name, institution name, conference name and the cost 
            // which was determined with the getCost method. It also has a close button to close the window.
    public partial class Invoice : Window
    {
        public Invoice(string firstName, string lastName, string instName, string confName, double cost)
        {
            InitializeComponent();
            // Set the label's content to have user's first name and second name
            lblInvFirstLast.Content = firstName + " " + lastName;
            // Set the label's content to have Institution name
            lblInvInstData.Content = instName;
            // Set the label's content to have conference name
            lblInvConfData.Content = confName;
            // Set the label's content to have the price/cost
            lblInvPriceData.Content = "£" + cost;
        }

        // Closes window
        private void btnInvClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

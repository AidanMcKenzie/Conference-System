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
    // CLASS DESCRIPTION: CertificateWindow is a window activated when the 'Certificate' button is pressed. It contains labels
            // which include the data the user entered for first name, last name, conference name and Paper Title. It also has
            // a close button to close the window.
    public partial class CertificateWindow : Window
    {
        public CertificateWindow(string firstName, string lastName, string confName, string paperTitle)
        {
            InitializeComponent();
            // Set the label's content to have user's first name and second name
            lblFirstSecond.Content = firstName + " " + lastName;
            // Set the label's content to have the conference name
            lblConfName.Content = confName;

            // If the Paper Title textbox wasn't empty
            if (paperTitle != null)
            {
                // Set the label's content to include the paper title entered
                lblPaper.Content = "and presented a paper entitled\n" + paperTitle + ".";
            }
        }

        // Closes the window
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

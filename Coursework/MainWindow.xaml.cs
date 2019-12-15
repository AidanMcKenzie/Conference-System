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



namespace Coursework
{
    // AUTHOR: Aidan McKenzie
    // DATE LAST MODIFIED: 23/10/2016
    // CLASS DESCRIPTION: MainWindow class is the GUI that the user will interact with. The user is prompted to enter information
            // in the textboxes. Buttons all have different uses, such as 'Set' will apply information entered as attributes of the
            // class 'Attendee', 'Clear' button will erase all data entered in TextBox, 'Get' will re-enter information that was set,
            // whilst 'Invoice' and 'Certificate' open separate windows.
    public partial class MainWindow : Window
    {
        // Create new instance of Attendee class
        Attendee newAtt = new Attendee();
        // Set variable 'cost' to 0; For use with getCost() method
        double cost = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        // Code for whe the Set button is clicked
        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            // Checks if first name box is empty
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("Please enter your forename");
            }
            // Else attendee's first name is what was entered in the FirstName box
            else
            {
                newAtt.FirstName = txtFirstName.Text;
            }

            // Checks if last name box is empty
            if (txtLastName.Text == "")
            {
                MessageBox.Show("Please enter your surname");
            }
            // Else attendee's last name is what was entered in the LastName box
            else
            {
                newAtt.LastName = txtLastName.Text;
            }

            // If exclusively numbers are entered
            if (System.Text.RegularExpressions.Regex.IsMatch(txtAttendeeRef.Text, "[ ^ 0-9]"))
            {
                // Else if the number is in the correct range, set the value
                if (Int32.Parse(txtAttendeeRef.Text) > 39999 && Int32.Parse(txtAttendeeRef.Text) < 60001)
                {
                    newAtt.AttendeeRef = Int32.Parse(txtAttendeeRef.Text);
                }
                // Else prompt the user to enter the correct data
                else
                {
                    MessageBox.Show("Please enter a numeric value between 40000 and 60000 for Attendee Ref");
                }
            }
            // Else prompt the user to enter the correct data
            else
            {
                MessageBox.Show("Please enter a numeric value between 40000 and 60000 for Attendee Ref");
            }

            // Sets Institution name
            newAtt.InstName = txtInstName.Text;

            // Checks if Conference box is empty
            if (txtConfName.Text == "")
            {
                MessageBox.Show("Please enter the Conference Name");
            }
            else
            {
                newAtt.ConfName = txtConfName.Text;
            }

            // Checks if RegType was selected correctly
            if (rdoFull.IsChecked == true)
            {
                newAtt.RegType = "Full";
            }
            else if (rdoStudent.IsChecked == true)
            {
                newAtt.RegType = "Student";
            }

            else if (rdoOrganiser.IsChecked == true)
            {
                newAtt.RegType = "Organiser";
            }
            else
            {
                MessageBox.Show("Please select a Registration Type");
            }

            //Checks which radio button for Paid was selected
            if (rdoPaidYes.IsChecked == true)
            {
                newAtt.Paid = true;
            }
            else if (rdoPaidNo.IsChecked == true)
            {
                newAtt.Paid = false;
            }
            else
            {
                MessageBox.Show("Please select an option for Paid");
            }

            // Checks if Presenter button is checked
            if (rdoPresYes.IsChecked == true)
            {
                newAtt.Presenter = true;
            }
            else if (rdoPresNo.IsChecked == true)
            {
                newAtt.Presenter = false;
            }
            else
            {
                MessageBox.Show("Please select an option for Presenter");
            }


            // Checks if Paper Title is empty or not and if presenter being true affects it
            if (newAtt.Presenter == true)
            {
                if (txtPaperTitle.Text == "")
                {
                    MessageBox.Show("Please enter a Paper Title");
                }
                else
                {
                    newAtt.PaperTitle = txtPaperTitle.Text;
                }
            }
            
        }

       // Code for the Clear button, sets all textboxes/buttons to empty or null
       private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAttendeeRef.Text = "";
            txtInstName.Text = "";
            txtConfName.Text = "";
            rdoFull.IsChecked = null;
            rdoStudent.IsChecked = null;
            rdoOrganiser.IsChecked = null;
            rdoPaidYes.IsChecked = null;
            rdoPaidNo.IsChecked = null;
            rdoPresYes.IsChecked = null;
            rdoPresNo.IsChecked = null;
            txtPaperTitle.Text = "";
        }

        // Code for the Get button
        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            // Fills the texboxes with the appropriate data
            txtFirstName.Text = newAtt.FirstName;
            txtLastName.Text = newAtt.LastName;
            txtAttendeeRef.Text = newAtt.AttendeeRef.ToString();
            txtInstName.Text = newAtt.InstName;
            txtConfName.Text = newAtt.ConfName;

            // Get the correct Registration Type radio button
            if (newAtt.RegType == "Full")
            {
                rdoFull.IsChecked = true;
            }
            else if (newAtt.RegType == "Student")
            {
                rdoStudent.IsChecked = true;
            }
            else if (newAtt.RegType == "Organiser")
            {
                rdoOrganiser.IsChecked = true;
            }
            else
            {
                MessageBox.Show("ERROR: Cannot get RegType");
            }

            // Get the correct Paid radio button
            if (newAtt.Paid == true)
            {
                rdoPaidYes.IsChecked = true;
            }
            else if (newAtt.Paid == false)
            {
                rdoPaidNo.IsChecked = true;
            }
            else
            {
                MessageBox.Show("ERROR: Cannot get selection for Paid");
            }

            // Gets the correct Presenter radio button
            if (newAtt.Presenter == true)
            {
                rdoPresYes.IsChecked = true;
            }
            else if (newAtt.Presenter == false)
            {
                rdoPresNo.IsChecked = true;
            }
            else
            {
                // Error check
                MessageBox.Show("ERROR: Cannot get selection for Presenter");
            }
            txtPaperTitle.Text = newAtt.PaperTitle;

        }

        // getCost() method checks Registration Type to see the cost of the Attendee
        private double getCost()
        {
            // If RegType is Full/Student/Organiser, apply correct cost
            if (newAtt.RegType == "Full")
            {
                cost = 500;
            }
            else if (newAtt.RegType == "Student")
            {
                cost = 300;
            }
            else if (newAtt.RegType == "Organiser")
            {
                cost = 0;
            }
            else
            {
                MessageBox.Show("ERROR: Cannot ascertain price");
            }
            // If presenter is selected, get 10% off the cost
            if(newAtt.Presenter == true)
            {
                cost = cost * 0.9;
            }
            return cost;
        }

        // Code for the Invoice button
        private void btnInvoice_Click(object sender, RoutedEventArgs e)
        {
            // If FirstName or ConfName boxes are empty, do not continue
            if ((txtFirstName.Text == "") || (txtConfName.Text == ""))
            {
                MessageBox.Show("Please select 'Set' before selecting 'Invoice'");
            }
            // Else run getCost() and open a new window, passing through the adequate information from Attendee
            else
            {
                getCost();
                Window Invoice = new Invoice(newAtt.FirstName, newAtt.LastName, newAtt.InstName, newAtt.ConfName, cost);
                Invoice.Show();
            }
        }

        // Code for the Certificate button
        private void btnCert_Click(object sender, RoutedEventArgs e)
        {
            // If FirstName or ConfName boxes are empty, do not continue
            if ((txtFirstName.Text == "") || (txtConfName.Text == ""))
            {
                MessageBox.Show("Please select 'Set' before selecting 'Certificate'");
            }
            // Else open a new Certificate window, passing through the adequate information from Attendee
            else
            {
                Window CertificateWindow = new CertificateWindow(newAtt.FirstName, newAtt.LastName, newAtt.ConfName, newAtt.PaperTitle);
                CertificateWindow.Show();
            }
        }

        private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

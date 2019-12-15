using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// AUTHOR: Aidan McKenzie
// DATE LAST MODIFIED: 20/10/2016
// CLASS DESCRIPTION: Attendee class contains all the values pertaining to what a user ('the attendee') enters into the GUI.
        // Class contains private declarations (strings, ints and bools) and public getters and setters for use with GUI.
namespace Coursework
{
    class Attendee : Person
    {
        // Declaring all strings/booleans
        private int attendeeRef;
        private string instName;
        private string confName;
        private string regType;
        private bool paid;
        private bool presenter;
        private string paperTitle;

        // Public getters and setters
        public int AttendeeRef
        {
            get { return attendeeRef; }
            set { attendeeRef = value; }   
        }

        public string InstName
        {
            get { return instName; }
            set { instName = value; }
        }

        public string ConfName
        {
            get { return confName; }
            set { confName = value; }
        }

        public string RegType
        {
            get { return regType; }
            set { regType = value; }
        }

        public bool Paid
        {
            get { return paid; }
            set { paid = value; }
        }

        public bool Presenter
        {
            get { return presenter; }
            set { presenter = value; }
        }

        public string PaperTitle
        {
            get { return paperTitle; }
            set { paperTitle = value; }
        }
    }
}

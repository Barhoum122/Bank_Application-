using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
   public  class person
    {
        string _FirstName="";
        string _LastName="";
        string _Phone  ="";
        string _Email   = "";
        public  person(string FirstName, string LastName, string Phone, string Email)
        {
            _FirstName = FirstName;
            _LastName = LastName;
            _Phone = Phone;
            _Email = Email;

        }
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class ContactDetails
    {
        //variable declaration
        private string firstname;
        private string lastname;
        private string address;
        private string city;
        private string state;
        private int zip;
        private long phonenumber;

        //creating xonstructor
        public ContactDetails(string firstname, string lastname, string address, string city, string state, int zip, long phonenumber)
        {
            //assigning variables
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phonenumber = phonenumber;
        }
        //Displaying details
        public void getDetails()
        {
            Console.WriteLine("Contact details : " + "\nName : " + firstname + " " + lastname + "\nAddress : " + address + "\nCity : " + city + "\nState : " + state + "\nZip Code : " + zip + "\nPhoneNumber = " + phonenumber);
        }


        static void Main(string[] args)
        {
            //creating object of ContactDetails
            ContactDetails contactdetails = new ContactDetails("Amir", "Jamadar", "Sangli", "Sangli", "Maharashtra", 415409, 9096076758);
            contactdetails.getDetails();
            Console.ReadLine();
        }
    }
}

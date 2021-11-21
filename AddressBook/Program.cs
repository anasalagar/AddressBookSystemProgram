using System;
using System.Collections.Generic;


namespace AddressBookSystem
{
    class AddContactDetails
    {
        public static void setDetails()
        {
            List<string> details = new List<string>();                        //creating list collection object

            Console.WriteLine("WELCOME TO ADDRESS BOOK");                     //display welcome message
            Console.WriteLine();
            Console.Write("Enter number of person details you are adding : "); //taking user input
            int count = Convert.ToInt32(Console.ReadLine());                   //converting string to integer  
            //variable declaration
            int i = 1;
            while (count >= i)
            {
                Console.WriteLine();
                Console.WriteLine("\nEnter new contact details :");
                Console.WriteLine();
                Console.Write("Enter Your First Name : ");          //taking input from user
                string firstname = Console.ReadLine();              //storing into variable
                details.Add("First Name: " + firstname);              //adding into list collection
                Console.Write("Enter Your Last Name : ");
                string lastname = Console.ReadLine();
                details.Add("Last Name : " + lastname);
                Console.Write("Enter Your address : ");
                string address = Console.ReadLine();
                details.Add("Address : " + address);
                Console.Write("Enter Your City Name : ");
                string city = Console.ReadLine();
                details.Add("City : " + city);
                Console.Write("Enter Your State Name : ");
                string state = Console.ReadLine();
                details.Add("State : " + state);
                Console.Write("Enter Your Zip Code : ");
                long zip = Convert.ToInt32(Console.ReadLine());
                details.Add("Zip Code : " + zip);
                Console.Write("Enter Your Phone Number : ");
                long phonenumber = Convert.ToInt64(Console.ReadLine());
                details.Add("Phone Number : " + phonenumber);


                Console.Write("\nDetails of Contact Number " + i);          //display contact details
                Console.WriteLine();
                Console.WriteLine();
                details.ForEach(Console.WriteLine);
                i++;
            }

        }

        static void Main(string[] args)
        {
            //calling function
            AddContactDetails.setDetails();
            Console.ReadLine();
        }
    }
}
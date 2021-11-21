using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBook
    {
        //declaring list with class contacts type
        public static List<ContactDetails> contacts = new List<ContactDetails>();
        //declaring dictionary
        public static Dictionary<string, List<ContactDetails>> addressBook = new Dictionary<string, List<ContactDetails>>();

        //the citybook and statebook dictionaries are basically to store person details along with key as city/state 
        public static Dictionary<string, List<ContactDetails>> cityBook = new Dictionary<string, List<ContactDetails>>();
        public static Dictionary<string, List<ContactDetails>> stateBook = new Dictionary<string, List<ContactDetails>>();

        //declaring it static so that we dont need to create an object in the program.cs
        //this method is used to pass the new address book name to the dictionary
        public static void AddTo(string name)
        {
            addressBook.Add(name, contacts);
        }
        //This method for add new contact in address book
        public void AddContact()
        {
            //creating object of ContactDetails class
            ContactDetails contact = new ContactDetails();
            Console.Write("Enter First Name : ");
            //storing user input in contact
            contact.firstName = Console.ReadLine();
            Console.Write("Enter Last Name : ");
            contact.lastName = Console.ReadLine();
            Console.Write("Enter address Name : ");
            contact.address = Console.ReadLine();
            Console.Write("Enter phone number : ");
            contact.phoneNumber = Console.ReadLine();
            Console.Write("Enter Email Id : ");
            contact.email = Console.ReadLine();
            Console.Write("Enter city Name : ");
            contact.city = Console.ReadLine();
            Console.Write("Enter state Name : ");
            contact.state = Console.ReadLine();
            Console.Write("Enter zip code : ");
            contact.zip = Console.ReadLine();
            //storing all input from user into contacts
            contacts.Add(contact);
        }
        //This method for view added Contact details
        public void ViewDetails()
        {
            //if statement for show nothing in list
            if (contacts.Count == 0)
            {
                Console.WriteLine("Currently there are no people added in your addressbook.");
            }
            //else statement for show details of contacts in addressbook
            else
            {
                Console.WriteLine("Here is the list and details of all the contacts in your addressbook.");

                //tforeacch loops iterates through all the contacts objects in the contacts class
                foreach (var Detailing in contacts)
                {
                    Console.WriteLine("First name : " + Detailing.firstName);
                    Console.WriteLine("Last name : " + Detailing.lastName);
                    Console.WriteLine("Address : " + Detailing.address);
                    Console.WriteLine("State : " + Detailing.state);
                    Console.WriteLine("City : " + Detailing.city);
                    Console.WriteLine("Zip Code : " + Detailing.zip);
                    Console.WriteLine("Phone number = " + Detailing.phoneNumber);
                }
            }
        }
        //This method for edit contact details
        public void EditDetails()
        {
            Console.WriteLine("Enter the first name of the contact you want to Modify.");
            Console.WriteLine();
            //taking input from user 
            string name = Console.ReadLine();
            //for each loop for show details of contacts
            foreach (var Details in contacts)
            {
                //if statement for first name of input matches with already existed contact first name
                if (name == Details.firstName)
                {
                    Console.Write("Enter First Name - ");
                    Details.firstName = Console.ReadLine();
                    Console.Write("Enter Last Name - ");
                    Details.lastName = Console.ReadLine();
                    Console.Write("Enter Address - ");
                    Details.address = Console.ReadLine();
                    Console.Write("Enter Phone number - ");
                    Details.phoneNumber = Console.ReadLine();
                    Console.Write("Enter Email ID - ");
                    Details.email = Console.ReadLine();
                    Console.Write("Enter City - ");
                    Details.city = Console.ReadLine();
                    Console.Write("Enter State - ");
                    Details.state = Console.ReadLine();
                    Console.Write("Enter ZIP code - ");
                    Details.zip = Console.ReadLine();
                    break;
                }
                //else statement from if input from user is mismatches with existing contact first name
                else
                {
                    Console.WriteLine("No such entry found. Please check and try again!");
                    break;
                }
            }

        }
        //this method for delete contact details
        public void DeleteContact()
        {
            //Taking input from user
            Console.Write("Enter the first name of contact you want to delete : ");
            Console.WriteLine();
            string name = Console.ReadLine();
            foreach (var Details in contacts)
            {
                //if statement for matching first name of existing contact with input taken from user
                if (name == Details.firstName)
                {
                    //if condition true then contact is deleted
                    Console.WriteLine("Do you want to delete this Contact ? (y/n)");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        contacts.Remove(Details);
                        Console.WriteLine("Contact is deleted.");
                        break;
                    }
                }
                //if condition is false then else condition is executed
                else
                {
                    Console.WriteLine("Contact is not present");
                }
            }
        }

        //this method takes the list and contactbook object of contacts class
        public static int SearchDuplicate(List<ContactDetails> contacts, ContactDetails contactBook)
        {
            //iteratingall elements in contact list by using for each loop
            foreach (var Details in contacts)
            {
                //using lambda expression and equals method
                var person = contacts.Find(p => p.firstName.Equals(contactBook.firstName));
                if (person != null)
                {
                    Console.WriteLine("Already this contact exist with same first name : " + person.firstName);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        //This method for search person using city name
        public static void SearchCity()
        {
            Console.WriteLine("Please Enter Name of city");
            string city = Console.ReadLine();
            foreach (var Details in contacts)
            {
                var person = contacts.Find(p => p.city.Equals(city));
                if (person != null)
                {
                    Console.WriteLine("{0} person in the {1}", Details.firstName, city);
                }
                else
                {

                }
            }

        }

        //This method for search person using state name
        public static void SearchState()
        {
            Console.WriteLine("Please Enter Name of State");
            string state = Console.ReadLine();
            foreach (var Details in contacts)
            {
                var person = contacts.Find(p => p.state.Equals(state));
                if (person != null)
                {
                    Console.WriteLine("{0} person in the {1}", Details.firstName, state);
                }
                else
                {

                }
            }

        }
        //This method for add person details by using city name
        public void AddByCity()
        {
            foreach (var Detail in contacts)
            {
                string city = Detail.city;
                if (cityBook.ContainsKey(city))
                {
                    List<ContactDetails> exist = cityBook[city];
                    exist.Add(Detail);
                }
                else
                {
                    List<ContactDetails> cityContact = new List<ContactDetails>();
                    cityContact.Add(Detail);
                    cityBook.Add(city, cityContact);
                }
            }
        }
        //This method for add person details by using  state name
        public void AddByState()
        {
            foreach (var Detail in contacts)
            {
                string state = Detail.state;
                if (stateBook.ContainsKey(state))
                {
                    List<ContactDetails> exists = stateBook[state];
                    exists.Add(Detail);

                }
                else
                {
                    List<ContactDetails> stateContact = new List<ContactDetails>();
                    stateContact.Add(Detail);
                    stateBook.Add(state, stateContact);
                }
            }
        }
        /// <summary>
        /// Views the by the selected option whther chosen to view by state or city
        /// if the user selects to choose city, he has to selct 1 and 2 for statewise display of contacts
        /// this method displayes city and all the common persons residing in that place
        /// </summary>
        public void ViewByCityOrStateName()
        {
            Console.WriteLine("Please select your option: \n 1 :  To view all contacts by city, \n 2 : To view all contacts by state.");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                int cityCount = cityBook.Count();
                if (cityCount != 0)
                {
                    foreach (KeyValuePair<string, List<ContactDetails>> item in cityBook)
                    {
                        Console.WriteLine("\n Following are the Person details residing in the city -" + item.Key);
                        foreach (var items in item.Value)
                        {
                            //Printing added details
                            Console.WriteLine("First Name : " + items.firstName);
                            Console.WriteLine("Last Name : " + items.lastName);
                            Console.WriteLine("Address : " + items.address);
                            Console.WriteLine("Phone Number : " + items.phoneNumber);
                            Console.WriteLine("Email ID : " + items.email);
                            Console.WriteLine("City : " + items.city);
                            Console.WriteLine("State : " + items.state);
                            Console.WriteLine("ZIP code : " + items.zip);
                        }

                    }
                }
                else
                {
                    Console.WriteLine("\nCurrently no entries are inserted.");
                }
            }
            else if (choice == 2)
            {

                int stateCount = stateBook.Count();
                if (stateCount != 0)
                {
                    foreach (KeyValuePair<string, List<ContactDetails>> item in stateBook)
                    {
                        Console.WriteLine("\n Following are the Person details residing in the state -" + item.Key);
                        foreach (var items in item.Value)
                        {
                            //Printing added details
                            Console.WriteLine("First Name : " + items.firstName);
                            Console.WriteLine("Last Name : " + items.lastName);
                            Console.WriteLine("Address : " + items.address);
                            Console.WriteLine("Phone Number : " + items.phoneNumber);
                            Console.WriteLine("Email ID : " + items.email);
                            Console.WriteLine("City : " + items.city);
                            Console.WriteLine("State : " + items.state);
                            Console.WriteLine("ZIP code : " + items.zip);
                        }

                    }
                }
                else
                {
                    Console.WriteLine("\nCurrently no entries are inserted.");
                }

            }
            else
            {
                Console.WriteLine("\nWrong entry, Please choose between 1 and 2");
            }
        }
        //This method for to get number of contact persons by counting city or state
        public void CountByCityOrStateName()
        {
            Console.WriteLine("Select 1 : count person by city, \n2: Count person by state");
            int num = Convert.ToInt32(Console.ReadLine());
            void CountByCity()
            {
                foreach (var item in cityBook)
                {
                    int count = item.Value.Count();
                    Console.WriteLine("There are {0} number of people in City- {1}", count, item.Key);
                }
            }
            void CountBystate()
            {
                foreach (var item in stateBook)
                {
                    int count = item.Value.Count();
                    Console.WriteLine("There are {0} number of people in City- {1}", count, item.Key);
                }
            }

            if (num == 1)
            {
                //When there are atleast 1 entry
                if (cityBook.Count != 0)
                {
                    CountByCity();
                }
                else
                {
                    Console.WriteLine("Currently no entries stored");
                }
            }
            else if (num == 2)
            {
                if (stateBook.Count != 0)
                {
                    CountBystate();
                }
                else
                {
                    Console.WriteLine("Currently no entries stored");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection, please select between 1 and 2");
            }

        }
        public void SortByFirstName(List<ContactDetails> contactDetails)
        {
            contacts = contactDetails.OrderBy(p => p.firstName).ToList();
        }
        public void SortByChoice(List<ContactDetails> contactDetails)
        {
            Console.WriteLine("Select the option to sort the contct list : \n1 : City Name \n2 : State Name \n3. Zip Code");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num == 1)
            {
                contacts = contactDetails.OrderBy(p => p.city).ToList();
            }
            if (num == 2)
            {
                contacts = contactDetails.OrderBy(p => p.state).ToList();
            }
            if (num == 3)
            {
                contacts = contactDetails.OrderBy(p => p.zip).ToList();
            }
            else
            {
                Console.WriteLine("Invalid Selection,please select between 1 to 3 ");
            }
        }
        //This method for writing address book with person contact into .txt file using File IO
        public static void WriteAddressBookUsingStreamWriter()
        {
            //provide file path
            string path = @"C:\Users\Admin\source\repos\AddressBookSystem\Files\AddressBookWriterFile.txt";
            using (StreamWriter se = File.AppendText(path))
            {
                //iterating each element from addressbook dictionary
                foreach (KeyValuePair<string, List<ContactDetails>> item in addressBook)
                {
                    foreach (var items in item.Value)
                    {
                        //writing in .txt file
                        se.WriteLine("First Name -" + items.firstName);
                        se.WriteLine("Last Name -" + items.lastName);
                        se.WriteLine("Address -" + items.address);
                        se.WriteLine("Phone Number - " + items.phoneNumber);
                        se.WriteLine("Email ID -" + items.email);
                        se.WriteLine("City -" + items.city);
                        se.WriteLine("State -" + items.state);
                        se.WriteLine("ZIP code -" + items.zip);
                    }
                    se.WriteLine("--------------------------------------------------------------");
                }
                se.Close();
                Console.WriteLine(File.ReadAllText(path));
            }
        }
        //This method for readingg address book with person contact from .txt file using File IO
        public static void ReadAddressBookUsingStreamReader()
        {
            Console.WriteLine("The contact List using StreamReader method ");

            string path = @"C:\Users\Admin\source\repos\AddressBookSystem\Files\AddressBookWriterFile.txt";
            using (StreamReader se = File.OpenText(path))
            {
                string s = " ";
                while ((s = se.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }

            }
        }
        //This method for writing address book with person contact into .csv file using File IO
        public static void CsvSerialise()
        {
            try
            {
                string csvPath = @"C:\Users\Admin\source\repos\AddressBookSystem\Files\CsvFile.csv";
                var writer = File.AppendText(csvPath);


                foreach (KeyValuePair<string, List<ContactDetails>> item in addressBook)
                {
                    foreach (var items in item.Value)
                    {
                        writer.WriteLine(items.firstName + ", " + items.lastName + ", " + items.phoneNumber + ", " + items.email + ", " + items.city + ", " + items.state + ", " + items.zip + ".");

                    }
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //This method for readingg address book with person contact from .csv file using File IO
        public static void CsvDeserialise()
        {
            string csvPath = @"C:\Users\Admin\source\repos\AddressBookSystem\Files\CsvFile.csv";
            using (var reader = new StreamReader(csvPath))

            {
                string s = " ";
                while ((s = reader.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }

            }


        }

    }
}
using System;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Display welcome message 
            Console.WriteLine("Welcome to the Address Book program");
            Console.WriteLine();
            //taking input from user 
            Console.Write("Enter number of Address Book you want : ");
            int numBook = Convert.ToInt32(Console.ReadLine());
            int numberBook = 0;
            string keyPress = "o";
            while (numberBook < numBook)
            {
                //taking address book name from user
                Console.WriteLine("Enter name of adress book");
                string book = Console.ReadLine();
                Console.WriteLine("Select the below option");
                //Provideing option for user
                Console.WriteLine("1 : Add Contact Details \n2 : View Contact Details \n3 : Edit Contact Details \n4 : Delete Contact Details");
                Console.WriteLine();
                int num = Convert.ToInt32(Console.ReadLine());
                //Creating object of AddressBook class
                AddressBook obj = new AddressBook();

                while (keyPress != "n")
                {
                    //switch statement for show method as per user choose option
                    switch (num)
                    {
                        case 1:
                            obj.AddContact();
                            break;

                        case 2:
                            obj.ViewDetails();
                            break;

                        case 3:
                            obj.EditDetails();
                            break;
                        case 4:
                            obj.DeleteContact();
                            break;
                    }
                    Console.WriteLine("Do you wish to continue? Press (y/n)");
                    keyPress = Console.ReadLine();
                }
                //calling method to add new addressbook in dictionary
                AddressBook.AddTo(book);
                numberBook++;
            }
        }
    }
}
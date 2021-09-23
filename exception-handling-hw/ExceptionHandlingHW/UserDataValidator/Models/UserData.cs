using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDataValidator.Models
{
    class UserData
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ZIPCode { get; set; }
        public string Website { get; set; }

        public void Read()
        {
            Console.WriteLine("Please, provide the following information: \n");

            Console.Write("Email: ");
            Email = Console.ReadLine();

            Console.Write("Phone number: ");
            PhoneNumber = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.Write("Date of birth: ");
                    DateOfBirth = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Sorry. The value you've introduced is not a date, try again.");
                }
            }
            
            Console.Write("ZIP Code: ");
            ZIPCode = Console.ReadLine();

            Console.Write("Website: ");
            Website = Console.ReadLine();
        }
    }
}

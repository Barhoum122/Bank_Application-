using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsFindUserScreen:clsScreen
    {
        static void _PrintUser(clsUser user)
        {
            Console.WriteLine("\n User Card ");
            Console.WriteLine("-------------------");
            Console.WriteLine(" Frist Name :" + user.FirstName);
            Console.WriteLine(" Last  Name :" + user.LastName);
            Console.WriteLine(" Full  Name :" + user.FirstName + " " + user.LastName);
            Console.WriteLine(" Phone      :" + user.Phone);
            Console.WriteLine(" Email      :" + user.Email);
            Console.WriteLine(" User Name  :" + user.UserName);
            Console.WriteLine(" Permissions:" + user.Permissions);
            Console.WriteLine(" Password   :" + user.Password);
            Console.WriteLine("-------------------");
        }
        public static void _FindClient()
        {

            int count = 0;
            _DrawScreenHeader("TO Find a user");
            string UserName = "";
            while (count < 3)
            {
                if (count == 0)
                    Console.Write("\n Please Inter User Name Account Number: ");
                else Console.Write("\n Please Inter User Name  Again Not Found: ");
                UserName = clsInputValidate.ReadString();

                if (clsUser.IsUserExist(UserName))
                {

                    clsUser client = clsUser.Find(UserName);
                    _PrintUser(client);
                    break;

                }
                count++;

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(count >= 3 ? "\n<:> Sorry,you Can`t Try This Moment Try Again Later....<:>\n" : "");
            Console.ResetColor();




        }
    }
}

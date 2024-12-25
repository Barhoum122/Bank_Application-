using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    class clsDeleteUserScreen:clsScreen
    {
        static void _PrintClient(clsUser user)
        {
            Console.WriteLine("\n Client Card ");
            Console.WriteLine("-------------------");
            Console.WriteLine(" Frist Name :" + user.FirstName);
            Console.WriteLine(" Last  Name :" + user.LastName);
            Console.WriteLine(" Full  Name :" + user.FirstName + " " + user.LastName);
            Console.WriteLine(" Phone      :" + user.Phone);
            Console.WriteLine(" Email      :" + user.Email);
            Console.WriteLine(" UserName :" + user.UserName);
            Console.WriteLine(" Permissions:" + user.Permissions);
            Console.WriteLine(" Password   :" + user.Password);
            Console.WriteLine("-------------------");

        }
        public static void DeletUser()
        {
            
            _DrawScreenHeader("TO Delet a User");
            int count = 0;
            string _UserName ;
            while (count < 3)
            {
                if (count == 0)
                    Console.Write("\n Please Inter User Name  : ");
                else Console.Write("\n Please Inter User Name again becouse Not Find: ");
                _UserName = clsInputValidate.ReadString();

                if (clsUser.IsUserExist(_UserName))
                {

                    clsUser user = clsUser.Find(_UserName);
                    _PrintClient(user);
                    Console.Write("\n ---------    You Need To Delete this User choose Y - N ,Or any char? ");

                    char _char = clsInputValidate.Readchar();
                    if (_char == 'Y' || _char == 'y')
                    {
                        if (user.Delet())
                        {
                           /* user = users;*/
                            Console.WriteLine(clsUtil.Tabs(6) + "\n\n Succesfuly For Delet");
                        }
                        else Console.WriteLine("\t Not,Succesfuly For Delet");

                    }
                    else
                        Console.WriteLine(clsUtil.Tabs(6) + "\n\nThanks for dont delet this client");
                    break;

                }
                count++;

            }
            /*Console.WriteLine(us)*/
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(count >= 3 ? "\n<:> Sorry,you Can`t Try This Moment Try Again Later....<:>\n" : "");
            Console.ResetColor();



        }
    }
}

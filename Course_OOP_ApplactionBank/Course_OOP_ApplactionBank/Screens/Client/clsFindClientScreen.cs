using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsFindClientScreen:clsScreen
    {
        static void _PrintClient(clsBankClient client)
        {
            Console.WriteLine("\n Client Card ");
            Console.WriteLine("-------------------");
            Console.WriteLine(" Frist Name :" + client.FirstName);
            Console.WriteLine(" Last  Name :" + client.LastName);
            Console.WriteLine(" Full  Name :" + client.FirstName + " " + client.LastName);
            Console.WriteLine(" Phone      :" + client.Phone);
            Console.WriteLine(" Email      :" + client.Email);
            Console.WriteLine(" Acc:Namber :" + client.AccountNumber);
            Console.WriteLine(" Acc:Balance:" + client.AccountBalance);
            Console.WriteLine(" Password   :" + client.PinCode);
            Console.WriteLine("-------------------");

        }

      /*  public static  void _FindClient()
        {
           
            int count=0;
            _DrawScreenHeader("TO Find a Client");
            string _AccountNumber = "";
            Console.WriteLine("\n Please Inter Client Account Number: ");
            _AccountNumber = clsInputValidate.ReadString();
                while (!clsBankClient.IsClientExist(_AccountNumber))
                {
                if (count < 2)
                {
                    count++;
                    Console.WriteLine("\n Please Inter Client Account Number Again Not Find: ");
                    _AccountNumber = clsInputValidate.ReadString();
                }
                else
                {
                    Console.WriteLine("\n Sorry,you Can`t Try This Moment Try Again....");
                    break;
                }
            }

            if (clsBankClient.IsClientExist(_AccountNumber))
            {

                clsBankClient client = clsBankClient.Find(_AccountNumber);
                _PrintClient(client);

            }



        }*/
        public static  void _FindClient()
        {
            if (!CheckAccessRight(clsUser.enPermissions.pFindClient)) return;
            int count=0;
            _DrawScreenHeader("TO Find a Client");
            string _AccountNumber = "";
                while (count<3)
                {
                if (count == 0)
                    Console.Write("\n Please Inter Client Account Number: ");
                else Console.Write("\n Please Inter Client Account Number Again Not Find: ");
                    _AccountNumber = clsInputValidate.ReadString();

                if (clsBankClient.IsClientExist(_AccountNumber))
                {

                    clsBankClient client = clsBankClient.Find(_AccountNumber);
                    _PrintClient(client);
                    break;

                }
                count++;
              
            }
                Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(count>=3? "\n<:> Sorry,you Can`t Try This Moment Try Again Later....<:>\n" : "");
            Console.ResetColor();
           



        }
    }
}

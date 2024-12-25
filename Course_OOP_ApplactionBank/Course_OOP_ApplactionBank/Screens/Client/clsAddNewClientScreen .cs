using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsAddNewClientScreen:clsScreen 
    {

        static void _ReadClientInfo(ref clsBankClient _client)
        {
          
            Console.Write("\n  Enter New Frist Name:");
            _client.FirstName = clsInputValidate.ReadString();
            Console.Write("  Enter New Last Name :");
            _client.LastName = clsInputValidate.ReadString();
            Console.Write("  Enter New Phone     :");
            _client.Phone = clsInputValidate.ReadString();
            Console.Write("  Enter New Email     :");
            _client.Email = clsInputValidate.ReadString();
         /*   Console.Write("  Enter New Acc:Balance:");
            _client.AccountBalance = clsInputValidate.ReadFloutNumber();*/
            Console.Write("  Enter New Password   :");
            _client.PinCode = clsInputValidate.ReadString();

        }
        static void _PrintClient(clsBankClient client)
        {
            Console.WriteLine("\n Client Card ");
            Console.WriteLine("-------------------");
            Console.WriteLine(" Frist Name :" +client.FirstName);
            Console.WriteLine(" Last  Name :" + client.LastName);
            Console.WriteLine(" Full  Name :" + client.FirstName+" "+client.LastName);
            Console.WriteLine(" Phone      :" + client.Phone);
            Console.WriteLine(" Email      :" + client.Email);
            Console.WriteLine(" Acc:Namber :" + client.AccountNumber);
            Console.WriteLine(" Acc:Balance:" + client.AccountBalance);
            Console.WriteLine(" Password   :" + client.PinCode);
            Console.WriteLine("-------------------");

        }
        public static void ShowAddNewClientScreen()
        {
            if (!CheckAccessRight(clsUser.enPermissions.pAddNewClient)) return;

            _DrawScreenHeader("TO Add New Client");
            string _AccountNumber = "";
            Console.WriteLine("\n Please Inter Client Account Number : ");
            _AccountNumber = clsInputValidate.ReadString();
            while (clsBankClient.IsClientExist(_AccountNumber))
            {
                Console.WriteLine("Please Inter Client Account Number Again is Exist: ");
                _AccountNumber = clsInputValidate.ReadString();
            }
           
            clsBankClient _NewClient = clsBankClient.GetAddNewClientObject(_AccountNumber);

           _ReadClientInfo(ref _NewClient);

           clsBankClient.enSaveResulte _enSaveResulte;
            _enSaveResulte = _NewClient.Save();

            switch (_enSaveResulte)
            {
                case
                   clsBankClient.enSaveResulte.svSucceeded:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t\t(.-.) Added Client Succesfuly");
                        Console.ResetColor();
                        _PrintClient(_NewClient);


                        break;
                    }
                case clsBankClient. enSaveResulte.svFaildEmptyObject:
                    {
                        Console.WriteLine("\n\t\tAdded Client Faild,because is Empty");
                        break;
                    }
                case clsBankClient. enSaveResulte.svFaildAccountNumberIsExist:
                    {
                        Console.WriteLine("\n\t\tAdded Client Faild,because is Account Number Is Exist");
                        break;
                    }

                default:
                    break;
            }


        }
    }
}

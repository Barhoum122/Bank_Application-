using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsUpdateClientScreen: clsScreen
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
        static void _ReadClientInfo(ref clsBankClient _client)
        {
            Console.Write("\n Enter New Frist Name:");
            _client.FirstName = clsInputValidate.ReadString();
            Console.Write("  Enter New Last Name  :");
            _client.LastName = clsInputValidate.ReadString();
            Console.Write("  Enter New Phone      :");
            _client.Phone = clsInputValidate.ReadString();
            Console.Write("  Enter New Email      :");
            _client.Email = clsInputValidate.ReadString();
            Console.Write("  Enter New Acc:Balance:");
            _client.AccountBalance = clsInputValidate.ReadFloutNumber();
            Console.Write("  Enter New Password   :");
            _client.PinCode = clsInputValidate.ReadString();

        }
        public static void ShowUpdateClientScreen()
        {
            if (!CheckAccessRight(clsUser.enPermissions.pUpdateClients)) return;
            _DrawScreenHeader("TO Update a Client");
            string _AccountNumber = "";
            int count = 0;
            while (count < 3)
            {
                if (count == 0)
                    Console.Write("\n Please Inter Client Account Number: ");
                else Console.Write("\n Please Inter Client Account Number Again Not Find: ");
                _AccountNumber = clsInputValidate.ReadString();

                if (clsBankClient.IsClientExist(_AccountNumber))
                {

                    clsBankClient client = clsBankClient.Find(_AccountNumber);
                    _PrintClient(client);
                    Console.WriteLine("\n ---------Update Client Info----------");
                    _ReadClientInfo(ref client);
                    clsBankClient.enSaveResulte _enSaveResulte;
                    _enSaveResulte = client.Save();


                    switch (_enSaveResulte)
                    {
                        case
                          clsBankClient.enSaveResulte.svSucceeded:
                            {
                                Console.WriteLine(" \n Update Client Succsed");

                                break;
                            }
                        case clsBankClient.enSaveResulte.svFaildEmptyObject:
                            {
                                Console.WriteLine("Update Client Faild");
                                break;
                            }

                        default:
                            break;
                    }

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

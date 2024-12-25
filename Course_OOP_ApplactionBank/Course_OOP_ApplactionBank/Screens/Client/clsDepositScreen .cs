using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsDepositScreen:clsScreen 
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
        public static void ShowDepositScreen()
        {
            _DrawScreenHeader("TO Deposit a Client");
            int count = 0;
            string _AccountNumber = "";
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
                    float Amount = 0;
                    Console.Write("\nPlease enter deposit amount? ");
                   
                    Amount = clsInputValidate.ReadFloutNumber();
                    Console.Write("\n ---------    You Need To Deposit this Client choose Y - N ,Or any char? ");

                    char _char = 'n';
                        _char = clsInputValidate.Readchar();
                    if (_char == 'Y' || _char == 'y')
                    {
                       
                        if (client.Deposit(Amount))
                        {

                            Console.WriteLine(clsUtil.Tabs(6) + "\n Succesfuly For Deposit");
                            Console.WriteLine(clsUtil.Tabs(6) + "\n Account Balance is:"+client.AccountBalance);
                        }
                        else Console.WriteLine("\t Not,Succesfuly For Deposit");

                    }
                    else
                        Console.WriteLine(clsUtil.Tabs(6) + "\n\nOperation was cancelled");
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

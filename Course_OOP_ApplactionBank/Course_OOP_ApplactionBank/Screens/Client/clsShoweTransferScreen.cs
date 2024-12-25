using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsShoweTransferScreen:clsScreen
    {
        static void _HeaderList()
        {

            Console.WriteLine(" \t\t _______________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"\t\t |{"Full  Name",-15}" +
                $"\t\t|{"Acc:Namber",-20}" +
                $"\t\t|{"Acc:Balance",-12}");


            Console.ResetColor();
            Console.WriteLine("\n\t\t _______________________________________________________________________________");
        }
        static void _PrintClientRecordLine(clsBankClient client,ConsoleColor color=ConsoleColor.White )
        {
        
           
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\t\t |{client.FirstName,-15}" + $"\t\t|{client.AccountNumber,-20}");
            Console.ResetColor();
            Console.ForegroundColor = color;
            Console.Write($"\t\t|{client.AccountBalance,-12}\n");
            Console.ResetColor();
            Console.WriteLine("\t \t .........................................................................");


        }

        private static void Printinfo(clsBankClient client, ConsoleColor color = ConsoleColor.White)
        {
            _HeaderList();
            _PrintClientRecordLine(client,color);
            
        }

        static void _PrintClient(clsBankClient client)
        {


            Console.WriteLine("\n Client Card ");
            Console.WriteLine("-------------------");
            Console.WriteLine(" Full  Name :" + client.FirstName + " " + client.LastName);
            Console.WriteLine(" Acc:Namber :" + client.AccountNumber);
            Console.WriteLine(" Acc:Balance:" + client.AccountBalance);

            Console.WriteLine("-------------------");

        }
        static clsBankClient _GetClientAccount()
        {
            int count = 0;
            string _AccountNumber;
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
                    return client;



                }
                
                count++;
            }
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(count >= 3 ? "\n<:> Sorry,you Can`t Try This Moment Try Again Later....<:>\n" : "");
            Console.ResetColor();

            return  null!;

        }
        private static float ReadAmount(clsBankClient _SourceClient)
        {
            float Amount = 0;
            Console.Write("\nPlease enter Transfer amount? ");
            Amount = clsInputValidate.ReadFloutNumber();
            while (Amount > _SourceClient.AccountBalance)
            {
                Console.Write("\n The Amount Greter Thin Account Balance " + _SourceClient.AccountBalance + "Plesse Agian? ");
                Amount = clsInputValidate.ReadFloutNumber();

            }
           
            return Amount;
        }

        public static void ShoweTransferScreen()
        {
            _DrawScreenHeader("Transfer Screen");
            clsBankClient _SourceClient = _GetClientAccount();
            if (_SourceClient == null) return;
            clsBankClient _DistntionClient = _GetClientAccount();
            if (_DistntionClient == null) return;
            float Amount = ReadAmount(_SourceClient);
            Console.Write("\n ---------    You Need To Transfer this Client choose Y - N ,Or any char? ");

            char _char = 'n';
            _char = clsInputValidate.Readchar();
            if (_char == 'Y' || _char == 'y')
            {
                if (_SourceClient.Transfer(Amount,  ref _DistntionClient,clsGlobalUser.Public_User.UserName))
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(clsUtil.Tabs(8) + "\n\n\nSuccesfuly For Transfer");
                    Printinfo(_SourceClient,ConsoleColor.Red);
                    Printinfo(_DistntionClient,ConsoleColor.Green);
                    Console.ResetColor();
                   
                  
                }
                else
                {
                     
                        Console.WriteLine(clsUtil.Tabs(6) + "\n\nTransfer is Faild");
                }
            }
            else
                Console.WriteLine(clsUtil.Tabs(6) + "\n\nOperation was cancelled");

        }
    }
}

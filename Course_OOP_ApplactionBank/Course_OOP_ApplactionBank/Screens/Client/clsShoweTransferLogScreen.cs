using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsShoweTransferLogScreen:clsScreen
    {


        static void _HeaderList()
        {

            Console.WriteLine(" ___________________________________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"|{"Data Time",-25}" +
                $"|{"S.Acc",-10}" + 
                $"|{"D.Acc",-10}" +
                $"|{"Amount",-10}" +
                $"|{"S.Balance(-)",-13}" +
                $"|{"D.Balance(+)",-13}" +
                $"|{"User Name",-10}");


            Console.ResetColor();
            Console.WriteLine("\n ___________________________________________________________________________________________________");
        }
        static void _PrintClientRecordLine(clsBankClient.stTransferLogData TransferLogData, ConsoleColor color = ConsoleColor.White)
        {
            

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"|{TransferLogData._DataTime,-25}" +
                $"|{TransferLogData.From,-10}" +
                $"|{TransferLogData.To,-10}" +
                $"|{TransferLogData.Amount,-10}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"|{TransferLogData.SourceBalunce,-13}");

            Console.ResetColor();
            Console.ForegroundColor = color;
            Console.Write($"|{TransferLogData.DistnationBalunce,-13}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"|{TransferLogData._UserName,-10}\n");
            Console.WriteLine("\n ......................................................................................");


        }

        private static void Printinfo(clsBankClient.stTransferLogData TransferLogData, ConsoleColor color = ConsoleColor.White)
        {
           
            _PrintClientRecordLine(TransferLogData, color);

        }
        public static void ShoweTransferLogScreen()
        {

            List<clsBankClient.stTransferLogData> TransferLogData = clsBankClient._GetTransferLogData();
           
            string Title = "Transfer LogScreen";

            _DrawScreenHeader(Title, " ");
           
            _HeaderList();
            if (TransferLogData.Count != 0)
            {
                foreach (clsBankClient.stTransferLogData _User in TransferLogData)
                {
                    Printinfo(_User,ConsoleColor.Green);
                }
            }
            else
                Console.WriteLine("\n\n\n " + clsUtil.Tabs(6) + "NO Users Register Data Loading");
            Console.WriteLine("<:_____________________________________________________________________________________________________________:>");
            /*  _footerList();
  */

        }
    }
    }


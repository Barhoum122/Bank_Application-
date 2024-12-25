using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsTransactionsScreen : clsScreen
    {
        enum enTransactionsMenueOptions
        {
            eDeposit = 1, eWithdraw = 2,
            eShowTotalBalance = 3,eShowTransfer = 4,eShowTransferLog = 5, eShowMainMenue = 6
        };
        static short ReadTransactionsMenueOption()
        {
            Console.Write(clsUtil.Tabs(6) + "Choose what do you want to do?[1 to 6] ? ");
            short Choice = clsInputValidate.ReadShortNumberBetween(1, 6, clsUtil.Tabs(6) + "Enter Number between 1 to 6? ");
            return Choice;
        }
        static void _ShowDepositScreen()
        {
            Console.Clear();
            clsDepositScreen.ShowDepositScreen();
            _GoBackToTransactionsMenue();
        }
        static void _ShowWithdrawScreen()
        {
            Console.Clear();
            clsWithdrawScreen.ShowWithdrawScreen();
            _GoBackToTransactionsMenue();
        }
        static void _ShowTotalBalancesScreen()
        {
            Console.Clear();
          clsShowTotalBalancesScreen.ShowTotalBalancesScreen();
            _GoBackToTransactionsMenue();
        }
        static void _ShoweTransferScreen()
        {
            Console.Clear();
          clsShoweTransferScreen.ShoweTransferScreen();
            _GoBackToTransactionsMenue();
        } static void _ShoweTransferLogScreen()
        {
            Console.Clear();
          clsShoweTransferLogScreen.ShoweTransferLogScreen();
            _GoBackToTransactionsMenue();
        }
        static void _GoBackToTransactionsMenue()
        {
            Console.ReadKey();
            Console.Clear();
            ShowTransactionsMenue();
        }

        static void _PerformTransactionsMenueOption(enTransactionsMenueOptions enTransactionsMenue)
        {
            switch (enTransactionsMenue)
            {
                case enTransactionsMenueOptions.eDeposit:
                    {
                        _ShowDepositScreen();
                        _GoBackToTransactionsMenue();
                        break;
                    }
                case enTransactionsMenueOptions.eWithdraw:
                    {
                       
                        _ShowWithdrawScreen();
                        _GoBackToTransactionsMenue();
                        break;
                    }

                case enTransactionsMenueOptions.eShowTotalBalance:
                    {
                        
                        _ShowTotalBalancesScreen();
                        _GoBackToTransactionsMenue();
                        break;
                    }
                  case enTransactionsMenueOptions.eShowTransfer:
                    {

                        _ShoweTransferScreen();
                        _GoBackToTransactionsMenue();
                        break;
                    } 
                case enTransactionsMenueOptions.eShowTransferLog:
                    {

                        _ShoweTransferLogScreen();
                        _GoBackToTransactionsMenue();
                        break;
                    }
                case enTransactionsMenueOptions.eShowMainMenue:
                    {
                        //do nothing here the main screen will handle it :-) ;
                        /*Console.Clear();*/
                     
                        
                        break;
                    }
            }
        }


        public static void ShowTransactionsMenue()
        {
            if (!CheckAccessRight(clsUser.enPermissions.pTranactions)) return;
            _DrawScreenHeader(" Transactions Screen");
            Console.WriteLine(clsUtil.Tabs(6) + " ===========================================");
            Console.WriteLine(clsUtil.Tabs(8) + " Transactions Menue\n");
            Console.WriteLine(clsUtil.Tabs(6) + " [1] Deposit..");
            Console.WriteLine(clsUtil.Tabs(6) + " [2] Withdraw..");
            Console.WriteLine(clsUtil.Tabs(6) + " [3] Total Balances.");
            Console.WriteLine(clsUtil.Tabs(6) + " [4] Transfer.");
            Console.WriteLine(clsUtil.Tabs(6) + " [5] TransferLog.");
            Console.WriteLine(clsUtil.Tabs(6) + " [6] Main Menue.");
            Console.WriteLine(clsUtil.Tabs(6) + " ===========================================");

            _PerformTransactionsMenueOption((enTransactionsMenueOptions)ReadTransactionsMenueOption());
            
        }

    }
}

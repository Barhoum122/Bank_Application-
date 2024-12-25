using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Course__OOP_Level_2_Applaction
{
     class clsMainScreen: clsScreen
    {
       


        //Privet function.
        enum enMainMenueOptions
        {
            eListClients = 1, eAddNewClient = 2, eDeleteClient = 3,
            eUpdateClient = 4, eFindClient = 5, eShowTransactionsMenue = 6,
            eManageUsers = 7, eRegister = 8,eCurrncyMenue = 9,eExit = 10
        };
        static short _ReadMainMenueOption()
        {
            Console.Write(clsUtil.Tabs(6) + "Choose what do you want to do?[1 to 8] ? ");
            short Choice = clsInputValidate.ReadShortNumberBetween(1, 10, clsUtil.Tabs(6) + "Enter Number between 1 to 10? ");
            return Choice;
        }
        static void _GoBackToMainMenue()
        {
           
            Console.ReadKey();
            Console.Clear();
            
            ShowMainMenue();
           
        }
        static void _ShowAllClientsScreen()
        {
     
           clsClientListScreen.ShowClientsList();
            Console.WriteLine(clsUtil.Tabs(6) + "Choose Any charcters to Exits ? ");
        }
        static void _ShowAddNewClientsScreen()
        {
           
            clsAddNewClientScreen.ShowAddNewClientScreen();
            Console.WriteLine(clsUtil.Tabs(6) + "Choose Any charcters to Exits ? ");
        }
        static void _ShowDeleteClientScreen()
        {

            clsDeleteClientScreen.DeletClient();
            Console.WriteLine(clsUtil.Tabs(6) + "Choose Any charcters to Exits ? ");
        }
        static void _ShowUpdateClientScreen()
        {
            clsUpdateClientScreen.ShowUpdateClientScreen();
            Console.WriteLine(clsUtil.Tabs(6) + "Choose Any charcters to Exits ? ");
        }
        static void _ShowFindClientScreen()
        {
            clsFindClientScreen._FindClient();
          /*  Console.Clear();*/
          
            Console.WriteLine(clsUtil.Tabs(6) + "Choose Any charcters to Exits ? ");
        }
        static void _ShowTransactionsMenue()
        {
            clsTransactionsScreen.ShowTransactionsMenue();
           /* Console.WriteLine(clsUtil.Tabs(6) + "Choose what do you want to do?[1 to 8] ? ");*/
        }
        static void _ShowManageUsersMenue()
        {
            clsManageUsersScreen.ShowManageUsersMenue();

        } 
        static void _ShoweRegisterUsersScreen()
        {
            clsRegisterUsersScreen.ShowListRegisterUsersScreen();

        }  static void _ShowCurrncyMenueScreen()
        {
            clsCurrencyMainScreen.ShowCurrencyMainScreen();

        }
        static void Logout()
        {
           

            clsUser NullUser= clsUser._GetEmptyUserObject();

            clsGlobalUser.Public_User= NullUser;
           /* Console.Clear();*/


        }
        static void _PerfromMainMenueOption(enMainMenueOptions MainMenueOption)
        {
            switch (MainMenueOption)
            {
                
                   
                case enMainMenueOptions.eListClients:
                    {
                        Console.Clear();
                        _ShowAllClientsScreen();
                        _GoBackToMainMenue();
                        break;
                    }
                case enMainMenueOptions.eAddNewClient:
                    Console.Clear();
                    _ShowAddNewClientsScreen();
                    _GoBackToMainMenue();
                    break;

                case enMainMenueOptions.eDeleteClient:
                    Console.Clear();
                    _ShowDeleteClientScreen();
                    _GoBackToMainMenue();    
                    break;

                case enMainMenueOptions.eUpdateClient:
                    Console.Clear();
                    _ShowUpdateClientScreen();
                    _GoBackToMainMenue();
                    break;

                case enMainMenueOptions.eFindClient:
                    Console.Clear();
                    _ShowFindClientScreen();
                    _GoBackToMainMenue();
                    break;

                case enMainMenueOptions.eShowTransactionsMenue:
                    Console.Clear();
                    _ShowTransactionsMenue();
                    _GoBackToMainMenue();
                    break;

                case enMainMenueOptions.eManageUsers:
                    Console.Clear();
                    _ShowManageUsersMenue();
                    _GoBackToMainMenue();
                    break;

                case enMainMenueOptions.eRegister:
                    Console.Clear();
                    _ShoweRegisterUsersScreen();
                    _GoBackToMainMenue();
                    break;
                case enMainMenueOptions.eCurrncyMenue:
                    Console.Clear();
                    _ShowCurrncyMenueScreen();
                    _GoBackToMainMenue();
                    break;
                case enMainMenueOptions.eExit:
                    Console.Clear();
                    Logout();
                    break;

            }


        }
        //Public Finction.
        public static void ShowMainMenue()
        {
           /* string UserName = "\tUser Name:"+clsGlobalUser.Public_User.UserName;
            string fristName = "Welcom Mr:" + clsGlobalUser.Public_User.FirstName;*/
            Console.WriteLine();
            _DrawScreenHeader("Main Screen"," " );
            Console.WriteLine(clsUtil.Tabs(6)+" ===========================================");
            Console.WriteLine(clsUtil.Tabs(8)+ " Main Menue\n");
            Console.WriteLine(clsUtil.Tabs(6)+ " [1] Show Client List.");
            Console.WriteLine(clsUtil.Tabs(6)+ " [2] Add New Client.");
            Console.WriteLine(clsUtil.Tabs(6)+ " [3] Delete Client.");
            Console.WriteLine(clsUtil.Tabs(6)+ " [4] Update Client Info.");
            Console.WriteLine(clsUtil.Tabs(6)+ " [5] Find Client.");
            Console.WriteLine(clsUtil.Tabs(6)+ " [6] Transactions.");
            Console.WriteLine(clsUtil.Tabs(6)+ " [7] Manage Users.");
            Console.WriteLine(clsUtil.Tabs(6)+ " [8] Login Regester.");
            Console.WriteLine(clsUtil.Tabs(6)+ " [9] Currency Calac.");
            Console.WriteLine(clsUtil.Tabs(6)+ " [10] Logout.\n");
            Console.WriteLine(clsUtil.Tabs(6)+" ===========================================");
            _PerfromMainMenueOption((enMainMenueOptions)_ReadMainMenueOption());
        }

    }
}

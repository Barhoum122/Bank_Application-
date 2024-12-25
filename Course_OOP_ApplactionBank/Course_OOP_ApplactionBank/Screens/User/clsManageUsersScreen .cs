using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsManageUsersScreen:clsScreen
    {
        enum enManageUsersMenueOptions
        {
            eListUsers = 1, eAddNewUser = 2, eDeleteUser = 3,
            eUpdateUser = 4, eFindUser = 5, eMainMenue = 6
        };
        static short ReadManageUsersMenueOption()
        {
            Console.Write(clsUtil.Tabs(6) + "Choose what do you want to do?[1 to 6] ? ");
            short Choice = clsInputValidate.ReadShortNumberBetween(1, 6, clsUtil.Tabs(6) + "Enter Number between 1 to 6? ");
            return Choice;
        }
        static void _GoBackToManageUsersMenue()
        {
            Console.ReadKey();
            Console.Clear();
            ShowManageUsersMenue();
        }
        static void _ShowListUsersScreen()
        {
            Console.Clear();
           clsShowListUsersScreen.ShowListUsersScreen();
            Console.Write(clsUtil.Tabs(6) + "Choose what do you want to do?[1 to 6] ? ");
        }
        
        static void _ShowAddNewUserScreen()
        {
            Console.Clear();
            clsAddNewUserScreen.ShowAddNewUserScreen();
            Console.Write(clsUtil.Tabs(6) + "Choose what do you want to Exit ? ");
        }
        static void _ShowDeleteUserScreen()
        {
                 Console.Clear();
            clsDeleteUserScreen.DeletUser();
            Console.Write(clsUtil.Tabs(6) + "Prees Any Key to Exit ? ");

        }
        static void _ShowUpdateUserScreen()
        {
            Console.Clear();
            clsUpdateUserScreen.ShowUpdateUsertScreen();
            Console.Write(clsUtil.Tabs(6) + "Prees Any Key to Exit ? ");
        }
        static void _ShowFindUserScreen()
        {
            Console.Clear();
            clsFindUserScreen._FindClient();
            Console.Write(clsUtil.Tabs(6) + "Prees Any Key to Exit ? ");
        }

        static void _PerformManageUsersMenueOption(enManageUsersMenueOptions ManageUsersMenueOption)
        {

            switch (ManageUsersMenueOption)
            {
                case enManageUsersMenueOptions.eListUsers:
                    {
                        Console.Clear();
                        _ShowListUsersScreen();
                        _GoBackToManageUsersMenue();
                        break;
                    }

                case enManageUsersMenueOptions.eAddNewUser:
                    {
                        
                        _ShowAddNewUserScreen();
                        _GoBackToManageUsersMenue();
                        break;
                    }

                case enManageUsersMenueOptions.eDeleteUser:
                    {
                       
                        _ShowDeleteUserScreen();
                        _GoBackToManageUsersMenue();
                        break;
                    }

                case enManageUsersMenueOptions.eUpdateUser:
                    {
                       
                        _ShowUpdateUserScreen();
                        _GoBackToManageUsersMenue();
                        break;
                    }

                case enManageUsersMenueOptions.eFindUser:
                    {
                      

                        _ShowFindUserScreen();
                        _GoBackToManageUsersMenue();
                        break;
                    }

                case enManageUsersMenueOptions.eMainMenue:
                    {
                        //do nothing here the main screen will handle it :-) ;
                      /*  Console.Clear();
                        clsMainScreen.ShowMainMenue();*/
                        break;
                    }
            }



        }

        //public Function

      public  static void ShowManageUsersMenue()
        {

            if (!CheckAccessRight(clsUser.enPermissions.pManageUsers)) return;
            _DrawScreenHeader("\t Manage Users Screen");
            
            Console.WriteLine(clsUtil.Tabs(6) + " ===========================================");
            Console.WriteLine(clsUtil.Tabs(8) + " Manage Users Menue.\n");
            Console.WriteLine(clsUtil.Tabs(6) + " [1] List Users.");
            Console.WriteLine(clsUtil.Tabs(6) + " [2] Add New User.");
            Console.WriteLine(clsUtil.Tabs(6) + " [3] Delete User.");
            Console.WriteLine(clsUtil.Tabs(6) + " [4] Update User.");
            Console.WriteLine(clsUtil.Tabs(6) + " [5] Find User.");
            Console.WriteLine(clsUtil.Tabs(6) + " [6] Main Menue.");
            Console.WriteLine(clsUtil.Tabs(6) + " ===========================================");

            _PerformManageUsersMenueOption((enManageUsersMenueOptions)ReadManageUsersMenueOption());





        }













    }


}
    

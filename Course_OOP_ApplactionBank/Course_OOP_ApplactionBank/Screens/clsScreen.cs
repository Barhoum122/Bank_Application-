using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
      class clsScreen: InterfaceCommunication
    {
        public override void SendEmail()
        {
            Console.Write("\n Hi Am Derived Class");
        }
        public override void SendSMS()
        {
            Console.Write("\n Hi Am Derived Class");
        }

        public override void SendFax()
        {
            throw new NotImplementedException();
        }
        public new void SendSMS_() {
            Console.Write("\n Hi Am Derived Send SMS ");
        }

       

        protected static void _DrawScreenHeader(string Title, string SubTitle = "")
        {
            string UserName = "\tUser Name:" + clsGlobalUser.Public_User.UserName;
            string fristName = "Welcom Mr:" + clsGlobalUser.Public_User.FirstName;
            DateTime dateTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(clsUtil.Tabs(1) + "   _____________________________________________________________________________________________________________\n");
            Console.WriteLine("  " + clsUtil.Tabs(7)+ Title +"\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(clsUtil.Tabs(1) + clsUtil.Tabs(6) + "   " + dateTime + clsUtil.Tabs(5) + "");
            Console.ResetColor();
            if (SubTitle != "")
            {
               
                 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(clsUtil.Tabs(2) + UserName + clsUtil.Tabs(4) + clsUtil.Tabs(5) + "" + fristName);
                Console.ResetColor();
                Console.WriteLine(  clsUtil.Tabs(2) + SubTitle );
                Console.ResetColor();

            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(clsUtil.Tabs(1) + "   _____________________________________________________________________________________________________________\n");
            Console.ResetColor();
        }
      public  static bool CheckAccessRight(clsUser.enPermissions _enPermissions)
        {
            if (!clsGlobalUser.Public_User.CheckAccessPermistion(_enPermissions))
            {
                Console.WriteLine("\t\t\t------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t   Access Denied Contect Your Accounts Admin");
                Console.WriteLine("\n\t\t\t------------------------------------------------------------");
                return false;
            }
            else return true;
        }

       
    }
}

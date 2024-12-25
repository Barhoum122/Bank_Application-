using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsGlobalUser
    {
        static clsUser _Public_User= clsUser.Find("","");
        public static clsUser Public_User
        {
            get { return _Public_User; }
            set { _Public_User = value; }
        }
     

    }
}

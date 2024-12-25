using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
   public abstract class InterfaceCommunication
    {
        public abstract  void SendEmail(/*string Title, string Body*/);
        public abstract  void SendSMS(/*string Title, string Body*/);
        public abstract  void SendFax(/*string Title, string Body*/);
        public virtual  void SendSMS_(/*string Title, string Body*/)
        {
            Console.WriteLine("kdd");
        }
       
      
    }
}

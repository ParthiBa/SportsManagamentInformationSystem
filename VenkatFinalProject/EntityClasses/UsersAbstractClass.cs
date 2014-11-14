using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenkatFinalProject.EntityClasses
{
    public abstract class UsersAbstractClass
    {
       protected ProcessBookingInterface m_processbooking;
       protected UsersAbstractClass(ProcessBookingInterface bookwhat)
       {
           this.m_processbooking = bookwhat;
       }
       public abstract void Book(String fid, String mid, DateTime date,int colcount, FormClass.CancelConfirmFormInterface handle);
       public abstract void Cancel(String fid, String mid, DateTime date,int colcount,FormClass.CancelConfirmFormInterface handle);	
    }
}

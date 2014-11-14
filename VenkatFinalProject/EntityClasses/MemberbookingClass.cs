using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenkatFinalProject.EntityClasses
{
    class MemberbookingClass : UsersAbstractClass
    {
        public MemberbookingClass(EntityClasses.ProcessBookingInterface FacilityBooking)
            : base(FacilityBooking)
        {
            //todo:
            //just pass which facility(gym,swimming pool,court) to be booked
        }
        public override void Book(String fid, String mid, DateTime date,int colcount,FormClass.CancelConfirmFormInterface handle)
        {
            m_processbooking.SetColCount(colcount);
            m_processbooking.SetDate(date);
            m_processbooking.SetBookedBy(mid);
            m_processbooking.SetFacilityID(fid);
            m_processbooking.SaveDB(handle);
        }
        public override void Cancel(String fid, String mid, DateTime date,int colcount,FormClass.CancelConfirmFormInterface handle)
        {
            m_processbooking.SetColCount(colcount);
            m_processbooking.SetDate(date);
            m_processbooking.SetBookedBy(mid);
            m_processbooking.SetFacilityID(fid);
            m_processbooking.ClearDB(handle);
        }
    }
}

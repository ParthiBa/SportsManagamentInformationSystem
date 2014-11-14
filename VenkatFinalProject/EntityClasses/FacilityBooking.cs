using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenkatFinalProject.FormClass;

namespace VenkatFinalProject.EntityClasses
{
    public class FacilityBooking : ProcessBookingInterface
    {
        DateTime m_date;
        String m_mid;
        String m_fid;
        int m_colcount;
        public int GetColCount()
        {
            return m_colcount;  
        }
        public void SetColCount(int colcount)
        {
            m_colcount = colcount;
        }
        public void SetDate(DateTime date)
        {
            m_date = date;
        }
        public DateTime GetDate()
        {
            return m_date;
        }
        public void SetBookedBy(String member)
        {
            m_mid = member;
        }
        public String GetBookedBy()
        {
            return m_mid;
        }
        public void SetFacilityID(String fid)
        {
            m_fid = fid;
        }
        public String GetFacilityID()
        {
            return m_fid;
        }
        public void SaveDB(FormClass.CancelConfirmFormInterface handle)
        {
            EDM.EDMHandler.GetInstance().SetParameters(GetFacilityID(), GetBookedBy(), GetDate(),GetColCount());
            EDM.EDMHandler.GetInstance().SetAction("BookFacility");
            EDM.EDMHandler.GetInstance().ExecuteQuery(new FormClass.ConfirmBookingClass.ConfirmBookingListener(new FormClass.ConfirmBookingClass()));
        }
        public void ClearDB(FormClass.CancelConfirmFormInterface handle)
        {
            EDM.EDMHandler.GetInstance().SetParameters(GetFacilityID(), GetBookedBy(), GetDate(), GetColCount());
            EDM.EDMHandler.GetInstance().SetAction("CancelBooking");
            EDM.EDMHandler.GetInstance().ExecuteQuery(new FormClass.CancelBookingClass.CancelBookingListener(new FormClass.CancelBookingClass()));
        }
    }
}

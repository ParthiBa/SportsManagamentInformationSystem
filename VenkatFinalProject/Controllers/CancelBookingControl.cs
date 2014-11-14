using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity.Infrastructure;

namespace VenkatFinalProject.Controllers
{
    public class CancelBookingControl : EDM.Command<bool>
    {
        static String m_mid;
        static String m_fid;
        static DateTime m_date;
        static int m_colcount;
        private SportsFacilityEntities5aaaaaaa ex;
        static AllentityBroker erb = new AllentityBroker();
        String[] Slots = { "", "", " 9 To 10", " 10 To 11", " 11 To 12", " 12 To 13", " 13 To 14"
                         ," 14 To 15"," 15 To 16"," 16 To 17"," 17 To 18"};

        public CancelBookingControl(DateTime date, String mid,String fid, int colcount)
        {
            m_date = date;
            m_fid = fid;
            m_mid = mid;
            m_colcount = colcount;
            ex = EDM.EDMHandler.GetContext();
        }
        public void SetParameters(String fid, int colcount)
        {
            m_fid = fid;
            m_colcount = colcount;
        }
        public bool execute()
        {
            //var q = from x in ex.BookingDetails
            //        where x.Member.MemberID == m_mid && DateTime.Compare(x.DateofBooking, m_date) == 0
            //        select x;
            string coll = Slots[m_colcount];
            var q = ex.BookingDetails.Where(x => x.Member.MemberID == m_mid & x.DateofBooking == m_date
                && x.Slot == coll && x.FID == m_fid);

            BookingDetail d = q.FirstOrDefault<BookingDetail>();
            using (TransactionScope ts = new TransactionScope())
            {
                erb.updateAvailability(m_fid, m_date.DayOfWeek, m_colcount + 7);
            //((IObjectContextAdapter)ex).ObjectContext.DeleteObject(q.FirstOrDefault<BookingDetail>());
                ex.BookingDetails.Remove(d);
                ts.Complete();
            }
            return true;
        }
    }
}

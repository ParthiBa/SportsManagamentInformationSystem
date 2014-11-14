using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace VenkatFinalProject.Controllers
{
    public class BookingFormControl : EDM.Command<bool>
    {
        static String m_mid;
        static String m_fid;
        static int m_columncount;
        DateTime m_date;
        String[] Slots = { "", "", " 9 To 10", " 10 To 11", " 11 To 12", " 12 To 13", " 13 To 14"
                         ," 14 To 15"," 15 To 16"," 16 To 17"," 17 To 18"};
        static AllentityBroker erb = new AllentityBroker();
        public BookingFormControl(DateTime date,String mid, String fid, int colcount)
        {
            m_date = date;
            m_fid = fid;
            m_mid = mid;
            m_columncount = colcount;
        }
        public void SetParameters(String fid, int colcount)
        {
            m_fid = fid;
            m_columncount = colcount;
        }
        public bool execute()
        {
            if (m_fid == "false")
                return false;
            BookingDetail bd = new BookingDetail();
                 int Memberid;
            var qr=from q in EDM.EDMHandler.GetContext().BookingDetails
                     orderby q.BookingID descending
                     select q;
          
            if (qr.FirstOrDefault<BookingDetail>() == null)
            { Memberid = 1; }
            else
            {   BookingDetail lastmember =qr.First<BookingDetail>();
                
                Memberid = (lastmember.BookingID) + 1; }
            
            bd.BookingID = (Memberid);
            bd.FID = m_fid;
            bd.MemberID = m_mid;
            bd.DateofBooking = m_date.Date;
            bd.Slot = Slots[m_columncount];

            erb.updateAvailability(m_fid, m_date.DayOfWeek, m_columncount + 7);
            
            using (TransactionScope ts = new TransactionScope())
            {
                var s = from x in EDM.EDMHandler.GetContext().BookingDetails
                        where x.MemberID == m_mid && x.FID == m_fid && x.DateofBooking == m_date
                        select x;
                int xa = s.Count<BookingDetail>();
                if (xa == 0)
                {
                    EDM.EDMHandler.GetContext().BookingDetails.Add(bd);
                }
                else
                {
                    BookingDetail temp = s.First<BookingDetail>();
                    temp.Slot = Slots[m_columncount]; 
                }
                ts.Complete();
            }
            return true;
        }
    }
}

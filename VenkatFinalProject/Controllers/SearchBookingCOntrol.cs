using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace VenkatFinalProject.Controllers
{
    class SearchBookingControl
    {
        static AllentityBroker erb = new AllentityBroker();
        static String m_tosearch;
        static DateTime m_date;
        public SearchBookingControl(String fname,DateTime date)
        {
            m_tosearch = fname;
            m_date = date;
        }
        public class Book : EDM.Command<ArrayList>
        {
            public Book(String fid, DateTime date)
            {
                m_tosearch = fid;
                m_date = date;
            }
            public ArrayList execute()
            {
                return erb.searchBoooking(m_tosearch, m_date.DayOfWeek);
            }
        }

        public class CancelBooking : EDM.Command<List<BookingDetail>>
        {
            public CancelBooking(String mid, DateTime date)
            {
                m_tosearch = mid;
                m_date = date;
            }
            public List<BookingDetail> execute()
            {
                List<BookingDetail> list = erb.searchbyMemberID(m_tosearch,m_date.Date);
                return list;
            }
        }

      
    }
}

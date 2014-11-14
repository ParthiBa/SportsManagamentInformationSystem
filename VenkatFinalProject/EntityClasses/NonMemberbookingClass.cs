using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenkatFinalProject.EntityClasses
{
    public class NonMemberbookingClass : UsersAbstractClass
    {
        public NonMemberbookingClass(EntityClasses.ProcessBookingInterface facility)
            :base(facility)
        {
            //todo:
            //just pass which facility to be booked
        }
        private UsersAbstractClass m_someOneWhoKnow;

        internal UsersAbstractClass SomeOneWhoKnow
        {
            get { return m_someOneWhoKnow; }
            set { m_someOneWhoKnow = value; }
        }
        public override void Book(String fid, String mid, DateTime date, Form handle)
        {
            m_processbooking.SetDate(date);
            m_processbooking.SetBookedBy(mid);
            m_processbooking.SetFacilityID(fid);
            m_processbooking.UpdateDB(handle);
        }
        public override void Cancel()
        {
            m_processbooking.Cancel();
        }
    }
}

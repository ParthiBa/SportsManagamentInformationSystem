using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenkatFinalProject.EntityClasses
{
    public class NonMemberClass : UsersAbstractClass
    {
        private String m_name;

        public NonMemberClass(EntityClasses.ProcessBookingInterface facility)
            :base(facility)
        {
            //todo:
            //just pass which facility to be booked
        }
        public String Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
        private String m_mobileNumber;

        public String MobileNumber
        {
            get { return m_mobileNumber; }
            set { m_mobileNumber = value; }
        }
        private UsersAbstractClass m_someOneWhoKnow;

        internal UsersAbstractClass SomeOneWhoKnow
        {
            get { return m_someOneWhoKnow; }
            set { m_someOneWhoKnow = value; }
        }
        public override void Book()
        {
            m_processbooking.SetDate();
            m_processbooking.SetBookedBy();
        }
        public override void Cancel()
        {
            m_processbooking.Cancel();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenkatFinalProject.EntityClasses
{
    class MemberClass : UsersAbstractClass
    {
        private String m_emailID;
        public MemberClass(EntityClasses.ProcessBookingInterface facility)
            :base(facility)
        {
            //todo:
            //just pass which facility to be booked
        }

        public String EmailID
        {
            get { return m_emailID; }
            set { m_emailID = value; }
        }
        private String m_matrixNumber;

        public String MatrixNumber
        {
            get { return m_matrixNumber; }
            set { m_matrixNumber = value; }
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

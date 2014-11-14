using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VenkatFinalProject.EntityClasses
{
    public interface ProcessBookingInterface
    {
        void SetColCount(int colcount);
        void SetDate(DateTime date);
        void SetBookedBy(String member);
        void SetFacilityID(String fid);
        void SaveDB(FormClass.CancelConfirmFormInterface handle);
        void ClearDB(FormClass.CancelConfirmFormInterface handle);
    }
}

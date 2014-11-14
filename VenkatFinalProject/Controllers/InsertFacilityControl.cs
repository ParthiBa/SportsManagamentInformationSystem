using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace VenkatFinalProject.Controllers
{
    public class InsertFacilityControl : EDM.Command<bool>
    {
        private String m_fid;
        private String m_fname;
        bool m_todelete;
        String m_desc;
        private SportsFacilityEntities5aaaaaaa ex;
        public InsertFacilityControl(String fid, String fname,bool todelete,String desc)
        {
         m_fid = fid;
         m_fname = fname;
         m_todelete = todelete;
         m_desc = desc;
         ex = EDM.EDMHandler.GetContext();
        }
        public bool execute()
        {
            var q = from x in ex.Facilities
                    where x.FacilityID == m_fid
                    select x;
            if (m_todelete)
            {
                ((IObjectContextAdapter)ex).ObjectContext.DeleteObject(q.FirstOrDefault<Facility>());
            }
            else
            {
                int xa = q.Count<Facility>();
                if (xa == 0)
                {
                    Facility fc = new Facility();
                    fc.FacilityID = m_fid;
                    fc.FacilityType = m_fname;
                    fc.FacilityDescription = m_desc;
                    EDM.EDMHandler.GetContext().Facilities.Add(fc);
                }
                else
                {
                    Facility temp = q.First<Facility>();
                    temp.FacilityType = m_fname;
                    temp.FacilityDescription = m_desc;
                }
            }
            
            return true;
        }
    }
}

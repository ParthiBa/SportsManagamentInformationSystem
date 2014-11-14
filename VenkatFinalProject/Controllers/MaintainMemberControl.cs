using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Entity.Infrastructure;

namespace VenkatFinalProject.Controllers
{
    public class MaintainMemberControl
    {
      SportsFacilityEntities5aaaaaaa sfentityframe;
        public MaintainMemberControl()
        {
            sfentityframe = EDM.EDMHandler.GetContext();
        }



        public bool CreateMember(string name, string number, string address)
        {

            Member m = new Member();
            Member lastmember = (from q in sfentityframe.Members
                                 orderby q.MemberID descending
                                 select q).First<Member>();
            int Memberid = Convert.ToInt32(lastmember.MemberID.Substring(1)) + 1;
            string newMemberid = "a" + Memberid.ToString("D3");
            m.MemberID = newMemberid;
            m.MemberName = name;
            m.phoneNumber = number;
            m.address = address;

            using (System.Transactions.TransactionScope ts = new System.Transactions.TransactionScope())
            {
                sfentityframe.Members.Add(m);
                sfentityframe.SaveChanges();
                ts.Complete();
                return true;
            }

        }
        public bool Update(string id, string name, string number, string address)
        {

            try
            {
                Member m = (from x in sfentityframe.Members
                            where x.MemberID == id
                            select x).FirstOrDefault<Member>();
                m.MemberName = name;
                m.phoneNumber = number;
                m.address = address;
                ((IObjectContextAdapter)sfentityframe).ObjectContext.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("try new id.");
                return false;
            }
        }
        public bool Delete(string id)
        {

            Member m = (from x in sfentityframe.Members
                        where x.MemberID == id
                        select x).FirstOrDefault<Member>();
            ((IObjectContextAdapter)sfentityframe).ObjectContext.DeleteObject(m);

            ((IObjectContextAdapter)sfentityframe).ObjectContext.SaveChanges();
            return true;
        }
        public Member find(string memberid)
        {


            Member m = sfentityframe.Members.First(x => x.MemberID == memberid);
            return m;
        }

        public MaintainMemberControl getreference()
        {
            return this;
        }


        public void createWindow(MaintainMemberControl mbc)
        {
            FormClass.CreateMemberWindow dr = new FormClass.CreateMemberWindow(mbc);
            dr.Show();
        }

        public void updateorDeleteWindow(MaintainMemberControl mbc, bool isupdate)
        {

            FormClass.updateOrDeleteMember f = new FormClass.updateOrDeleteMember(mbc,isupdate);
            f.Show();
        }
    }
}

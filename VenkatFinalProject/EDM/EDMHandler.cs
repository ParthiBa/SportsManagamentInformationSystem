using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Collections;

namespace VenkatFinalProject.EDM
{
    public class EDMHandler
    {
        static String m_mname;
        static String m_mid;
        static String m_fid;
        static String m_fname;
        static DateTime m_date;
        static String m_phoneNumber;
        static int m_colcount;
        static String m_desc;

        static String m_action;
        static EDMHandler m_HandlerSingleTon = null;
        static public SportsFacilityEntities5aaaaaaa m_context = GetContext();
       
        public void SetAction(String Action)
        {
            m_action = Action;
        }
        public void SetParameters(String mname, String mid,String phoneNumber,String address)//create member
        {
            m_mname = mname;
            m_mid = mid;
            m_phoneNumber = phoneNumber;
        }
        public void SetParameters(String fname, String mid,DateTime date)//Search
        {
            m_fname = fname;
            m_date = date;
            m_mid = mid;
        }
        public void SetParameters(String fid,String mid, DateTime date,int colcount)//book/cancel facility
        {
            m_fid = fid;
            m_date = date;
            m_mid = mid;
            m_colcount = colcount;
        }
        public void SetParameters(String fname, String fid,String desc)//create facility
        {
            m_fname = fname;
            m_fid = fid;
            m_desc = desc;
        }
        private EDMHandler()
        {
        }
        static public SportsFacilityEntities5aaaaaaa GetContext()
        {
            if (m_context == null)
                return new SportsFacilityEntities5aaaaaaa();
            else
                return m_context;
        }
        static public EDMHandler GetInstance()
        {
            if (m_HandlerSingleTon == null)
                return new EDMHandler();
            else
                return m_HandlerSingleTon;
        }
        public void ExecuteQuery(FormClass.ResultListenerInterface<ArrayList> resultListener)
        {
            if (m_action == "SearchFacility")
            {
                ArrayList list = new HandleRequest<ArrayList>(new Controllers.SearchBookingControl.Book(m_fname, m_date)).execute();
                if (resultListener != null)
                    resultListener.onResultsSucceded(list);
            }
        }
        public void ExecuteQuery(FormClass.ResultListenerInterface<List<BookingDetail>> resultListener)
        {
            if (m_action == "SearchFacility")
            {
                List<BookingDetail> list = new HandleRequest<List<BookingDetail>>(new Controllers.SearchBookingControl.CancelBooking(m_mid, m_date)).execute();
                if (resultListener != null)
                    resultListener.onResultsSucceded(list);
            }
        }
        public void ExecuteQuery(FormClass.ResultListenerInterface<List<Member>> resultListener)
        {
            //List<Member> list;
            //m_memberlistresultListener = resultListener;
            //if (m_action == "SearchMember")
            //{
            //    ;// list = new LoadMemberData().execute();
            //}
            //m_context.SaveChanges();
            //if (resultListener != null)
            //resultListener.onResultsSucceded(list);
        }
        public void ExecuteQuery(FormClass.ResultListenerInterface<bool> resultListener)
        {
            bool result = false;
            if (m_action == "BookFacility")
            {
                result = new HandleRequest<bool>(new Controllers.BookingFormControl(m_date,m_mid, m_fid, m_colcount)).execute();
            }
            if (m_action == "CancelBooking")
            {
                result = new HandleRequest<bool>(new Controllers.CancelBookingControl(m_date,m_mid,m_fid, m_colcount)).execute();
            }
            if (m_action == "InsertFacility")
            {
                result = new HandleRequest<bool>(new Controllers.InsertFacilityControl(m_fid, m_fname,false,m_desc)).execute();
            }
            if (m_action == "DeleteFacility")
            {
                result = new HandleRequest<bool>(new Controllers.InsertFacilityControl(m_fid, m_fname, true, m_desc)).execute();
            }
            if (resultListener != null)
            {
                if (result == true)
                    resultListener.onResultsSucceded(result);
                else
                    resultListener.onResultsFail(result);
            }
            m_context.SaveChanges();
        }
        private class HandleRequest<Result>
        {
            Command<Result> m_command;
            public HandleRequest(Command<Result> controller)
            {
                m_command = controller;
            }
            public Result execute()
            {
                return m_command.execute();
            }
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VenkatFinalProject.Controllers
{
    class ReportController
    {
       Team6sportsfacility1 ds = new Team6sportsfacility1();
        public Team6sportsfacility1 makeListofMembers()
        {

            Team6sportsfacility1TableAdapters.MembersTableAdapter mta = new Team6sportsfacility1TableAdapters.MembersTableAdapter();
            mta.Fill(ds.Members);
            return ds;
        }

        public Team6sportsfacility1 prepareBookingChat()
        {
            Team6sportsfacility1TableAdapters.BookingDetailsTableAdapter bta = new Team6sportsfacility1TableAdapters.BookingDetailsTableAdapter();
            bta.Fill(ds.BookingDetails);
            return ds;
        }


        public Team6sportsfacility1 prepareListoffac()
        {
            Team6sportsfacility1TableAdapters.BookingDetailsTableAdapter bta = new Team6sportsfacility1TableAdapters.BookingDetailsTableAdapter();
            bta.Fill(ds.BookingDetails);
            return ds;

        }

        public Team6sportsfacility1 prepareChartReport()
        {
            Team6sportsfacility1TableAdapters.availabilityThursdayTableAdapter atta = new Team6sportsfacility1TableAdapters.availabilityThursdayTableAdapter();
            Team6sportsfacility1TableAdapters.availabilityFridayTableAdapter afta = new Team6sportsfacility1TableAdapters.availabilityFridayTableAdapter();
            atta.Fill(ds.availabilityThursday);
            afta.Fill(ds.availabilityFriday);
            return ds;

        }

        public Team6sportsfacility1 prepareBookingTransaction()
        {
            Team6sportsfacility1TableAdapters.BookingDetailsTableAdapter bta = new Team6sportsfacility1TableAdapters.BookingDetailsTableAdapter();
            Team6sportsfacility1TableAdapters.FacilityTableAdapter fta = new Team6sportsfacility1TableAdapters.FacilityTableAdapter();
            Team6sportsfacility1TableAdapters.MembersTableAdapter mta = new Team6sportsfacility1TableAdapters.MembersTableAdapter();
            bta.Fill(ds.BookingDetails);
            fta.Fill(ds.Facility);
            mta.Fill(ds.Members);
            return ds;
        }
    }
}

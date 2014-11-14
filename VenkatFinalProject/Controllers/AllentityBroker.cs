using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Reflection;

namespace VenkatFinalProject.Controllers
{
    class AllentityBroker
    {
        private SportsFacilityEntities5aaaaaaa context;
       private StringDictionary sdr ;
       public ArrayList al;
        public AllentityBroker()
       {
           context = EDM.EDMHandler.GetContext();
           sdr = new StringDictionary();
           sdr.Add("Badminton","bT");
           sdr.Add("TableTenis", "TT");
           al = new ArrayList();
           
       }
        public List<string> getTypeoFfacilites()
        {
          List<string> list = new List<string>();
            var q = (from x in EDM.EDMHandler.GetContext().Facilities
                     select x.FacilityType).Distinct();

            foreach( var item in q)
            {
                list.Add((string)item);
            }
                   



            return list;
        }

          private    void searchBookingiMon(string faclity)
        {
            var Monquery = from x in EDM.EDMHandler.GetContext().availabilityMondays
                           where x.Facility.FacilityType==faclity
                           select x;
            List<availabilityMonday> monlist = new List<availabilityMonday>();
             foreach(var o in Monquery)
             {
               
                 monlist.Add(o);
                 al.Add(o);

             }
          
        }

          private void searchBookingiTues(string faclity)
          {
              var Monquery = from x in EDM.EDMHandler.GetContext().availabilityTuesdays
                             where x.Facility.FacilityType == faclity
                             select x;
              List<availabilityTuesday> tuelist = new List<availabilityTuesday>();
              foreach (var o in Monquery)
              {
                  tuelist.Add(o);
                  al.Add(o);

              }
    
          }

          private void searchBookingiWed(string faclity)
          {
              var wedquery = from x in EDM.EDMHandler.GetContext().availabilityWednesdays
                             where x.Facility.FacilityType == faclity
                             select x;
              List<availabilityWednesday> wedlist = new List<availabilityWednesday>();
              foreach (var o in wedquery)
              {
                  wedlist.Add(o);
                  al.Add(o);

              }
             
          }

          private void searchBookingiThurs(string faclity)
          {
              var Thrusquery = from x in EDM.EDMHandler.GetContext().availabilityThursdays
                               where x.Facility.FacilityType == faclity
                               select x;
              List<availabilityThursday> Thruslist = new List<availabilityThursday>();
              foreach (var o in Thrusquery)
              {
                  Thruslist.Add(o);
                  al.Add(o);
                 

              }

          }
          private void searchBookingiFri(string faclity)
          {
              var Friquery = from x in EDM.EDMHandler.GetContext().availabilityFridays
                             where x.Facility.FacilityType == faclity
                             select x;
              List<availabilityFriday> Frilist = new List<availabilityFriday>();
              foreach (var o in Friquery)
              {
                  Frilist.Add(o);
                  al.Add(o);

              }
         
          }
          private void searchBookingiSat(string faclity)
          {
              var Satquery = from x in EDM.EDMHandler.GetContext().availabilitySaturdays
                             where x.Facility.FacilityType == faclity
                             select x;
              List<availabilitySaturday> Satlist = new List<availabilitySaturday>();
              foreach (var o in Satquery)
              {
                  Satlist.Add(o);
                  al.Add(o);

              }
           
          }
          private void searchBookingiSun(string faclity)
          {
              var Sunquery = from x in EDM.EDMHandler.GetContext().availabilitySundays
                             where x.Facility.FacilityType == faclity
                             select x;
        
              foreach (var o in Sunquery)
              {
           
                  al.Add(o);

              }
             
          }

          public ArrayList searchBoooking(string facilty, DayOfWeek d)
          {
              if (al.Count != 1)
              {
                  al.Clear();
              }
              switch ((int)d)
              {
                  case 0:

                      searchBookingiSun(facilty);
                      break;
                  case 1:
                      searchBookingiMon(facilty);
                      break;
                  case 2:
                      searchBookingiTues(facilty);
                      break;
                  case 3:
                      searchBookingiWed(facilty);
                      break;
                  case 4:
                      searchBookingiThurs(facilty);
                      break;
                  case 5:

                      searchBookingiFri(facilty);
                      break;
                  case 6:
                      searchBookingiSat(facilty);
                      break;
              }
              //  ArrayList retura = new ArrayList();
              //foreach(object o in al)
              //{Type getype=o.GetType();
              //   foreach(PropertyInfo prinfo in getype.GetProperties() )
              //   {
              //       string c = prinfo.PropertyType.ToString();
              //       if((prinfo.CanRead)&& prinfo.PropertyType.Equals("System.Int16")) 
              //       {//Int16 c=(short)(prinfo.GetValue(o,null));
              //           if((Int16)(prinfo.GetValue(o,null))==0)
              //           { 
              //               object x="available";
              //               prinfo.SetValue(o, x, null);
              //           }
              //       }
              //   }
              //}

              return al;
          }

        public List<BookingDetail> searchbyMemberID(string memberid,DateTime d)
        {
            var detailsquery = context.BookingDetails.Where(x => x.Member.MemberID ==memberid & x.DateofBooking == d);

            return detailsquery.ToList<BookingDetail>();
        }

        public List<Member> allMembers()
        {
            var member = from x in context.Members
                         select x;
            return member.ToList<Member>();
        }



        public void updateAvailability(string fid, DayOfWeek d, int hour)
        {


            switch ((int)d)
            {
                case 1:

                    availabilityMonday mon;
                    var query = from cr in context.availabilityMondays
                                where cr.facilityID.Equals(fid)
                                select cr;
                    if (query.Count<availabilityMonday>() == 0)
                    {

                        mon = new availabilityMonday();
                    }
                    else
                    {
                        mon =
                         (availabilityMonday)query.FirstOrDefault<availabilityMonday>(); ;
                    }
                    mon.facilityID = fid;
                    if (hour == 9)
                    {
                        mon.Slot9To10 ^= 1;

                    }
                    else if (hour == 10)
                    {
                        mon.slot10to11 ^= 1;


                    }
                    else if (hour == 11)
                    {
                        mon.slot11to12 ^= 1;
                    }
                    else if (hour == 12)
                    {
                        mon.slot12to13 ^= 1;

                    }
                    else if (hour == 13)
                    {

                        mon.slot13to14 ^= 1;

                    }
                    else if (hour == 14)
                    {

                        mon.slot14to15 ^= 1;

                    }
                    else if (hour == 15)
                    {

                        mon.slot15to16 ^= 1;

                    }
                    else if (hour == 16)
                    {

                        mon.slot16to17 ^= 1;

                    }
                    else if (hour == 17)
                    {

                        mon.slot117to18 ^= 0;
                    }
                    if (query.Count<availabilityMonday>() == 0)
                    {

                        context.availabilityMondays.Add(mon);
                    }


                    context.SaveChanges();
                    break;
                case 2:

                    availabilityTuesday tues;


                    var tquery = from cr in context.availabilityTuesdays
                                 where cr.facilityID.Equals(fid)
                                 select cr;
                    if (tquery.Count<availabilityTuesday>() == 0)
                    {

                        tues = new availabilityTuesday();
                    }
                    else
                    {
                        tues =
                          (availabilityTuesday)tquery.FirstOrDefault<availabilityTuesday>();
                    }
                    tues.facilityID = fid;
                    if (hour == 9)
                    {
                        short? flag = 1;
                        tues.Slot9To10 ^= flag;

                    }
                    else if (hour == 10)
                    {
                        short? flag = 1;
                        tues.slot10to11 ^= flag;



                    }
                    else if (hour == 11)
                    {
                        short? flag = 1;
                        tues.slot11to12 ^= flag;




                    }
                    else if (hour == 12)
                    {
                        tues.slot12to13 ^= 1;

                    }
                    else if (hour == 13)
                    {

                        tues.slot13to14 ^= 1;

                    }
                    else if (hour == 14)
                    {

                        tues.slot14to15 ^= 1;

                    }
                    else if (hour == 15)
                    {

                        tues.slot15to16 ^= 1;

                    }
                    else if (hour == 16)
                    {

                        tues.slot16to17 ^= 1;

                    }
                    else if (hour == 17)
                    {
                        tues.slot117to18 ^= 1;
                    }
                    else
                    {
                        tues.Slot9To10 = 0;
                        tues.slot10to11 = 0;
                        tues.slot11to12 = 0;
                        tues.slot12to13 = 0;
                        tues.slot13to14 = 0;
                        tues.slot14to15 = 0;
                        tues.slot15to16 = 0;
                        tues.slot16to17 = 0;
                        tues.slot117to18 = 0;
                    }
                    if (tquery.Count<availabilityTuesday>() == 0)
                    {

                        context.availabilityTuesdays.Add(tues);
                    }

                    context.SaveChanges();
                    break;
                case 3:

                    availabilityWednesday wednes;


                    var wquery = from cr in context.availabilityWednesdays
                                 where cr.facilityID.Equals(fid)
                                 select cr;
                    if (wquery.Count<availabilityWednesday>() == 0)
                    {

                        wednes = new availabilityWednesday();
                    }
                    else
                    {
                        wednes = (availabilityWednesday)wquery.FirstOrDefault<availabilityWednesday>();
                    }
                    wednes.facilityID = fid;
                    if (hour == 9)
                    {
                        wednes.Slot9To10 ^= 1;

                    }
                    else if (hour == 10)
                    {
                        wednes.slot10to11 ^= 1;


                    }
                    else if (hour == 11)
                    {

                        wednes.slot11to12 ^= 1;



                    }
                    else if (hour == 12)
                    {
                        wednes.slot12to13 ^= 1;

                    }
                    else if (hour == 13)
                    {
                        wednes.slot13to14 ^= 1;

                    }
                    else if (hour == 14)
                    {

                        wednes.slot14to15 ^= 1;

                    }
                    else if (hour == 15)
                    {

                        wednes.slot15to16 ^= 1;

                    }
                    else if (hour == 16)
                    {
                        wednes.slot16to17 ^= 1;

                    }
                    else
                    {
                        wednes.Slot9To10 = 0;
                        wednes.slot10to11 = 0;
                        wednes.slot11to12 = 0;
                        wednes.slot12to13 = 0;
                        wednes.slot13to14 = 0;
                        wednes.slot14to15 = 0;
                        wednes.slot15to16 = 0;
                        wednes.slot16to17 = 0;
                    }
                    if (wquery.Count<availabilityWednesday>() == 0)
                    {

                        context.availabilityWednesdays.Add(wednes);
                    }

                    context.SaveChanges();
                    break;
                case 4:

                    availabilityThursday thurs;


                    var thquery = from cr in context.availabilityThursdays
                                  where cr.facilityID.Equals(fid)
                                  select cr;
                    if (thquery.Count<availabilityThursday>() == 0)
                    {

                        thurs = new availabilityThursday();
                    }
                    else
                    {
                        thurs = (availabilityThursday)thquery.FirstOrDefault<availabilityThursday>();
                    }
                    thurs.facilityID = fid;
                    if (hour == 9)
                    {
                        thurs.Slot9To10 ^= 1;

                    }
                    else if (hour == 10)
                    {
                        thurs.slot10to11 ^= 1;


                    }
                    else if (hour == 11)
                    {

                        thurs.slot11to12 ^= 1;



                    }
                    else if (hour == 12)
                    {
                        thurs.slot12to13 ^= 1;

                    }
                    else if (hour == 13)
                    {

                        thurs.slot13to14 ^= 1;

                    }
                    else if (hour == 14)
                    {

                        thurs.slot14to15 ^= 1;

                    }
                    else if (hour == 15)
                    {

                        thurs.slot15to16 ^= 1;

                    }
                    else if (hour == 16)
                    {

                        thurs.slot16to17 ^= 1;

                    }
                    else if (hour == 17)
                    {
                        thurs.slot117to18 ^= 1;
                    }
                    else
                    {
                        thurs.Slot9To10 = 0;
                        thurs.slot10to11 = 0;
                        thurs.slot11to12 = 0;
                        thurs.slot12to13 = 0;
                        thurs.slot13to14 = 0;
                        thurs.slot14to15 = 0;
                        thurs.slot15to16 = 0;
                        thurs.slot16to17 = 0;
                    }
                    if (thquery.Count<availabilityThursday>() == 0)
                    {

                        context.availabilityThursdays.Add(thurs);
                    }

                    context.SaveChanges();
                    break;
                case 5:

                    availabilityFriday Fri;



                    var friquery = from cr in context.availabilityFridays
                                   where cr.facilityID.Equals(fid)
                                   select cr;
                    if (friquery.Count<availabilityFriday>() == 0)
                    {

                        Fri = new availabilityFriday();
                    }
                    else
                    {
                        Fri = (availabilityFriday)friquery.FirstOrDefault<availabilityFriday>();
                    }
                    Fri.facilityID = fid;
                    if (hour == 9)
                    {
                        Fri.Slot9To10 ^= 1;

                    }
                    else if (hour == 10)
                    {
                        Fri.slot10to11 ^= 1;


                    }
                    else if (hour == 11)
                    {

                        Fri.slot11to12 ^= 1;



                    }
                    else if (hour == 12)
                    {
                        Fri.slot12to13 ^= 1;

                    }
                    else if (hour == 13)
                    {

                        Fri.slot13to14 ^= 1;

                    }
                    else if (hour == 14)
                    {

                        Fri.slot14to15 ^= 1;

                    }
                    else if (hour == 15)
                    {

                        Fri.slot15to16 ^= 1;

                    }
                    else if (hour == 16)
                    {

                        Fri.slot16to17 ^= 1;

                    }
                    else if (hour == 17)
                    {
                        Fri.slot117to18 ^= 1;
                    }
                    else
                    {
                        Fri.Slot9To10 = 0;
                        Fri.slot10to11 = 0;
                        Fri.slot11to12 = 0;
                        Fri.slot12to13 = 0;
                        Fri.slot13to14 = 0;
                        Fri.slot14to15 = 0;
                        Fri.slot15to16 = 0;
                        Fri.slot16to17 = 0;
                    }
                    if (friquery.Count<availabilityFriday>() == 0)
                    {


                        context.availabilityFridays.Add(Fri);
                    }

                    context.SaveChanges();
                    break;
                case 6:


                    availabilitySaturday Sat;


                    var satquery = from cr in context.availabilitySaturdays
                                   where cr.facilityID.Equals(fid)
                                   select cr;
                    if (satquery.Count<availabilitySaturday>() == 0)
                    {

                        Sat = new availabilitySaturday();
                    }
                    else
                    {
                        Sat = (availabilitySaturday)satquery.FirstOrDefault<availabilitySaturday>();
                    }
                    Sat.facilityID = fid;
                    if (hour == 9)
                    {
                        Sat.Slot9To10 ^= 1;
                    }
                    else if (hour == 10)
                    {
                        Sat.slot10to11 ^= 1;


                    }
                    else if (hour == 11)
                    {

                        Sat.slot11to12 ^= 1;



                    }
                    else if (hour == 12)
                    {
                        Sat.slot12to13 ^= 1;
                    }

                    else if (hour == 13)
                    {

                        Sat.slot13to14 ^= 1;

                    }
                    else if (hour == 14)
                    {

                        Sat.slot14to15 ^= 1;

                    }
                    else if (hour == 15)
                    {

                        Sat.slot14to15 ^= 0;

                    }
                    else if (hour == 16)
                    {

                        Sat.slot16to17 ^= 1;

                    }
                    else
                    {
                        Sat.Slot9To10 = 0;
                        Sat.slot10to11 = 0;
                        Sat.slot11to12 = 0;
                        Sat.slot12to13 = 0;
                        Sat.slot13to14 = 0;
                        Sat.slot14to15 = 0;
                        Sat.slot15to16 = 0;
                        Sat.slot16to17 = 0;
                    }
                    if (satquery.Count<availabilitySaturday>() == 0)
                    {

                        context.availabilitySaturdays.Add(Sat);
                    }

                    context.SaveChanges();
                    break;
                case 0:

                    availabilitySunday Sun;



                    var sunquery = from cr in context.availabilitySundays
                                   where cr.facilityID.Equals(fid)
                                   select cr;
                    if (sunquery.Count<availabilitySunday>() == 0)
                    {

                        Sun = new availabilitySunday();
                    }
                    else
                    {
                        Sun = (availabilitySunday)sunquery.FirstOrDefault<availabilitySunday>();
                    }
                    if (hour == 9)
                    {
                        Sun.Slot9To10 ^= 1;

                    }
                    else if (hour == 10)
                    {
                        Sun.slot10to11 ^= 1;


                    }
                    else if (hour == 11)
                    {

                        Sun.slot11to12 ^= 1;



                    }
                    else if (hour == 12)
                    {
                        Sun.slot12to13 ^= 1;

                    }
                    else if (hour == 13)
                    {

                        Sun.slot13to14 ^= 1;

                    }
                    else if (hour == 14)
                    {

                        Sun.slot14to15 ^= 1;

                    }
                    else if (hour == 15)
                    {

                        Sun.slot15to16 ^= 1;

                    }
                    else if (hour == 16)
                    {

                        Sun.slot16to17 ^= 1;

                    }
                    else
                    {
                        Sun.Slot9To10 = 0;
                        Sun.slot10to11 = 0;
                        Sun.slot11to12 = 0;
                        Sun.slot12to13 = 0;
                        Sun.slot13to14 = 0;
                        Sun.slot14to15 = 0;
                        Sun.slot15to16 = 0;
                        Sun.slot16to17 = 0;
                    }
                    if (sunquery.Count<availabilitySunday>() == 0)
                    {

                        context.availabilitySundays.Add(Sun);
                    }

                    context.SaveChanges();
                    break;
            }

        }
    }
}

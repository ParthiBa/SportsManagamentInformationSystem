//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VenkatFinalProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookingDetail
    {
        public int BookingID { get; set; }
        public string FID { get; set; }
        public string MemberID { get; set; }
        public System.DateTime DateofBooking { get; set; }
        public string Slot { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual Facility Facility { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFMovieTheatre.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class seat
    {
        public int seatid { get; set; }
        public string seatname { get; set; }
        public int projectionroom_prjroomid { get; set; }
    
        public virtual projectionroom projectionroom { get; set; }
    }
}

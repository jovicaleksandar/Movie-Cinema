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
    
    public partial class drink
    {
        public int drinkid { get; set; }
        public string drinkname { get; set; }
        public Nullable<long> drinkprice { get; set; }
        public int bar_barid { get; set; }
    
        public virtual bar bar { get; set; }
    }
}

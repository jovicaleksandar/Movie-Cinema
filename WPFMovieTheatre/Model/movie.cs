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
    
    public partial class movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public movie()
        {
            this.projections = new HashSet<projection>();
        }
    
        public int movieid { get; set; }
        public string moviegenre { get; set; }
        public string movieformat { get; set; }
        public string movietitle { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projection> projections { get; set; }
    }
}

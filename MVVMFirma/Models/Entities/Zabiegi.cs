//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVVMFirma.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zabiegi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zabiegi()
        {
            this.HarmonogramZabiegow = new HashSet<HarmonogramZabiegow>();
        }
    
        public int ZabiegID { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public Nullable<decimal> Cena { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HarmonogramZabiegow> HarmonogramZabiegow { get; set; }
    }
}

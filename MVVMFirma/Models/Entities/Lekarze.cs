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
    
    public partial class Lekarze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lekarze()
        {
            this.GrafikLekarzy = new HashSet<GrafikLekarzy>();
            this.HarmonogramZabiegow = new HashSet<HarmonogramZabiegow>();
            this.Recepty = new HashSet<Recepty>();
            this.Wizyty = new HashSet<Wizyty>();
        }
    
        public int LekarzID { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Nullable<int> SpecjalizacjaID { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrafikLekarzy> GrafikLekarzy { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HarmonogramZabiegow> HarmonogramZabiegow { get; set; }
        public virtual Specjalizacje Specjalizacje { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Recepty> Recepty { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wizyty> Wizyty { get; set; }
    }
}

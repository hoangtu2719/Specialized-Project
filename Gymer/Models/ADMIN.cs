//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gymer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ADMIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADMIN()
        {
            this.BaiViets = new HashSet<BaiViet>();
        }
    
        public int MaAdmin { get; set; }
        public string HoTenAdmin { get; set; }
        public string DiaChiAdmin { get; set; }
        public string DienThoaiAdmin { get; set; }
        public string TenDNAdmin { get; set; }
        public string MatKhauAdmin { get; set; }
        public Nullable<System.DateTime> NgaySinhAdmin { get; set; }
        public Nullable<bool> GioiTinhAdmin { get; set; }
        public string EmailAdmin { get; set; }
        public Nullable<int> QuyenAdmin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }
    }
}

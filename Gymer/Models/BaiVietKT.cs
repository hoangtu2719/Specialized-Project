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
    
    public partial class BaiVietKT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiVietKT()
        {
            this.BaiViets = new HashSet<BaiViet>();
        }
    
        public int MaBaiVietKT { get; set; }
        public string NoiDung { get; set; }
        public string AnhChuDe { get; set; }
        public string TenChuDe { get; set; }
        public string TieuDe { get; set; }
        public Nullable<int> MaNguoiDung { get; set; }
        public Nullable<System.DateTime> NgayDang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }
    }
}
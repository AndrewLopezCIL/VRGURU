using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chapter4CodeFirst.Models
{
    public class BundlesModels
    {
        [Key]
        public int BundleID { get; set; }
        [ForeignKey("VRHeadsetModels")]
        [Display(Name = "Headset Bundle ID")]
        public int HeadsetBundledID { get; set; }
        [Display(Name = "Bundled Item")]
        public string BundledItem { get; set; }
        public virtual VRHeadsetModels VRHeadsetModels { get; set; }
        public virtual ICollection<StoresModels> StoresModels { get; set;}
    
    }
}
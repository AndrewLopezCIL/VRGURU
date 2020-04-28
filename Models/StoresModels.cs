using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chapter4CodeFirst.Models
{
    public class StoresModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Display(Name = "Store ID")]
        public int StoreID { get; set; }
        [Display(Name = "Store Name")]
        public string StoreName { get; set; }

        public virtual ICollection<BundlesModels> BundlesModels{ get; set; }
    }
}
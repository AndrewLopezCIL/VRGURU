using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chapter4CodeFirst.Models
{
    public class VRHeadsetModels
    {
        [Key]
        public int HeadsetID { get; set; }
        [Required(ErrorMessage = "Please enter a valid price.")]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please enter a store where the headset is available for purchase.")]
        [Display(Name = "Available Store Name")]
        public string AvailableStoreName { get; set; }
        [Required(ErrorMessage = "Please enter a name for the headset.")]
        [Display(Name = "Headset Name")]
        public string HeadsetName { get; set; }

        public virtual ICollection<BundlesModels> BundlesModels { get; set; }
    }
}
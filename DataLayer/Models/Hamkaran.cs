using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Hamkaran
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "نام همکار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "وب سایت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string WebSite { get; set; }

        [Display(Name = "تصویر")]
        public string ImageHamkaran { get; set; }
    }
}

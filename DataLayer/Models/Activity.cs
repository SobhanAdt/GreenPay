using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Activity
    {
        [Key]
        public int ActiveID { get; set; }

        [Display(Name = "تصویر")]
        public string ActiveImage { get; set; }

        [Display(Name = "توضیح")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ActiveTitle { get; set; }


    }
}

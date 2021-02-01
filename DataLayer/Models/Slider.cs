using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Slider
    {
        [Key]
        public int SliderID { get; set; }

        [Display(Name = "تصویر اسلایدر")]
        public string ImageSlider { get; set; }

        [Display(Name = "عنوان تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Alt { get; set; }

        [Display(Name = "آدرس ارجاء")]
        public string Url { get; set; }

        [Display(Name = "عنوان اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "زیر عنوان 1")]
        public string Subtitle1 { get; set; }

        [Display(Name = "زیر عنوان 2")]
        public string SubTitle2 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPlanlayiciProje.Models
{
    public class HomeViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını belirtiniz."), MaxLength(20)]
        [Display(Name ="Kullanızı adınız:")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen adınızı belirtiniz."), MaxLength(20)]
        [Display(Name = "Adınız:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen  soyadını belirtiniz."), MaxLength(30)]
        [Display(Name = "Soyadınız:")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz."), MaxLength(20)]
        [Display(Name = "Şifreniz :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz."), MaxLength(50)]
        [Display(Name = "Email:")]
        public string Email { get; set; }
    }
}

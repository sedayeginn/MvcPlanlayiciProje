using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcPlanlayiciProje.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adını belirtiniz."), MaxLength(20)]
        [Display(Name = "Kullanızı adınız:")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz."), MaxLength(20)]
        [Display(Name = "Şifreniz :")]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}

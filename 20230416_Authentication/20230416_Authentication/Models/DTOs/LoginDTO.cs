using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace _20230416_Authentication.Models.DTOs
{
    public class LoginDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı boş bırakılamaz.")]
        [Display(Name = "Kullanıcı Adı")]
        [MinLength(3, ErrorMessage = "Min. 3 karekter giriniz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Parola boş bırakılamaz.")]
        [Display(Name = "Parola")]
        [MinLength(6, ErrorMessage = "Min. 6 karekter giriniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnURL { get; set; }
    }
}

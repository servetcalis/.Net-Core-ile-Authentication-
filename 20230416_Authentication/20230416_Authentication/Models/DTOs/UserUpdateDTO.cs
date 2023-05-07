using _20230416_Authentication.Models.Entities.Concrete;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace _20230416_Authentication.Models.DTOs
{
    public class UserUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı boş bırakılamaz.")]
        [Display(Name = "Kullanıcı Adı")]
        [MinLength(3, ErrorMessage = "Min. 3 karekter giriniz.")]
        public string UserName { get; set; }

        [Display(Name = "Parola")]
        [MinLength(6, ErrorMessage = "Min. 6 karekter giriniz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Parola (Tekrar)")]
        [MinLength(6, ErrorMessage = "Min. 6 karekter giriniz.")]
        [Compare(nameof(Password), ErrorMessage = "Parolalar birbirleri ile uyuşmuyor.")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }


        [Required(ErrorMessage = "Email boş bırakılamaz.")]
        [Display(Name = "Email Adresi")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli bir email adresi giriniz.")]
        public string Email { get; set; }


        public UserUpdateDTO() { }

        public UserUpdateDTO(AppUser appUser)
        {
            UserName = appUser.UserName;
            Email = appUser.Email;
        }
    }
}

using _20230416_Authentication.Models.Entities.Interfaces;
using _20230416_Authentication.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace _20230416_Authentication.Models.Entities.Concrete
{
    // IdentityUser => Microsoft.Extensions.Identity.Stores paketini yükleyelim.
    // AspNetCore.Identity bize hazır olarak sunulmul bir sınıftır. AspNetCore.Identity aracılığı ile işlemlerimizi hızlıca yürütebiliriz. İçerisinde kullanıcının tüm işlemlerini yürütebileceğimiz hzır CRUD metodları ve migration ile veritabanına hızlı gönderebileceğimiz sınıflar bulunmaktadır. Kullanıcı işlemleri için veritabanında ve uygulama tarafında hazırlanması gereken varlıkları bize 8 adet sınıf aracılığıyla sunmaktadır. Migration esnasında göç ettirilen sınıflar incelendiğinde bunu görebilirsiniz. Bunun yanında Authentication işlemleri için yada CRUD operasyonlarında kullanabileceğimiz hazır metodlar senkron ve asenkron program için bizlere kolaylık sunmaktadır.

    // Günümüzde bir çok firma Identity mekanizması üzerine kendi yapılarını yada projede ihtiyaç dutdukları özellikleri kazandırarak kendi Identity yapılarını oluşturmaktadır. Bizde bu projede kendi Identity yapımızı oluşturalım. AppUser sınıfı içerisinde meslek tanımlaması yapalım.


    public class AppUser : IdentityUser, IBaseEntity
    {
        // AppUser sınıfımızı IdentityUser sınıfından katılım almaktadır. Böylelikle IdentityUser sınıfının size sunduğu üyelerden faydalanmakta. Fakat IdentityUser sınıfı ihtiyaçlarımızı karşılamaz ise ihtiyacımız olan üyeleri kendimiz ekleyebiliriz.
        public string Occupation { get; set; }


        private DateTime _createDate = DateTime.Now;
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;
        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}

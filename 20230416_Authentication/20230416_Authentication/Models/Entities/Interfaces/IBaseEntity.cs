using _20230416_Authentication.Models.Enums;
using System;

namespace _20230416_Authentication.Models.Entities.Interfaces
{
    public interface IBaseEntity
    {
        // IBaseEntity.cs sınıfında yada daha önce hazırladığımız base sınıf mantıklarında her zaman Id'y, ilgili ata sınıftan dağıtırdık. Çünkü hazırlayacağımız AppUser.cs sınıfında IdentityUser.cs sunufını kullanacağız ve bu sınıfın bie sunduğu hazır varlıklardan faydalanacağız ve farkına varacağınız gibi bu hazır varlıkların kendi id'leri ve iyi bir şekilde döşünülmüş kullanıcı bazlı üyeleri bulundurmaktadır. Bu yüzden IBaseEntity.cs üzerinden Id propertysi dağıtımı yapmayacağız.

        // Ayrıca arayüzlere bu şekilde üye tanımlamanın yazılım dünyasında hoş karşılanmayacağını unutmayalım ama bizim uygulamamızdaki AppUser sınıfı Concrete olan Identity sınıfından miras alacağından dolayı burada AppUser'ın soyutlamaya bağlı kalması açısından interfase kullanmak zorundaydık.

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }

    }
}

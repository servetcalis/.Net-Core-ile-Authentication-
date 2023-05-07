1. Asp.Net Core Web App (Model-View-Controller) projesi açılır.
2. "Model > Entities" klasörü oluşturulur.
	2.1. "Model > Enums" klasörü oluşturuldu.
		2.1.1. "Model > Enums > Status.cs" dosyası oluşturuldu.
	2.2. "Model > Entities > Interfaces" klasörü oluşturuldu.
		2.2.1 "Model > Entities > Interfaces > IBaseEntity.cs" dosyası oluşturuldu.
	2.3. "Model > Entities > Concrete" klasörü oluşturuldu.
		2.3.1. "Model > Entities > Concrete > AppUser.cs" dosyası oluşturuldu.
3. "Infrastructure" klasörü oluşturuldu.
	3.1. "Infrastructure > Context" klasörü oluşturuldu.
		3.1.1. "Infrastructure > Context > ApplicationDbContext.cs" dosyası oluşturuldu.
4. "Startup.cs" dosyası içerisinde configration ayarlarını yazalım.
5. "appsettings.json" dosyası içerisine "ConnectionString" cümlesini ekleyelim.
6. Migration yapalım.
7. "Models > DTOs" klasörü açalım.
	7.1. "Models > DTOs > RegisterDTO.cs" dosyası oluşturalım.
8. "Controller > AccountController.cs" dosyası oluşturalım.
### 2.HAFTA ÖDEVDE İSTENİLENLER
-İlk hafta geliştirdiğiniz api kullanılacaktır.
-Rest standartlarına uygun olmalıdır.
-solid prensiplerine uyulmalıdır.
-Fake servisler geliştirilerek Dependency injection kullanılmalıdır.
-Api’ nizde kullanılmak üzere extension geliştirin.
-Projede swagger implementasyonu gerçekleştirilmelidir.
-Global loglama yapan bir middleware(sadece actiona girildi gibi çok basit düzeyde)
Bonus
-Fake bir kullanıcı giriş sistemi yapın ve custom bir attribute ile bunu kontrol edin.
-Global exception middleware i oluşturun

### ÖDEV
-İlk hafta yaptığımız api üzerinden geliştirerek devam edelim.Projemizi tamamıyla n katmanlı mimariye çevirdik.

<img width="251" alt="image" src="https://github.com/user-attachments/assets/e4c0b54c-974a-4100-875e-72dbf712dbbf" />

Katman katman projemize ve içindekilere bakalım.

### ENTİTİES KATMANI
<img width="118" alt="image" src="https://github.com/user-attachments/assets/8be4a43d-6f6f-4c65-b3dc-acdace34d675" />
 Entities katmanı içerisinde varlıklarımızın olduğu sadece entity sınıfları bulunmaktadır. İlk hafta burada DataAnnatoins kurallarını yazmıştık. Fakat hem bu doğru değil hem de projemize fluent validation kütüphanesini kullanıcağız.

 ```c#
    public class Movie
    {      
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string Category { get; set; }
        public int Duration { get; set; } 
        public string Director { get; set; }
    }
```

### BUSINESS KATMANI
Şimdi business katmanımızın içeriğine bakalım.

<img width="190" alt="image" src="https://github.com/user-attachments/assets/3d110f00-c551-4fa6-8a8a-a268631e8eb9" />

Bu katmanda servis işlemlerimizi, validasyon işlemlerimizi gerçekleştiriceğiz. Servis işlemlerini yapaarken solid prensiplerine uygun olması ve daha test ediilebilir bir proje olması açısından soyutlama işlemini yapıyoruz. Bu yüzden burada soyut olan interfacelerimzi abstracts klasörü içerisinde, somut olan manager sınıflarımızı ise concretes klasörü içerisinde tutuyoruz.

Aşağıda IMovieService interface' i örenk olarak koyuldu.

<img width="461" alt="image" src="https://github.com/user-attachments/assets/598afe3b-9866-4206-bf88-77f8d56b3d7d" />


 Burda Validators klasörü içerisinde entitylerizmizin validator sınıfalrını bulunduruyoruz. Burda fluent validation kütüphanesinden faydalanarak kuurallarımızı yazıyoruz.
 
 <img width="687" alt="image" src="https://github.com/user-attachments/assets/44a038a8-9a99-4d3f-9e74-83a3c8b5bd6e" />

Ayrıca her katman için kendi ServiceRegistration classları nı kendi katmanı içerisinde yazıyoruz. Bu şekilde her katman kendi ihtiyacını barındıran gereksinimleri kendi katmanında tutucak.

<img width="647" alt="image" src="https://github.com/user-attachments/assets/f801bf7f-07e5-430b-8bae-d9bb567dd0c6" />

### DATA ACCESS KATMMANI
Bu katman bizim veri erişim katmanımızdır. Şuan projemizde bir veri tabanı kullanılmamaktadır. InMemory olarak projemizde kodlama yapıyoruz.Burda eğer service katmanında bir sorun olmassa data access katmanına gelerek veri işlemlerini gerçekleştirir.

<img width="236" alt="image" src="https://github.com/user-attachments/assets/4315b6a7-9f3c-4a46-93fc-bfa0ee1b0d4c" />

### CORE KATMANI 
Bu katman bizim aslında projeden bağımsız olarak her projede kullanabilceğimiz ksıımları içeren katmandır. Bu katman hiçbir katmana bağlı değildir. Bu katmanda global loglama ve exception middleware lerimizi bu katmanda kodlarız. Daha ayrıntılı olarak incelemek isterseniz kodlara bakabilirsizniz. 

<img width="203" alt="image" src="https://github.com/user-attachments/assets/4e8ad63c-69c0-4dc9-9415-5fae6fee294b" />

### API KATMANI 
Bu katman ise controller larımızın bulunduğu katmandır.

<img width="218" alt="image" src="https://github.com/user-attachments/assets/7b6dcaf1-7f52-4d82-b7c6-fd3f6709af3c" />

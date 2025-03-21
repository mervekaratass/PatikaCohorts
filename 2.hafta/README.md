### 📫 2.HAFTA ÖDEVDE İSTENİLENLER

- İlk hafta geliştirdiğiniz api kullanılacaktır.
- Rest standartlarına uygun olmalıdır.
- Solid prensiplerine uyulmalıdır.
- Fake servisler geliştirilerek Dependency injection kullanılmalıdır.
- Api’ nizde kullanılmak üzere extension geliştirin.
- Projede swagger implementasyonu gerçekleştirilmelidir.
- Global loglama yapan bir middleware(sadece actiona girildi gibi çok basit düzeyde)
Bonus
-Fake bir kullanıcı giriş sistemi yapın ve custom bir attribute ile bunu kontrol edin.
-Global exception middleware i oluşturun

### ⚡ÖDEV
İlk hafta yaptığımız api üzerinden geliştirerek devam edelim.Projemizi tamamıyla n katmanlı mimariye çevirdik.

<img width="251" alt="image" src="https://github.com/user-attachments/assets/e4c0b54c-974a-4100-875e-72dbf712dbbf" />

Katman katman projemize ve içindekilere bakalım.

-----------------------------------------------------------------------

### 🌱 ENTİTİES KATMANI
<img width="118" alt="image" src="https://github.com/user-attachments/assets/8be4a43d-6f6f-4c65-b3dc-acdace34d675" />

✍🏻 Entities katmanı içerisinde varlıklarımızın olduğu sadece entity sınıfları bulunmaktadır. İlk hafta burada DataAnnatoins kurallarını yazmıştık. Fakat hem bu doğru değil hem de projemize fluent validation kütüphanesini kullanıcağız.

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
-----------------------------------------------------------------------

### 🌱 BUSINESS KATMANI
Şimdi business katmanımızın içeriğine bakalım.

<img width="190" alt="image" src="https://github.com/user-attachments/assets/3d110f00-c551-4fa6-8a8a-a268631e8eb9" />

🛠 Bu katmanda servis işlemlerimizi, validasyon işlemlerimizi gerçekleştiriceğiz. Servis işlemlerini yapaarken solid prensiplerine uygun olması ve daha test ediilebilir bir proje olması açısından soyutlama işlemini yapıyoruz. Bu yüzden burada soyut olan interfacelerimzi abstracts klasörü içerisinde, somut olan manager sınıflarımızı ise concretes klasörü içerisinde tutuyoruz.

Aşağıda IMovieService interface' i örenk olarak koyuldu.
 ```c#
 public interface IMovieService
 {
     List<Movie> GetAll();
     Movie? GetById(int id);
     void Add(Movie movie);
     Movie? Update(int id, Movie movie);
     void Delete(int id);
     List<Movie> GetByQuery(string? name, string? category);
 }
 ```

 Burda Validators klasörü içerisinde entitylerizmizin validator sınıfalrını bulunduruyoruz. Burda fluent validation kütüphanesinden faydalanarak kuurallarımızı yazıyoruz.

  ```c#
  public class MovieValidator : AbstractValidator<Movie>
  {
      public MovieValidator()
      {
          RuleFor(m => m.MovieName)
             .NotEmpty().WithMessage("Film adı zorunludur.")
             .Length(1, 50).WithMessage("Film adı 1 ile 50 karakter arasında olmalıdır.");

          RuleFor(m => m.Duration)
            .GreaterThan(0).WithMessage("Film süresi 0'dan büyük olmalıdır.");

          RuleFor(m => m.Category)
            .NotEmpty().WithMessage("Kategori ismi zorunludur.");

          RuleFor(m => m.Director)
            .NotEmpty().WithMessage("Yönetmen adı zorunludur.")
            .Length(1, 50).WithMessage("Yönetmen adı 1 ile 50 karakter arasında olmalıdır.");
      }
  }
 ```

Ayrıca her katman için kendi ServiceRegistration classları nı kendi katmanı içerisinde yazıyoruz. Bu şekilde her katman kendi ihtiyacını barındıran gereksinimleri kendi katmanında tutucak.

 ```c#
  public static class BusinessServiceRegistration
  {
      public static IServiceCollection AddBusinessServices(this IServiceCollection services)
      {
          services.AddSingleton<IMovieService, MovieManager>();
              
          return services;
      }
  }
  ```
-----------------------------------------------------------------------

### 🌱 DATA ACCESS KATMMANI

⚡Bu katman bizim veri erişim katmanımızdır. Şuan projemizde bir veri tabanı kullanılmamaktadır. InMemory olarak projemizde kodlama yapıyoruz.Burda eğer service katmanında bir sorun olmassa data access katmanına gelerek veri işlemlerini gerçekleştirir.

<img width="236" alt="image" src="https://github.com/user-attachments/assets/4315b6a7-9f3c-4a46-93fc-bfa0ee1b0d4c" />

-----------------------------------------------------------------------

### 🌱 CORE KATMANI 

⚡Bu katman bizim aslında projeden bağımsız olarak her projede kullanabilceğimiz ksıımları içeren katmandır. Bu katman hiçbir katmana bağlı değildir. Bu katmanda global loglama ve exception middleware lerimizi bu katmanda kodlarız. Daha ayrıntılı olarak incelemek isterseniz kodlara bakabilirsizniz. 

<img width="203" alt="image" src="https://github.com/user-attachments/assets/4e8ad63c-69c0-4dc9-9415-5fae6fee294b" />

### API KATMANI 
Bu katman ise controller larımızın bulunduğu katmandır.

<img width="218" alt="image" src="https://github.com/user-attachments/assets/7b6dcaf1-7f52-4d82-b7c6-fd3f6709af3c" />

----------------------------------------------------------------
Anlatıcaklarım bu kadar. Umarım açık olmuştur. 🧕🏻 Görüşürüz 🎉

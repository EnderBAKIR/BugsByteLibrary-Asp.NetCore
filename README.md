# Ender Bakır ASP.Net Core Mvc Bitirme Projesi
## Projenin Adı : “BugsByteLibrary”
### Projenin Amacı
BugsByteLibrary'nin amacı, yazılımda açık kaynak yardımlaşmayı arttırmak, 
desteklemek ve bunu keyifli bir hale getirmektir.
BugsByteLibrary'de kullanıcılar, kod yazarken karşılarına çıkan engelleri, onları artık 
bunaltıcı seviyeye getiren problemleri ve aldıkları hataları diğer kullanıcılar ile paylaşıp 
bu derdine bir çözüm bulabiliyor. Aynı sıkıntıları yaşayan diğer kullanıcılar ise bu yapıdan 
yararlanabiliyorlar.
Sitede kullanıcıların gezinmesi ve yeni bir şeyler öğrenmesi için yapıcı seçenekler mevcut. 
Bunlardan kısaca bahsetmek gerekirse, e-kitaplar, bilgilendirici bloglar ve en önemlisi 
kod bankası blogları ile kurslardır.
Kullanıcılar, diğer kişilerin bloglarına yorum yaparak, kod bankalarında belirlenen 
modeller için kodlar yazarak yorum sayılarını arttırıyor ve yaptıkları yorumlara göre ekitaplara, kurslara erişim sağlayabiliyorlar. Bu sayede kullanıcıyı site içerisinde daha çok 
tutmaya, diğer insanlara yardımcı olmaya istekli hale getirmiş oluyoruz.
Sitenin doğası gereği yazılımcıları içerisine çektiği için istihdam alanları da bulunuyor. 
Site yönetimi tarafından açılan iş ilanlarına kullanıcılar başvuru yapabiliyor, bu sayede 
sadece bir forum sitesi olmaktan çıkıp farklı bir sektöre de hitap eden bir yapıya bürünmüş oluyor.

------------


#### Projedeki Yapıların İşleyişi
##### • Kategoriler
Kategorileri admin oluşturabiliyor, güncelleyebiliyor ve silebiliyor. Kategoriler ile 
bloglar arasında çoklu ilişki kuruldu ve bir bloğu kullanıcının gereksinimine göre birden fazla 
kategoriye tanımlı olarak ekleyebiliyor. Kategoriler aynı zamanda sitedeki bilgilendirici 
bloglar ile kod bankası bloglarında da kullanılıyor ve listeleme sırasında yapıların karışıklık 
yaratmasını engelliyor. Bir kategori silindiğinde ona ait blogların silinmesi özelliği kapalı, 
çünkü sitenin yapısını bozması söz konusu olabileceğinden veri kaybını önlemesi adına böyle 
bir karar alındı.
##### • Kullanıcı Blogları
Kullanıcıların oluşturacağı bloglar kategori seçilip oluşturuluyor, birden fazla kategori seçimi 
yapılabiliyor. Kişi istediği takdirde bloğuna resim ekleyebiliyor, güncelleme ve silme 
işlemlerini de gerçekleştirebiliyor.
##### • Yorumlar
Kullanıcılar, site içindeki bilgilendirici bloglar hariç diğer bloglara yorum yapabiliyor. Bu 
yorumlar, kişinin kendi profil alanında listeleniyor ve istediği zaman silebilir veya 
güncelleyebilir. Yorum silme işlemi, yorumu veritabanından tamamen kaldırmaz; sadece ilgili 
blogda ve kullanıcının profilinde görüntülenmesini engeller. Bu karar, olumsuz durumlar 
veya olası yasal sorunlarda yorumu tekrar erişebilmek ve verileri kullanabilmek amacıyla 
alınmıştır. Yorumları veritabanından tamamen silme işlemi sadece admin rolüne sahip kişiler 
tarafından gerçekleştirilebilir.
Yorumların diğer önemli bir özelliği ise kişiye platformdaki ödülleri kazandırabilmesidir. 
Ayrıca, bir kullanıcı kendi bloğuna gelen yorumlardan istediğini "Çözüm Yorumu" olarak 
işaretleyebilir. Bu özellik, ilgili blog ziyaret edildiğinde çözümü aramak yerine anında çözüme 
ulaşılmasını sağlayarak bilgiye ulaşmada zamanın ne kadar önemli bir unsur olduğunu göz 
önüne alarak siteye eklenmiştir.
##### • Bilgilendirici Bloglar
Bilgilendirici bloglar sadece admin rolüne sahip kişiler tarafından siteye eklenebilir. Bu 
bloglar, listelenmelerini sağlayan durum kodlarını içerir ve diğer bloglarla karışmalarını 
önler. Bilgilendirici bloglara herhangi bir kullanıcı ulaşabilir ve içeriğini görebilir, ancak 
sadece admin dışında kimse düzenleyemez veya silemez. Bu bloglara yorum atılamaz; bu 
bloglar, oluşturuldukları kategorideki konuya bağlı olarak bilgi aktarma amacıyla kullanılır. 
Bu blogların en önemli özelliği, site üzerinde sadece diğer kullanıcıların problemleri üzerine 
açılan bloglardan ziyade genel bilgi sağlamak isteyen kullanıcıları platformda tutmaya 
yardımcı olmalarıdır.
##### • Kod Bankası Blogları
Kod bankası blogları sadece admin rolüne sahip kişiler tarafından siteye eklenip, 
düzenlenebilir ve silinebilir. Diğer bloglardan durum kodları ile ayrılarak olası bir listeleme 
karışıklığı önlenir. Bu bloglarda yazılım dilleri üzerinde belirlenen modeller bulunur ve 
kullanıcılar bu modellere göre CRUD işlemleri, validasyonlar, ek özellikler gibi işlevsel kodları 
yazabilirler. Kullanıcıların yazdığı bu kodlar yorum olarak listelenir ve yine kullanıcıya site 
içerisindeki ödül mekanizmalarında avantaj sağlar. Bu blogların en önemli özelliği ise 
kendisine tanımlanan kategori ve model üzerinde diğer tecrübeli kişilerin bilgisini 
paylaşmasını sağlamak ve site ziyaretçilerinin de bundan faydalanabilmesidir.
##### • Kurslar
Kurslar sadece admin rolüne sahip kişiler tarafından siteye eklenip, düzenlenebilir ve 
silinebilir. Kurslara belirli bir yorum sayısına ulaşmış kullanıcılar istekte bulunabilir. Bu 
istekler admin sayfasında listelenir ve admin, kullanıcılara BugsyByteLibrary'nin, online ekurs mağazalarında bulunan ücretli içerikleri ücretsiz olarak alabilmelerini sağlayan kodları 
tanımlar. Bu kodları kullanıcılar profilinde görebilir ve ömür boyu erişim sağlayabilirler; ilgili 
kurs silinse dahi kullanıcıların kodlara erişimini engellememek adına kodlar kesinlikle 
silinmez. Bir kursa kod isteğinde bulunan kullanıcı, aynı işlemi tekrarlayamaz; bu da güvenlik 
sorunlarının önüne geçilmesini sağlar.
##### • İş İlanları
İş ilanları sadece admin rolüne sahip kişiler tarafından siteye eklenip, düzenlenebilir ve 
silinebilir. Sitenin sadece bir forum platformuna yönelik kalmaması ve içerisinde zengin bir 
içerik portföyünün oluşması adına istihdam alanı oluşturmak için iş ilanları eklenir. Bu 
sayede hem BugsByteLibrary'nin kendi eğitimci kadrosunu oluştururken zorlanmasının 
önüne geçilir, hem de yeni iş ortakları edinme olanağı sağlanır. İş ilanları site içerisinde 
listelenir; kullanıcılar kişisel bilgilerini ve kendilerine ait "pdf" formatındaki CV'lerini 
ekleyerek bu ilanlara başvurabilir. Kişi iş başvurularını ve başvuru durumlarını kendi 
profilinde görebilir, admin ise gelen başvuruları listeleyebilir ve bu başvurulara ret cevabı 
verebilir. Ancak hiçbir zaman başvurular veritabanından silinmez; ileriye dönük iş ağı 
oluşturmak adına bu verilerin veritabanında saklanması tercih edildi.


## Projede Kullanılan Teknolojiler Ve Tasarım Desenleri

### • Çerçeve Ve Mimari
1. Asp.Net Core MVC
2. Katmanlı Mimari
### • ORM Araçları
1. Entity Framework Core 
2. Entity Framework Core SqlServer
3. Entity Framework Core Tools
4. Entity Framework Core Design
### • Veri Tabanı Şeması Yaklaşımı
CodeFirst
### • Mail Gönderme İşlemleri
.Net Core Mailkit
### • Kimlik Doğrulama Ve Yetkilendirme
Asp.Net Core Identity Entity Framework Core
### • Validasyon Ve Nesne Doğrulama Kontrolü
ASP.NET Core Fluent Validation
### • Tasarım Desenleri 
1. Repository Pattern
2. Service Pattern
3. UnitOfWork Pattern
4. Dependency İnjection
5. Decorator Pattern


## Güvenlik İçin Alınan Önlemler 
Güvenlik için kimlik doğrulama ve rol bazlı yetkilendirme işlemlerinde kendisini kanıtlamış bir 
kütüphane olan Asp.Net Core Identity Entity Framework Core kütüphanesi kullanıldı.
Site yönetiminden sorumlu olan kullanıcılara admin rolü atandı ve admin için area yapıldı.
Admin areaya ait Url’lere bu role sahip olmayan herhangi bir kullanıcı girmeye çalıştığında 404 
status kodu ile karşılaşması sağlandı.
Kullanıcılar sadece kayıt olarak hesaplarını işlevsel hale getiremiyorlar. aynı zamanda mail 
doğrulama işlemini yapmak zorundalar. Maili doğrulanmayan kullanıcılar için Identity 
kütüphanesinin “MailConfirmed” özelliği değil projemizin gereksinimlerini karşılayan
doğrulama işlemleri yapıldı. Maili doğrulanmamış kullanıcılar sitede sadece “okuma” 
işlemlerini gerçekleştirebiliyor ama “Post” istekleri ile alakalı işlemleri kesinlikle yapamıyorlar.

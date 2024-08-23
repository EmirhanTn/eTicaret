using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eTicaret.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Category> categories = new List<Category>()
             {
            new Category(){Name = "Kamera", Description = "Kamera Ürünleri"},
            new Category(){Name = "Bilgisayar", Description = "Bilgisayar Ürünleri"},
            new Category(){Name = "Elektronik", Description = "Elektronik Ürünleri"},
            new Category(){Name = "Telefon", Description = "Telefon Ürünleri"},
            new Category(){Name = "beyaz Eşya", Description = "beyaz Eşya Ürünleri"},

            };

            foreach (var kategori in categories)
            {
                context.Categories.Add(kategori);

            }
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product(){ Name="Nikon D7500 18-140mm VR Kit İthalatçı Garantili", Description="Nikon D7500 18-140mm VR Kit İthalatçı Garantili\r\nÜRÜN ÖZELLİKLERİ\r\n\r\n20,9MP DX-Format CMOS Sensör\r\nEXPEED 5 Görüntü İşlemci\r\nOLPF – Yok\r\n3.2\" 1,229k-Nokta LCD Ekran\r\n30 fps Ultra HD 4K Video\r\n180.000 RGB Ölçüm Sensörü\r\n51 Nokta AF Sistemi\r\nISO 1.620.000 Genişletilebilir\r\n100-51200 ISO Eşdeğeri\r\n8fps Seri Çekim 100 Kareye Kadar\r\nDahili SnapBridge",Price=41249, Stock=10, IsApproved=true, CategoryId= 1,IsHome=true,Image="8.jpg"},
                new Product(){ Name="MSI CYBORG 15 A13VF-892XTR Intel Core i7 13620H 16GB", Description="şlemci: Intel® Core™ i7-13620H (24M Cache, up to 4.90 GHz)\r\nİşletim Sistemi: FreeDOS\r\nEkran: 15.6\" FHD (1920*1080), 144Hz\r\nChipset: Integrated SoC\r\nEkran Kartı: RTX 4060, GDDR6 8GB\r\nEkran Kartı Watt Değeri: 35W+10W (Dynamic Boost ile)\r\nHafıza: DDR V 16GB (8GB*2, 5200MHz)\r\nHafıza yuvası: 2 Slot\r\nMaksimum Hafıza: Max 64GB\r\nDepolama Kapasitesi: 512GB NVMe SSD\r\nDepolama Seçenekleri: 1x M.2 SSD slot (NVMe PCIe Gen4)\r\nÖn Kamera: HD type (30fps@720p)",Price=35999, Stock=5, IsApproved=true, CategoryId=2,IsHome=true,Image="5.jpg" },
                new Product(){ Name="Casper Nirvana C550.1255-BV00X-G-F Intel Core i7 1255U 16GB", Description="Casper Nirvana C550.1255-BV00X-G-F Intel Core i7 1255U 16GB 500GB SSD Freedos 15.6\" Taşınabilir Bilgisayar Özellikleri",Price=17999, Stock=20, IsApproved=true, CategoryId=2,IsHome=true, Image = "4.jpg"},
                new Product(){ Name="Xiaomi Redmi 12 128 GB 8 GB Ram (Xiaomi Türkiye Garantili)", Description="Xiaomi Redmi 12 128 GB 8 GB Ram (Xiaomi Türkiye Garantili) Özellikleri",Price=7199, Stock=25, IsApproved=true, CategoryId=4 ,IsHome=true,Image="7.jpg"},
                new Product(){ Name="Samsung Galaxy S24+ 256 GB 12 GB Ram (Samsung Türkiye Garantili)", Description="Galaxy S serisi, tasarımı, performansı ve yenilikçi özellikleriyle dikkat çekerken, S24+ modeli beklentilerin zirveye çıkmasına neden oldu. 256 GB geniş depolama kapasitesi ve 12 GB RAM ile donatılan bu cihaz, kullanıcılara benzersiz bir telefon kullanma deneyimi sunmayı amaçlıyor. Ürün, zarif ve modern tasarımıyla öne çıkıyor. Cihazın ön yüzü, kenardan kenara uzanan kavisli ekranı ile estetik bir şıklık sunarken, arka kısmındaki mat yüzey ve çerçevesiz kamera modülüyle de özgün bir izlenim bırakıyor.",Price=4629900, Stock=5, IsApproved=true, CategoryId=4, IsHome = true, Image = "6.jpg"},
              

                new Product(){ Name="iPhone 15 Plus 128 GB", Description="iPhone 15 Plus 128 GB Özellikleri\r\n",Price=60000, Stock=30, IsApproved=true, CategoryId=4, Image = "9.jpg"},
                new Product(){ Name="Samsung 55S90C 55\" 138 Ekran Uydu Alıcılı 4K Ultra HD Smart OLED TV", Description="Muhtemelen şu anda bu fiyata alabileceğiniz en iyi cihaz. TechRadar Choice Awards 2023’te Yılın TV’si olarak seçmemizde de bunun büyük etkisi var.”\r\n“Samsung S90C görüntü kalitesi ve performansın mükemmel bir birleşimini sunuyor.",Price=52379, Stock=15, IsApproved=true, CategoryId= 3,Image="11.jpg"},
                new Product(){ Name="Samsung WW11BGA046AEAH 11 Kg 1400 devir Çamaşır Makinesi", Description="Samsung WW11BGA046AEAH 11 Kg 1400 devir Çamaşır Makinesi Özellikleri",Price=17699, Stock=30, IsApproved=true, CategoryId=5,Image="1.jpg" },
                new Product(){ Name="Bosch WGA252Z0TR 1200 Devir 10 kg Çamaşır Makinesi", Description="Genel Özellikler Ürün Tipi Solo Renk Beyaz Programlar Beyazlar/renkliler programı, Hassas programı, Sentetikler programı, Yünlüler elde yıkama programı İlave yıkama programları AllergyPlus & Baby, Başlat/Beklet tuşu, Devir sayısı seçimi, Durulama, easy ironing steam assisted, Kalan süre erteleme, Kırışıklık önleme, Leke Çıkarma, Mix, Perde, Sıcaklık seçimi, Sıkma-Boşaltma, Süper-Kısa 15'/30', Tambur temizlik, VarioSpeed, Yorgan Su güvenlik sistemi Çoklu su koruması Çıkarılabilir üst kapak hayır Enerji sınıfı A Kapasite 10,0 kg Maksimum sıkma devri 1.200 rpm Kapı yönü Sol",Price=20000, Stock=5, IsApproved=true, CategoryId=5,Image="2.jpg"},
                new Product(){ Name="Apple Watch Seri 9 Gps 45MM Gece Yarısı Alüminyum Kasa Spor Kordon - M/l MR9A3TU/A", Description="\r\nApple Watch Seri 9 GPS 45mm Gece Yarısı Alüminyum Kasa Spor Kordon - M/L MR9A3TU/A",Price=16999, Stock=60, IsApproved=true, CategoryId= 3, Image = "3.jpg"},


            };
            foreach (var urun in products)
            {
                context.Products.Add(urun);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
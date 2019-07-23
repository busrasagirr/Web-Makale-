using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MakaleWeb.Entities;

namespace MakaleWeb.DataAccessLayer
{
    public class OrnekData : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Kullanicilar admin = new Kullanicilar()
            {
                Ad = "Büşra",
                Soyad = "Sağır",
                Email = "busrasagirr@hotmail.com",
                Sifre = "12345",
                Adminmi = true,
                Aktif = true,
                AktifGuid = Guid.NewGuid(),
                KullaniciAd = "busrasagir",
                OlusturmaTarihi = DateTime.Now,
                DegistirenKullanici = "busrasagir",
                DegistirmeTarihi = DateTime.Now.AddDays(3)
            };

            Kullanicilar uye = new Kullanicilar()
            {
                Ad = "Şevval",
                Soyad = "Özkan",
                Email = "sevvalozkan9898@hotmail.com",
                Sifre = "1234",
                Adminmi = false,
                Aktif = true,
                AktifGuid = Guid.NewGuid(),
                KullaniciAd = "sevo",
                OlusturmaTarihi = DateTime.Now,
                DegistirenKullanici = "sevo",
                DegistirmeTarihi = DateTime.Now.AddDays(3)
            };

            context.Kullanicilar.Add(admin);
            context.Kullanicilar.Add(uye);

            context.SaveChanges();

            for (int i = 0; i < 5; i++)
            {
                Kategoriler ktg = new Kategoriler()
                {
                    Baslik = FakeData.PlaceData.GetStreetName(),
                    Aciklama = FakeData.PlaceData.GetAddress(),
                    OlusturmaTarihi = DateTime.Now,
                    DegistirmeTarihi = DateTime.Now,
                    DegistirenKullanici = "busrasagir"
                };
                context.Kategoriler.Add(ktg);

                ktg.Makaleler = new List<Makaleler>();
                for (int j = 0; j < 5; j++)
                {
                    ktg.Makaleler.Add(new Makaleler()
                    {
                        Baslik = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 25)),
                        Metin = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        Taslakmi = false,
                        BegeniSayisi=FakeData.NumberData.GetNumber(1,9),
                        Kullanici=(j%2==0)?admin:uye,
                        DegistirmeTarihi=FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                        OlusturmaTarihi=FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                        DegistirenKullanici=(j%2==0)?admin.KullaniciAd:uye.KullaniciAd
                    });
                }
            context.Kategoriler.Add(ktg);
            }
            context.SaveChanges();

        }
        
    }
}

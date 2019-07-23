using MakaleWeb.DataAccessLayer;
using MakaleWeb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.BusinessLayer
{
    public class Test
    {
        Repository<Kullanicilar> rep_kul = new Repository<Kullanicilar>();
        Repository<Kategoriler> rep_kat = new Repository<Kategoriler>();
        Repository<Makaleler> rep_makale = new Repository<Makaleler>();
        Repository<Yorumlar> rep_yorum = new Repository<Yorumlar>();
        Repository<Begeniler> rep_begeni = new Repository<Begeniler>();

        public Test()
        {
            //// DAtabase yoksa bu aşağıdakiler database -i oluştursun. Kapattık çünkü database-i oluşturdum! Yoksa aç!
            DatabaseContext db = new DatabaseContext();
            ////db.Database.CreateIfNotExists();
            db.Kullanicilar.ToList();
            //*************************************

            //List<Kategoriler> kategoriler = rep_kat.List();
            //List<Kategoriler> kategori_filtre = rep_kat.List(x => x.ID == 1);  //parametreli olan List() -i nasıl kullanırızın örneği!
            List<Makaleler> makaleler = rep_makale.List();
        }

        public void YorumTest()
        {
            Kullanicilar kullanici = rep_kul.Find(x => x.ID == 1);
            Makaleler makale = rep_makale.Find(x => x.ID == 1);

            Yorumlar yorum = new Yorumlar()
            {
                Metin = "deneme",
                OlusturmaTarihi = DateTime.Now,
                DegistirmeTarihi = DateTime.Now,
                DegistirenKullanici = "busrasagir",
                Makale=makale,
                Kullanici=kullanici
            };
            
            rep_yorum.Insert(yorum);

        }

        public void InsertTest()
        {
            int kayit = rep_kul.Insert(new Kullanicilar()
            {
                Ad = "deneme",
                Soyad = "deneme",
                Email = "deneme@hotmail.com",
                Sifre = "12345",
                Adminmi = true,
                Aktif = true,
                AktifGuid = Guid.NewGuid(),
                KullaniciAd = "deneme",
                OlusturmaTarihi = DateTime.Now,
                DegistirenKullanici = "deneme",
                DegistirmeTarihi = DateTime.Now.AddDays(3)
            });

        }

        public void UpdateTest()
        {
            Kullanicilar user = rep_kul.Find(x => x.Ad == "Nurefşan");

            if (user != null)
            {
                user.Ad = "deneme";
                int kayit = rep_kul.Update();

            }
        }

        public void DeleteUpdate()
        {
            Kullanicilar user = rep_kul.Find(x => x.Ad == "Nurefşan");
            if (user != null)
            {
                int kayit = rep_kul.Delete(user);
            }

        }


    }
}

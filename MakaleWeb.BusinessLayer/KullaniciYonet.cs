using MakaleWeb.DataAccessLayer;
using MakaleWeb.Entities;
using MakaleWeb.Entities.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleWeb.BusinessLayer
{
    public class KullaniciYonet
    {
        Repository<Kullanicilar> rep_kul = new Repository<Kullanicilar>();
        BLHatalar<Kullanicilar> kullaniciSonuc = new BLHatalar<Kullanicilar>();

        public BLHatalar<Kullanicilar> KullaniciKayit(KayitModal model)
        {
            Kullanicilar kullanici = rep_kul.Find(x => x.KullaniciAd == model.KullaniciAd || x.Email == model.EMail);

            if (kullanici!=null)
            {
                if (kullanici.KullaniciAd==model.KullaniciAd)
                {
                    kullaniciSonuc.Hata.Add("Kullanıcı adı kayıtlı.");
                }
                if (kullanici.Email==model.EMail)
                {
                    kullaniciSonuc.Hata.Add("Kullanıcı mail adresi kayıtlı.");
                }
            }
            else
            {  //Kayıt işlemi
                //Aktivasyon e-posta gönderimi
                int kayit = rep_kul.Insert(new Kullanicilar()
                {
                    KullaniciAd = model.KullaniciAd,
                    Email = model.EMail,
                    Sifre = model.Sifre,
                    //OlusturmaTarihi=DateTime.Now,
                    //DegistirmeTarihi=DateTime.Now,
                    //DegistirenKullanici="busrasagir",
                    Aktif = false,
                    AktifGuid = Guid.NewGuid(),
                    Adminmi = false
                });
                if (kayit>0)
                {
                    kullaniciSonuc.sonuc = rep_kul.Find(x => x.KullaniciAd == model.KullaniciAd || x.Email == model.EMail);
                }
            }
            return kullaniciSonuc;
        }

        public BLHatalar<Kullanicilar> LoginUser(LoginModal data)
        {
            //giriş kontrolü
            //hesap aktive edilmiş mi?
            kullaniciSonuc.sonuc = rep_kul.Find(x => x.KullaniciAd == data.KullaniciAd && x.Sifre == data.Sifre);
            if (kullaniciSonuc.sonuc != null)
            {
                if (!kullaniciSonuc.sonuc.Aktif)
                {
                    kullaniciSonuc.Hata.Add("Kullanıcı aktifleştirilmemiştir! Lütfen e-posta adresinizi kontrol ediniz.");
                }
            }
            else
            {
                kullaniciSonuc.Hata.Add("Kullanıcı adı veya şifre uyuşmuyor.");
            }

            return kullaniciSonuc;
        }

    }
}

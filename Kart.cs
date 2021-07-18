using System;
using System.Collections.Generic;

namespace Proje_2
{
    class Kart
    {

        public string Başlık;
        public string İçerik;
        private int ID;
        private int Buyukluk;


        public Kart(string baslik,string icerik,int id, int buyukluk){
            // **Büyüklükler Enum olarak saklanmalı. Kart üzerinde gösterilirken XS olarak gösterilmeli. Giriş yapılırken kullanıcıdan 1 alınmalıdır.

            // **Takım üyeleri mevcut bir listede daha tanımlanmış olamlıdır.(Program içerisinde dinamik tanımlanmasına gerek yok.) Kart tanımlarken takım üyesinin ID'si istenmeli. Tanımlı bir ID değilse "Hatalı girişler yaptınız!" uyarısı ile işlem iptal edilebilir.
            this.Başlık=baslik;
            this.İçerik=icerik;
            this.ID=id;
            this.Buyukluk=buyukluk;
        }

        public int ID1 { get => ID; set => ID = value; }
        public int Buyukluk1 { get => Buyukluk; set => Buyukluk = value; }

        public void KartıKonsolaYazdir(){          
            Console.WriteLine("Başlık      : {0}",this.Başlık);
            Console.WriteLine("İçerik      : {0}",this.İçerik);
            Console.WriteLine("Atanan Kişi : {0}",this.ID);
            Console.WriteLine("Büyüklük    : {0}",(Buyukluk) this.Buyukluk);
            Console.WriteLine("-");
        }
    }
}
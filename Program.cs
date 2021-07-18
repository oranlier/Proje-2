using System;


namespace Proje_2
{
    public class Program
    {

        static void Main(string[] args)
        {
            //Board TODO - IN PROGRESS - DONE kolonlarından oluşmalı.

            //Varsayılan olarak bir board tanımlı olmalı ve 3 tane de kart barındırmalı.(Kartlar herhangi bir line'da yani kolonda olabilir.)

            //Kartlar ancak takımdan birine atanabilir. Takımdaki kişiler ise varsayılan olarak tanımlanmalı. Takım üyeleri Dictionary 
            //kullanılarak key-value pair şeklinde yada bir sınıf aracılığıyla tutulabilir. Kartlara atama yapılırken takım üyeleri ID leri 
            //ile atanacak. Yani kullanılacak ypının mutlaka bir ID içermesi gerekir.

            //Uygulama ilk başladığında kullanıcıya yapmak istediği işlem seçtirilir.

            Board _board = new();
            //varsayılan board elemanlarının atanması:
            _board.BoardaKartEkle(new Kart("baslik1","içerik1",1,1),0,false);
            _board.BoardaKartEkle(new Kart("baslik2","içerik2",2,2),0,false);
            _board.BoardaKartEkle(new Kart("baslik3","içerik3",3,3),0,false);

            bool cikma = true;
            while (cikma)
            {
            //Ana menunun konsola yazdırılması:
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");
            Console.WriteLine("Çıkmak için ENTER 'a basın:");
            int i = 0;
                if (!int.TryParse(Console.ReadLine(),out i)){
                    Console.WriteLine("İşlem sonlandırıldı.");
                    cikma = false;
                }
            
                if (i==1){
                    // string ad = KullaniciGirisleri.AdSoyadGirilsin("İsim");
                    // string soyad = KullaniciGirisleri.AdSoyadGirilsin("Soyisim");
                    // long no = KullaniciGirisleri.NoGirilsin();
                    // Rehber.KisiyiRehbereKaydet(new Kart(ad,soyad,no),true);
                    _board.BoardlarıListele(true);
                    cikma = true;  
                }
                else if(i==2){
                    _board.BoardaKartEkle();
                    cikma = true;
                }
                else if(i==3){
                    _board.BoardtanKartSil();
                    cikma = true;
                }
                else if(i==4){
                    _board.KartTaşı();
                    cikma = true; 
                }
                else{
                    Console.WriteLine("İşlem sonlandırıldı.");
                    cikma = false;
                }
            } 
        }
    }
}

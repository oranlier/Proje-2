using System;
using System.Collections.Generic;

namespace Proje_2
{
    class Board
    {
        public List<Kart>[] kolonlar = new List<Kart>[3];
        private List<string> KolonAdları = new List<string>(){"TODO","IN_PROGRESS","DONE"};
        public Board(){
            this.kolonlar[0]=new List<Kart>();
            this.kolonlar[1]=new List<Kart>();
            this.kolonlar[2]=new List<Kart>();
        }
        public bool BoardaKartEkle(){
                        string str="";
            foreach(KeyValuePair<int, string> kvp in CS.TakımÜyeleri)
                str += "("+kvp.Key+")"+kvp.Value+"  ";
            if(!CS.BirStringGir("Lütfen kart başlığını yazınız:",out string baslık )){return false;}
            if(!CS.BirStringGir("Lütfen kart içeriğini yazınız:",out string icerik )){return false;}
            if(!CS.AralıktaTamsayıGirilsin(1,CS.TakımÜyeleri.Count,"Takım Üyesi ID 'sini girin. " + str,out int ID )){return false;}
            if(!CS.AralıktaTamsayıGirilsin(1,5,"Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :)",out int takım)){return false;}
            
            Kart kart = new Kart(baslık,icerik,ID,takım);
            this.kolonlar[0].Add(kart);
            Console.WriteLine("{0} kartı boarda eklendi, devam etmek için ENTER 'a basın.", kart.Başlık);
            Console.ReadLine();
            return true;
        }
        public void BoardaKartEkle(Kart kart,int boardno, bool bilginotu){
            this.kolonlar[boardno].Add(kart);
            if(bilginotu){
                Console.WriteLine("{0} kartı boarda eklendi, devam etmek için ENTER 'a basın.", kart.Başlık);
                Console.ReadLine();
                }
        }

        public bool BoardtanKartSil(){
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            if (!CS.BirStringGir("Lütfen kart başlığını yazınız:",out string silinecekBaslik)){return false;}
            int silinenSay=0;
                foreach (var liste in this.kolonlar)
                {
                    silinenSay += liste.RemoveAll(t => t.Başlık == silinecekBaslik);
                }
                // Kart bulunamaz ise:
                if (silinenSay==0){
                    Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                    Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                    Console.WriteLine("* Yeniden denemek için : (2)");
                    if (!CS.AralıktaTamsayıGirilsin(1,2,"",out int i)){return false;}
                    if (i==2){BoardtanKartSil();}
                }
                else{
                    Console.WriteLine("{0} adet kart silindi, devam etmek için ENTER 'a basın.",silinenSay);
                    Console.ReadLine();
                }
                return true;
            // ** Aynı isimde birden fazla kart bulunursa her ikisi de silinebilir.
        }

        public bool KartTaşı(){
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            if (!CS.BirStringGir("Lütfen kart başlığını yazınız:",out string silinecekBaslik)){return false;}
            int listeno=0;
            foreach (var liste in this.kolonlar)
            {
                foreach (var item in liste)
                {
                    if(item.Başlık == silinecekBaslik){
                        // Kart bulunur ise:
                        Console.WriteLine("Bulunan Kart Bilgileri:");
                        Console.WriteLine("**************************************");
                        Console.WriteLine("Başlık      : {0}",item.Başlık);
                        Console.WriteLine("İçerik      : {0}",item.İçerik);
                        Console.WriteLine("Atanan Kişi : {0}",item.ID1);
                        Console.WriteLine("Büyüklük    : {0}",item.Buyukluk1);
                        Console.WriteLine("Line        : {0}",KolonAdları[listeno]); 

                        Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:"); 
                        Console.WriteLine("(1) TODO");
                        Console.WriteLine("(2) IN PROGRESS");
                        Console.WriteLine("(3) DONE");
                        if(!CS.AralıktaTamsayıGirilsin(1,3,"",out int secim)){return false;};
                        BoardaKartEkle(new Kart(item.Başlık,item.İçerik,item.ID1,item.Buyukluk1),secim-1,false);
                        string silinenkartbasligi = item.Başlık;
                        liste.Remove(item);
                        this.BoardlarıListele(false);

                        Console.WriteLine("{0} kartı taşındı, devam etmek için ENTER 'a basın.", silinenkartbasligi);
                        Console.ReadLine();
                        return true;
                    }
                }
                listeno++;
            }
            
            // Kart bulunamaz ise:
            Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* İşlemi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için : (2)");
            if(!CS.AralıktaTamsayıGirilsin(1,2,"",out int n)){return false;}
            {
                if(n==2){KartTaşı();}
                else if (n==1){Console.WriteLine("İşlem sonlandırıldı.");}
                else{Console.WriteLine("Hatalı bir seçim yaptınız!");}
            }
            return false;
        }
        public void BoardlarıListele(bool bilginotu){
        int i=0;
            foreach (var liste in this.kolonlar)
            {
                Console.WriteLine("{0} Line",KolonAdları[i]);
                Console.WriteLine("************************");
                int j=0; 
                if (liste.Count>0){
                    foreach (var item in liste){
                        item.KartıKonsolaYazdir();
                        j++;
                    }
                }
                Console.WriteLine("{0} kolonunda {1} adet kart listelendi.", KolonAdları[i], j);                 
                i++;
            }

            if (bilginotu){
            Console.WriteLine("Board listelendi, devam etmek için ENTER 'a basın.");
            Console.ReadLine();
            }
        }
    }
}
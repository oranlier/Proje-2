using System;
using System.Collections.Generic;
namespace Proje_2
{
    public static class CS{
        
        public static Dictionary<int, string> TakımÜyeleri = new Dictionary<int, string>(){{1,"Ali"},{2,"Veli"},{3,"Ayşe"},{4,"Fatma"},{5,"Zeynep"}};
        
        public static bool BirStringGir(string str,out string str2){
            Console.WriteLine(str);
            str2=Console.ReadLine().Trim();
                if (str2.Trim()==""){
                Console.WriteLine("Hatalı bir değer girdiniz. İşlem sonlandırıldı.");
                return false;
                }
            return true;
        }

        public static bool AralıktaTamsayıGirilsin(int KucukTamsayı,int BuyukTamsayı,string str,out int n)
        {
            if (str !=""){Console.WriteLine(str);}

            int.TryParse(Console.ReadLine(),out n);
            if (n!<KucukTamsayı || n!>BuyukTamsayı) {
                Console.WriteLine("Hatalı bir değer girdiniz. İşlem sonlandırıldı.");
                return false;
            }
            else{
                return true;
            }
            
            
        }
    }
}
using System;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace S01_Parallel

{
    class Program
    {
        static void Main(string[] args)
        {
            int soluongDuLieu = 60;
            int [] dsDuLieu = new int[soluongDuLieu];

            int MaxTT;
            int slSongSong = 3;
            int[] MaxLocal = new int[slSongSong];
            int i;
            Random rd = new Random();

            // khoi tao DATA ban dau
            Console.Write("\n Khoi tao DATA!", soluongDuLieu);
            for (i = 0; i < soluongDuLieu; i++)
            {
                dsDuLieu[i] = rd.Next();
            }    
            for (i = 0; i < soluongDuLieu; i++)
            {
                Console.Write("\t" + dsDuLieu[i]);
            }

            MaxTT = dsDuLieu[0];
            for (i = 1; i < soluongDuLieu; i++)
            {
                if (MaxTT < dsDuLieu[i])
                {
                    MaxTT = dsDuLieu[i];
                }    
            }
            Console.Write("\n\t MAXTT = " + MaxTT);

            // CODE song song - Parallel
            Parallel.For(0, slSongSong,
                mayI =>
                {
                    int bd, kt;

                    //Chia viec
                    bd = mayI * (soluongDuLieu / slSongSong);
                    kt = (mayI + 1) * (soluongDuLieu / slSongSong);

                    // Thuc hien cv theo tung MAY
                    MaxLocal[mayI] = dsDuLieu[bd];
                    for (int j = bd; j < kt; j++)
                    {
                        if (MaxLocal[mayI] < dsDuLieu[j])
                        {
                            MaxLocal[mayI] = dsDuLieu[j];
                        }
                    }
                }
                );
            // Tong hop ket qua !
            int MaxSS = MaxLocal[0];
            for (i = 1; i < slSongSong; i++)
            {
                if (MaxSS < MaxLocal[i])
                {
                    MaxSS = MaxLocal[i];
                }
            }
            Console.WriteLine("\n\t MAXSS = " + MaxSS);

        }
    }
}

using System;
using System.IO;

namespace tax
{
    class MainClass
    {
        

        public static void Main(string[] args)
        {
            //var income = 100000;
            //var tax = 0;
            double[] taxRate = new[] { 10.0 , 12.0, 22.0, 24.0, 32.0, 35.0, 37.0 };
            double[] brackets = new[] { 19050.0, 77400.0, 165000.0, 315000.0, 400000.0, 600000.0, 1000000.0 };
            string [] sum  = new string [taxRate.Length];

            for (int i = 0; i < taxRate.Length ;i++){
                
                sum[i] = taxRate[i].ToString() + ","
                                   + brackets[i].ToString();
                
            }


            File.WriteAllLines("tax.csv",sum);
            Console.WriteLine("have writeen file");
        }
    }
}

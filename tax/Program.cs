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
            double[] brackets = new[] { 0.0 , 19050.0, 77400.0, 165000.0, 315000.0, 400000.0, 600000.0, 1000000.0 };
            string [] sum  = new string [taxRate.Length];
            double[] cumulativeTax = new double[taxRate.Length];

            cumulativeTax[0] = 0.0;

            for (int i = 0; i < taxRate.Length ;i++){

                if(i>0){
                    
                cumulativeTax[i] = taxRate[i] * .01 * (brackets[i + 1] - brackets[i]) + cumulativeTax[i];
                    
                }

                
                sum[i] = taxRate[i].ToString() + ","
                                   + brackets[i].ToString() + ","
                                   + cumulativeTax[i].ToString();;
                
            }


            File.WriteAllLines("tax.csv",sum);
            Console.WriteLine("have writeen file");
        }
    }
}

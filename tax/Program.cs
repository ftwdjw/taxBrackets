using System;
using System.IO;

namespace tax
{
    class MainClass
    {
        

        public static void Main(string[] args)
        {
            var income = 100000.0;
            var tax = 0.0;
            double[] taxRate = new[] { 10.0 , 12.0, 22.0, 24.0, 32.0, 35.0, 37.0 };
            double[] brackets = new[] { 0.0 , 19050.0, 77400.0, 165000.0, 315000.0,
                400000.0, 600000.0, 1000000.0 };
            
            string [] sum  = new string [taxRate.Length];
            double[] cumulativeTax = new double[taxRate.Length];
            bool FindTaxBracket = true;

            int i = 0, saveBracket=0;

            cumulativeTax[0] = 0.0;


            //generate cumulative tax table and save to output array for csv file

            for ( i = 0; i < taxRate.Length ;i++){

                if(i>0){
                    
                cumulativeTax[i] = taxRate[i-1] * .01 * (brackets[i] - brackets[i-1]) 
                                                  + cumulativeTax[i-1];
                    
                }

                
                sum[i] = taxRate[i].ToString() + ","
                                   + brackets[i].ToString() + ","
                                   + cumulativeTax[i].ToString();;
                
            }


            //find tax table
            i = 0;

            while(FindTaxBracket){
                if(income>brackets[i] && income<brackets[i+1]){
                    saveBracket = i;
                    FindTaxBracket = false;
                }
                i++;
            }

            tax = cumulativeTax[saveBracket] + (income - brackets[saveBracket]) * taxRate[saveBracket];

            Console.WriteLine("income="+income);
            Console.WriteLine("tax Bracket=" + brackets[saveBracket]+"to"+brackets[saveBracket+1]);
            Console.WriteLine("tax rate=" + taxRate[saveBracket]);
            Console.WriteLine("tax =" + tax);

            File.WriteAllLines("tax.csv",sum);
            Console.WriteLine("have written file");
        }
    }
}

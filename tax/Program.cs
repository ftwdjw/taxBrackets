using System;
using System.IO;

namespace tax
{
    class MainClass
    {
        

        public static void Main(string[] args)
        {
            var income = 120000.0;
            var tax = 0.0;
            double[] taxRate = new[] { 10.0 , 12.0, 22.0, 24.0, 32.0, 35.0, 37.0 };
            double[] brackets = new[] { 0.0 , 19050.0, 77400.0, 165000.0, 315000.0,
                400000.0, 600000.0, 1000000.0 };

            //used to print file with WriteAllLines
            
            string [] outputArray  = new string [taxRate.Length+10];

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

                
                outputArray[i] = taxRate[i].ToString() + ","
                                   + brackets[i].ToString() + ","
                                   + cumulativeTax[i].ToString();
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

            double deltaToMin = (income - brackets[saveBracket]);

            tax =  (deltaToMin * taxRate[saveBracket] * .01) + cumulativeTax[saveBracket];

            //write to console

            Console.WriteLine("income = {0:C}", income);

            Console.WriteLine("tax Bracket = {0:C} to {1:C}" , brackets[saveBracket]
                              , brackets[saveBracket+1]);

            Console.WriteLine("tax rate = {0:#}%" , taxRate[saveBracket]);

            Console.WriteLine("income delta to min bracket = {0:C}" , deltaToMin);

            Console.WriteLine("cumulative Tax = {0:C}" , cumulativeTax[saveBracket]);

            Console.WriteLine("tax = {0:C}" , tax);

            //write to output csv file for exel in bin directory


                
            outputArray[taxRate.Length + 1] = "income" + "," + income.ToString() ;

            outputArray[taxRate.Length + 2] = "tax bracket" + ","
                + brackets[saveBracket].ToString() + "to" 
                                       + brackets[saveBracket + 1].ToString();

            outputArray[taxRate.Length + 3] = "tax Rate" + "," 
                + taxRate[saveBracket].ToString();

            outputArray[taxRate.Length + 4] = "tax " + "," + tax.ToString();


            File.WriteAllLines("tax.csv",outputArray);
            Console.WriteLine("have written csv file in bin directory");
        }
    }
}

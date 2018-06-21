using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FiguresInWords
{
    public class Figures
    {
        long input;
        string[,] array = {{"", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" },
            { "десять", "одинадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать","семнадцать", "восемнадцать", "девятнадцать" },
        { "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" },
        {"", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот","восемьсот", "девятьсот"},
        { "", "одна", "две", "", "", "", "", "","", "" } };

        string[] rang = {"тысяч", "миллион","миллиард", "триллион", "квадриллион","квинтиллион"};

        List<long> digits = new List<long>();
        List<long> digitsTmp = new List<long>();

        public void Display(long number)
        {
            string finalResult ="";
            if(number == 0)
            {
                Console.WriteLine("Ноль");
            }
            else if(number < 1000)
            {
                Console.WriteLine(threeDigit(number));
            }   
            else if(number > 999)
            {
                SplitNumber(number);
                int i = digits.Count - 2; ;
                for (int j = 0; j < digits.Count; j++)
                {
                    if (i >= 0)
                    {                        
                        finalResult += threeDigit(digits[j]) + " " + setRange(digits[j], i) + " ";
                    }
                    else 
                    {
                        finalResult += threeDigit(digits[j]);
                    }
                    
                    i--;
                }
                finalResult = finalResult.Replace("один тысяч", "одна тысяч").Replace("два тысячи", "две тысячи");
                Console.WriteLine(finalResult);
            }
        }

        public string setRange(long number, int i)
        {
            string rangEnd = "";

            if (i == 0&&number!=0)
            {
                if (number % 10 > 1 && number % 10 < 5)
                {
                    rangEnd = rang[i] + "и";
                }
                else if (number % 10 == 1)
                {
                    rangEnd = rang[i] + "a";
                }
                else rangEnd = rang[i] + "";
            }
            else if (number != 0)
            {
                if ((number % 10 > 1 && number % 10 < 5) && !(number % 100 > 10 && number % 100 < 20))
                {
                    rangEnd = rang[i] + "а";
                }
                else if (number % 10 != 1)
                {
                    rangEnd = rang[i] + "ов";
                }
                else
                {
                    rangEnd = rang[i] + "";
                }
            }            

            return rangEnd;
        }

        public string threeDigit(long number)
        {
            long hundreds, dozens;
            string result = "";

            if (number > 99)
            {
                hundreds = number / 100;
                result += array[3, hundreds];
                number %= 100;
                
                if(number>9 && number < 20)
                {
                    dozens = number % 10;
                    result += " " + array[1, dozens];
                }
                else if (number > 19)
                {
                    dozens = number / 10;
                    result += " " + array[2, dozens];
                    number %= 10;
                    result += " " + array[0, number];
                }
                else if (number < 10)
                {
                    result += " " + array[0, number];
                }
            }
            else if(number < 100 && number > 9 )
            {
                if (number > 9 && number < 20)
                {
                    dozens = number % 10;
                    result += " " + array[1, dozens];
                }
                else if (number > 19)
                {
                    dozens = number / 10;
                    result += " " + array[2, dozens];
                    number %= 10;
                    result += " " + array[0, number];
                }
                
            }
            else if(number < 10)
            {
                 result += " " + array[0, number];
            }
            return result;
        }
        

        public void SplitNumber(long num)
        {
            while (num > 0)
            {
                digitsTmp.Add(num % 1000);
                num /= 1000;
            }
            for(int j = digitsTmp.Count-1; j>=0; j--)
            {
                digits.Add(digitsTmp[j]);
            }

        }

        public long Input()
        {
            
            string str = Console.ReadLine();
            if (!Int64.TryParse(str, out input))
            {
                Console.WriteLine("Введен неправильный формат!\n Введите повторно.");
                Input();
            }

            return input;
        }

      

    }
}

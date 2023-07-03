using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCF77.Analyse
{
    internal class DCF77Analyse
    {
        
        public void PrintData(string csvBits)
        {
            string[] datas;
            if (csvBits.Contains(";"))
            {
                datas = csvBits.Split(';');
            }
            else
            {
                datas = (from b in csvBits.ToCharArray()
                                select b.ToString()).ToArray();
            }


            bool calc = false;
            int countN = 1;
            int result = 0;

            for (int i = 0; i < datas.Length; i++)
            {

                Console.WriteLine($"Bit_{i.ToString().PadLeft(2)}:{datas[i]}");

                calc = Check(i, out string dataName);

                if (calc && datas[i] == "1")
                {
                    result += countN;
                }

                if (calc)
                {
                    countN = UpdateCountN(countN);
                }

                if(dataName != string.Empty)
                {
                    Console.WriteLine($"\t\t{dataName}: {result}" );
                    result = 0;
                    countN = 1;
                }
            }

        }


        private int UpdateCountN(int countN)
        {
            if(countN < 8)
            {
                countN = countN << 1;
            } 
            else if(countN == 8)
            {
                countN = 10;
            }
            else if (countN == 10)
            {
                countN = 20;
            }
            else if (countN == 20)
            {
                countN = 40;
            }

            return countN;
        }

        private bool Check(int i, out string dataName)
        {
            dataName = string.Empty;
            // Minutes
            if (i >= 21 && i< 27)
            {
                return true;
            }
            else if (i == 27)
            {
                dataName = "Minutes";
                return true;
            }

            // Hour
            if (i >= 29 && i < 34)
            {
                return true;
            }
            else if (i == 34)
            {
                dataName = "Hour";
                return true;
            }

            //Kalendertag
            if (i >= 36 && i < 41)
            {
                return true;
            }
            else if (i == 41)
            {
                dataName = "Kalendertag";
            }

            // Wochentag
            if (i >= 42 && i < 44)
            {
                return true;
            }
            if (i == 44)
            {
                dataName = "Wochentag";
                return true;
            }

            // Kalendermonat
            if (i >= 45 && i < 49)
            {
                return true;
            }
            if (i == 49)
            {
                dataName = "Kalendermonat";
                return true;
            }

            // Kalenderjahr
            if (i >= 50 && i < 57)
            {
                return true;
            }
            if (i == 57)
            {
                dataName = "Kalenderjahr";
                return true;
            }


            return false;
        }
    }

    /*
     * 
     * if(i == 0)
                {

                } else if(i == 17)
                {
                    Console.WriteLine("\nSommer- oder Winterzeit:");
                }
                else if (i == 21)
                {
                    Console.WriteLine("\nMinutes (ones):");
                }
                else if (i == 25)
                {
                    Console.WriteLine("\nMinutes (tens):");

                }
                else if (i == 28)
                {
                    Console.WriteLine("\nParity of Minutes:");

                }
                else if (i == 29)
                {
                    Console.WriteLine("\nHour (ones):");

                }
                else if (i == 33)
                {
                    Console.WriteLine("\nHour (tens):");

                }
                else if (i == 35)
                {
                    Console.WriteLine("\nParity of hour:");

                }
                else if (i == 36)
                {
                    Console.WriteLine("\nDay of the month (ones):");

                }
                else if (i == 40)
                {
                    Console.WriteLine("\nDay of the month (tens):");

                }
                else if (i == 42)
                {
                    Console.WriteLine("\nDay of the week:");

                }
                else if (i == 45)
                {
                    Console.WriteLine("\nMonth (ones):");

                }
                else if (i == 49)
                {
                    Console.WriteLine("\nMonth (tens):");

                }
                else if (i == 50)
                {
                    Console.WriteLine("\nYear (ones):");

                }
                else if (i == 1)
                {
                    Console.WriteLine("\n:");

                }
     */
}

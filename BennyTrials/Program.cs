using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BennyTrials
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2020, 11, 25);
            DateTime date2 = new DateTime(2020, 12, 12);


            TimeSpan diff1 = date2 - date1;

            Console.WriteLine(diff1);
            Console.ReadLine();


            bool isTrue = true;
            if(diff1 < Datetime.Now)
            {
                isTrue = true;
            }
            else
            {
                isTrue = false;
            }

        }
    }
}

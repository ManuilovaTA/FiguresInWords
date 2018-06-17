using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresInWords
{
    class Program
    {

        static void Main(string[] args)
        {
            Figures figures = new Figures();

            Console.WriteLine("Enter number!");
            figures.Display(figures.Input());

            Console.ReadKey();
        }
            
    }
}


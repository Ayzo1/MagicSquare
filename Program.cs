using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquare
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 0;
            while (true)
            {
                Console.WriteLine("Введите размерность от 3");
                size = Convert.ToInt32(Console.ReadLine());
                if (size > 2) break;
            }

            var magicSquare = new MagicSquare(size);
            var matrix = magicSquare.Square;


            for (var a = 0; a < size; a++)
            {
                for (var j = 0; j < size; j++)
                {
                    Console.Write(matrix[a, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}

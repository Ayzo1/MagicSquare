using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSquare
{
    class MagicSquare
    {
        public int[,] Square { get; }
        public int Size { get; }

        public MagicSquare(int size)
        {
            Size = size;
            Square = new int[size, size];

            if (size % 2 != 0)
                CreateOddSquare(0, 0, 0, size * size, size);

            if (size % 2 == 0 && size % 4 != 0)
                CreateSingleEvenSquare();

            if (size % 4 == 0)
                CreateDoubleEvenSquare();
        }

        private void CreateDoubleEvenSquare()
        {
            var number = 1;
            for (var i = 0; i < Size; i++)
            {
                var flag = true;
                if (i + Size / 4 + 1 > Size || i - Size / 4 < 0) flag = false;

                for (var j = 0; j < Size; j++)
                {
                    if (!flag)
                    {
                        if (j + Size / 4 + 1 > Size || j - Size / 4 < 0)
                            Square[i, j] = number;
                    }
                    else
                    {
                        if (j >= Size / 4 && j < Size - Size / 4)
                            Square[i, j] = number;
                    }
                    number++;
                }
            }
            number--;
            for (var i = 0; i < Size; i++)
                for (var j = 0; j < Size; j++)
                {
                    if (Square[i, j] == 0) Square[i, j] = number;
                    number--;
                }
        }

        private void CreateSingleEvenSquare()
        {
            var quarterNumbers = (Size / 2) * (Size / 2);
            var halfSize = (Size / 2);
            CreateOddSquare(0, 0, 0, quarterNumbers, halfSize);
            CreateOddSquare((Size / 2), 0, quarterNumbers * 2, quarterNumbers * 3, halfSize);
            CreateOddSquare(0, halfSize, quarterNumbers * 4 - quarterNumbers, quarterNumbers * 4, halfSize);
            CreateOddSquare(halfSize, halfSize, quarterNumbers, quarterNumbers * 2, halfSize);

            var median = halfSize / 2;

            for (var i = 0; i < halfSize; i++)
            {
                var x = 0;
                if (i % 2 != 0) x = median;
                var maxLength = x + median;
                for (; x < maxLength; x++)
                {
                    var temp = Square[i, x];
                    Square[i, x] = Square[i + halfSize, x];
                    Square[i + halfSize, x] = temp;
                }
            }
        }

        private void CreateOddSquare(int startX, int startY, int start, int end, int size)
        {
            var x = startX + size / 2;
            var y = startY;
            Square[startY, x] = start + 1;

            for (var i = start + 2; i < end + 1; i++)
            {
                var previousX = x;
                var previousY = y;
                x++;
                y--;

                if (x > startX + size - 1) x = x - size;
                if (y < startY) y = y + size;
                if (Square[y, x] > 0)
                {
                    Square[previousY + 1, previousX] = i;
                    x = previousX;
                    y = previousY + 1;
                }
                else Square[y, x] = i;
            }
        }
    }
}

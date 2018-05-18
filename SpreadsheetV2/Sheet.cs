using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetV2
{
    public class Sheet
    {
        public string[,] _printArr = null;          //Store the array of strings to print (two-dimensional array)

        public void PrintTable()
        {
            if (_printArr == null)
            {
                throw new Exception("Table not yet created!");
            }

            int arrBound1 = _printArr.GetUpperBound(0);
            int arrBound2 = _printArr.GetUpperBound(1);
            for (int j = 0; j <= arrBound2; j++)
            {
                for (int i = 0; i <= arrBound1; i++)
                {
                    string printValue = _printArr[i, j];
                    Console.Write(printValue);
                }
            }
        }
    }
}

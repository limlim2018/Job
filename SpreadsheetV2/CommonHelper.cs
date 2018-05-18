using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetV2
{
    public enum CommandType
    {
        Create = 0,           //Create Table
        SetNumber = 1,        //Set Number
        Sum = 2,              //Sum
        Quit = 3              //Quit
    }

    public static class CommonHelper
    {
        public const string DNum = @" (\d{1,3})";
        public const int NUM_LENGTH = 4;
        public const string BORDER_VER = "|";
        public const string BORDER_HOR = "-";
        public const string STR_EMPTY = " ";
        public const string STR_NEWLINE = "\n";
        public const int MAX_NUMBER = 999;
        public static int TryParseInt(string input)
        {
            int value;
            if(!Int32.TryParse(input,out value))
            {
                throw new Exception("不是一个合法的整数!");
            }
            return value;
        }

        /// <summary>
        /// GetAllCommandTypes
        /// </summary>
        /// <returns></returns>
        public static Type[] GetAllCommandTypes()
        {
            var type = typeof(ICommand);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(s => s.GetTypes())
                            .Where(p => !p.IsAbstract && type.IsAssignableFrom(p)).ToArray();
            return types;
        }

        /// <summary>
        /// Check Index
        /// </summary>
        /// <param name="x">X Pos</param>
        /// <param name="y">Y Pos</param>
        /// <param name="printArr"></param>
        /// <returns></returns>
        public static bool CheckIndex(int x, int y,string[,] printArr)
        {
            if ((x <= printArr.GetUpperBound(0) && x >= 0) &&
                (y <= printArr.GetUpperBound(1) && y >= 0))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get A Number Value From Position
        /// </summary>
        /// <param name="x">x coordinates</param>
        /// <param name="y">y coordinates</param>
        public static int GetNumberValue(int x, int y,string[,] printArr)
        {
            int xPos = (x - 1) * CommonHelper.NUM_LENGTH;

            if (!CommonHelper.CheckIndex(xPos + 1, y, printArr) ||
                !CommonHelper.CheckIndex(xPos + 2, y, printArr) ||
                !CommonHelper.CheckIndex(xPos + 3, y, printArr))
            {
                throw new Exception("Please enter a valid subscript.");
            }

            string value = printArr[(x - 1) * NUM_LENGTH + 1, y] +
                            printArr[(x - 1) * NUM_LENGTH + 2, y] +
                            printArr[(x - 1) * NUM_LENGTH + 3, y];
            int iValue;
            if (!Int32.TryParse(value, out iValue))
            {
                throw new Exception("Type conversion failure must be a valid integer.");
            }
            return iValue;
        }

        /// <summary>
        /// Set Number Value
        /// </summary>
        /// <param name="x">X Pos</param>
        /// <param name="y">Y Pos</param>
        /// <param name="value">value</param>
        /// <param name="printArr"></param>
        public static void SetNumberValue(int x, int y, int value,string[,] printArr)
        {
            if (printArr == null)
            {
                throw new Exception("Please Create Table First!");
            }

            if (value > CommonHelper.MAX_NUMBER)
            {
                throw new Exception("Only three integers are supported!");
            }

            int hundreds = value / 100;
            int decade = value / 10 - hundreds * 10;
            int unit = value % 10;

            int xPos = (x - 1) * CommonHelper.NUM_LENGTH;

            if (!CommonHelper.CheckIndex(xPos + 1, y, printArr) ||
                !CommonHelper.CheckIndex(xPos + 2, y, printArr) ||
                !CommonHelper.CheckIndex(xPos + 3, y, printArr))
            {
                throw new Exception("Please enter a valid subscript.");
            }

            //Clear Data
            printArr[xPos + 1, y] = CommonHelper.STR_EMPTY;
            printArr[xPos + 2, y] = CommonHelper.STR_EMPTY;
            printArr[xPos + 3, y] = CommonHelper.STR_EMPTY;

            if (hundreds > 0)
            {
                printArr[(x - 1) * CommonHelper.NUM_LENGTH + 1, y] = hundreds.ToString();
            }

            if (decade > 0 || (decade == 0 && value > 99))
            {
                printArr[(x - 1) * CommonHelper.NUM_LENGTH + 2, y] = decade.ToString();
            }

            if (unit >= 0)
            {
                printArr[(x - 1) * CommonHelper.NUM_LENGTH + 3, y] = unit.ToString();
            }
        }
    }
}

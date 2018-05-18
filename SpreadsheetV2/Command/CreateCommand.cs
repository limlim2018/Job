using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpreadsheetV2
{
    public class CreateCommand : ICommand
    {
        public int width { get; set; }
        public int height { get; set; }

        public CommandType CmdType
        {
            get
            {
                return CommandType.Create;
            }
        }

        private Regex _reg = new Regex(@"[cC]" + CommonHelper.DNum + CommonHelper.DNum);

        private Sheet _sheet;

        public CreateCommand(Sheet sheet)
        {
            this._sheet = sheet;
        }

        public bool ExecuteCmd()
        {
            if ((width < 1) || (height < 3))
            {
                throw new Exception("The table width and height should be at least 3.");
            }
            
            int actualWidth = width * CommonHelper.NUM_LENGTH + 2;
            int actualHeight = height + 2;
            this._sheet._printArr = new string[actualWidth, actualHeight];

            int arrBound1 = this._sheet._printArr.GetUpperBound(0) + 1;
            int arrBound2 = this._sheet._printArr.GetUpperBound(1) + 1;

            for (int i = 0; i < arrBound1; i++)
            {
                for (int j = 0; j < arrBound2; j++)
                {

                    if ((j == 0 && i != arrBound1 - 1) || (j == arrBound2 - 1 && i != arrBound1 - 1))
                    {
                        this._sheet._printArr[i, j] = CommonHelper.BORDER_HOR;
                    }
                    else if ((i == 0 && j != 0) || (i % CommonHelper.NUM_LENGTH == 0) && i != 0)
                    {
                        this._sheet._printArr[i, j] = CommonHelper.BORDER_VER;
                    }
                    else if (i == arrBound1 - 1)
                    {
                        this._sheet._printArr[i, j] = CommonHelper.STR_NEWLINE;
                    }
                    else
                    {
                        this._sheet._printArr[i, j] = CommonHelper.STR_EMPTY;
                    }
                }
            }

            //print table
            this._sheet.PrintTable();

            return true;
        }

        public bool AnalysisCmd(string input)
        {
            var match = _reg.Match(input);
            if (!match.Success || (input.Split(' ').Length != 3))
            {
                return false;
            }
            width = CommonHelper.TryParseInt(match.Groups[1].Value);
            height = CommonHelper.TryParseInt(match.Groups[2].Value);

            if ((width < 1) || (height < 3))
            {
                return false;
            }

            return true;
        }
    }
}

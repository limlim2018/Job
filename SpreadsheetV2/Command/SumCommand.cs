using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpreadsheetV2
{
    public class SumCommand : ICommand
    {
        public int x1 { get; set; }
        public int y1{ get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
        public int x3 { get; set; }
        public int y3 { get; set; }

        public CommandType CmdType
        {
            get
            {
                return CommandType.Sum;
            }
        }

        private Regex _reg = new Regex(@"[sS]" + CommonHelper.DNum +
                    CommonHelper.DNum + CommonHelper.DNum + CommonHelper.DNum +
                    CommonHelper.DNum + CommonHelper.DNum);

        private Sheet _sheet;

        public SumCommand(Sheet sheet)
        {
            this._sheet = sheet;
        }

        public bool ExecuteCmd()
        {
            if(this._sheet._printArr==null)
            {
                throw new Exception("Please Creaet Table First!");
            }

            int iValue1 = CommonHelper.GetNumberValue(x1, y1,this._sheet._printArr);
            int iValue2 = CommonHelper.GetNumberValue(x2, y2, this._sheet._printArr);
            int sum = iValue1 + iValue2;
            if (sum > 999)
            {
                throw new Exception("Overflow, the result of the sum must be between 0 and 1000.");
            }
            CommonHelper.SetNumberValue(x3, y3, sum, this._sheet._printArr);

            this._sheet.PrintTable();

            return true;
        }

        public bool AnalysisCmd(string input)
        {
            var match = _reg.Match(input);
            if (!match.Success || (input.Split(' ').Length != 7))
            {
                return false;
            }
            x1 = CommonHelper.TryParseInt(match.Groups[1].Value);
            y1 = CommonHelper.TryParseInt(match.Groups[2].Value);
            x2 = CommonHelper.TryParseInt(match.Groups[3].Value);
            y2 = CommonHelper.TryParseInt(match.Groups[4].Value);
            x3 = CommonHelper.TryParseInt(match.Groups[5].Value);
            y3 = CommonHelper.TryParseInt(match.Groups[6].Value);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpreadsheetV2
{
    public class SetNumCommand : ICommand
    {
        public int x { get; set; }
        public int y { get; set; }
        public int v { get; set; }

        public CommandType CmdType
        {
            get
            {
                return CommandType.SetNumber;
            }
        }

        private Regex _reg = new Regex(@"[nN]" + CommonHelper.DNum + CommonHelper.DNum + CommonHelper.DNum);


        private Sheet _sheet;

        public SetNumCommand(Sheet sheet)
        {
            this._sheet = sheet;
        }


        public bool ExecuteCmd()
        {
            CommonHelper.SetNumberValue(x, y, v,this._sheet._printArr);
            this._sheet.PrintTable();
            return true;
        }

        public bool AnalysisCmd(string input)
        {
            var match = _reg.Match(input);
            if (!match.Success || (input.Split(' ').Length != 4))
            {
                return false;
            }
            x = CommonHelper.TryParseInt(match.Groups[1].Value);
            y = CommonHelper.TryParseInt(match.Groups[2].Value);
            v = CommonHelper.TryParseInt(match.Groups[3].Value);
            return true;
        }
    }
}

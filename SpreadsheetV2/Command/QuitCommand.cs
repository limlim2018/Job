using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetV2
{
    public class QuitCommand : ICommand
    {
        public CommandType CmdType
        {
            get
            {
                return CommandType.Quit;
            }
        }

        private Sheet _sheet;

        public QuitCommand(Sheet sheet)
        {
            this._sheet = sheet;
        }

        public bool AnalysisCmd(string input)
        {
            string[] arr = input.Split(' ');
            if(arr[0].ToUpper()=="Q")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExecuteCmd()
        {
            return true;
        }
    }
}

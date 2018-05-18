using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SpreadsheetV2
{
    public interface ICommand
    {
        bool ExecuteCmd();
        CommandType CmdType { get; }
        bool AnalysisCmd(string input);
    }
}

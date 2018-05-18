using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpreadsheetV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SpreadsheetV2.Tests
{
    [TestClass()]
    public class QuitCommandTest
    {
        [TestMethod()]
        public void AnalysisCmdAnalysisCmd_Test()
        {
            Sheet sheet = new Sheet();
            QuitCommand cmd = new QuitCommand(sheet);

            bool result = cmd.AnalysisCmd("Qtt 1");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("N 1 1");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("Q");
            Assert.AreEqual(result, true);

            Console.WriteLine("Test Complete");
        }

        [TestMethod()]
        public void ExecuteCmd_Test()
        {
            Sheet sheet = new Sheet();
            QuitCommand cmd = new QuitCommand(sheet);

            bool result = cmd.AnalysisCmd("Q");
            Assert.AreEqual(result, true);

            result = cmd.ExecuteCmd();
            Assert.AreEqual(result, true);
        }
    }
}

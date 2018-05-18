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
    public class CreateCommandTest
    {
        [TestMethod()]
        public void AnalysisCmdAnalysisCmd_Test()
        {
            Sheet sheet = new Sheet();
            CreateCommand cmd = new CreateCommand(sheet);

            bool result = cmd.AnalysisCmd("C 0 1");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("D 3 3");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("N 3 3");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("C 3 3");
            Assert.AreEqual(result, true);

            Assert.AreEqual(cmd.CmdType, CommandType.Create);
            Assert.AreEqual(cmd.width, 3);
            Assert.AreEqual(cmd.height, 3);

            result = cmd.AnalysisCmd("c 5 6");
            Assert.AreEqual(result, true);

            Assert.AreEqual(cmd.CmdType, CommandType.Create);
            Assert.AreEqual(cmd.width, 5);
            Assert.AreEqual(cmd.height, 6);

            Console.WriteLine("Test Complete");
        }

        [TestMethod()]
        public void ExecuteCmd_Test()
        {
            Sheet sheet = new Sheet();
            CreateCommand cmd = new CreateCommand(sheet);

            bool result = cmd.AnalysisCmd("C 3 3");
            Assert.AreEqual(result, true);
            Assert.AreEqual(cmd.CmdType, CommandType.Create);
            Assert.AreEqual(cmd.width, 3);
            Assert.AreEqual(cmd.height, 3);

            result = cmd.ExecuteCmd();
            Assert.AreEqual(result, true);
            Assert.AreEqual(sheet._printArr.GetLength(0), 3*CommonHelper.NUM_LENGTH+2);
            Assert.AreEqual(sheet._printArr.GetLength(1), 3+2);

            Console.WriteLine("Test Complete");
        }
    }
}
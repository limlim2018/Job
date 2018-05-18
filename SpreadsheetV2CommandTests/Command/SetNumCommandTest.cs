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
    public class SetNumCommandTest
    {
        [TestMethod()]
        public void AnalysisCmdAnalysisCmd_Test()
        {
            Sheet sheet = new Sheet();
            SetNumCommand cmd = new SetNumCommand(sheet);

            bool result = cmd.AnalysisCmd("N 1 1 2344");
            Assert.AreEqual(result, true);

            result = cmd.AnalysisCmd("D 1 1 2344");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("N 1 1 234");
            Assert.AreEqual(result, true);

            result = cmd.AnalysisCmd("N 1 1 4");
            Assert.AreEqual(result, true);

            result = cmd.AnalysisCmd("N 1 1 10");
            Assert.AreEqual(result, true);

            Console.WriteLine("Test Complete");
        }

        [TestMethod()]
        public void ExecuteCmd_Test()
        {
            bool result = false;
            Sheet sheet = new Sheet();
            CreateCommand createCmd = new CreateCommand(sheet);
            result = createCmd.AnalysisCmd("C 3 3");
            Assert.AreEqual(result, true);
            result = createCmd.ExecuteCmd();
            Assert.AreEqual(result, true);

            SetNumCommand cmd = new SetNumCommand(sheet);

            result = cmd.AnalysisCmd("N 1 3 333");
            Assert.AreEqual(result, true);
            result = cmd.ExecuteCmd();
            Assert.AreEqual(result, true);

            Assert.AreEqual(CommonHelper.GetNumberValue(1, 3, sheet._printArr), 333);

            Console.WriteLine("Test Complete");
        }

        [TestMethod()]
        public void ExecuteCmd_Test_Error1()
        {
            Sheet sheet = new Sheet();
            SetNumCommand cmd = new SetNumCommand(sheet);
            bool result = false;

            try
            {
                result = cmd.AnalysisCmd("N 1 3 333");
                Assert.AreEqual(result, true);
                result = cmd.ExecuteCmd();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Please Create Table First!", ex.Message);
            }
            Console.WriteLine("Test Complete");
        }

        [TestMethod()]
        public void ExecuteCmd_Test_Error2()
        {
            bool result = false;
            Sheet sheet = new Sheet();
            CreateCommand createCmd = new CreateCommand(sheet);
            result = createCmd.AnalysisCmd("C 3 3");
            Assert.AreEqual(result, true);
            result = createCmd.ExecuteCmd();
            Assert.AreEqual(result, true);

            SetNumCommand cmd = new SetNumCommand(sheet);

            try
            {
                result = cmd.AnalysisCmd("N 1 9 333");
                Assert.AreEqual(result, true);
                result = cmd.ExecuteCmd();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Please enter a valid subscript.", ex.Message);
            }
            Console.WriteLine("Test Complete");
        }
    }
}

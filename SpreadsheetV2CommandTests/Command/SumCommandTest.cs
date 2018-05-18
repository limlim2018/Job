using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpreadsheetV2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetV2CommandTests.Command
{
    [TestClass()]
    public class SumCommandTest
    {
        [TestMethod()]
        public void AnalysisCmdAnalysisCmd_Test()
        {
            Sheet sheet = new Sheet();
            SumCommand cmd = new SumCommand(sheet);

            bool result = cmd.AnalysisCmd("N 1 1 2344");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("N 1 1 234");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("S 1 1 12");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("S 1 1 1 2");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("S 1 1 1 2 3");
            Assert.AreEqual(result, false);

            result = cmd.AnalysisCmd("S 1 1 1 2 2 2");
            Assert.AreEqual(result, true);

            Console.WriteLine("Test Complete");
        }

        [TestMethod()]
        public void ExecuteCmd_Test()
        {
            Sheet sheet = new Sheet();
            SumCommand cmd = new SumCommand(sheet);
            bool result = false;

            CreateCommand createCmd = new CreateCommand(sheet);
            result = createCmd.AnalysisCmd("C 3 3");
            Assert.AreEqual(result, true);
            createCmd.ExecuteCmd();
            Assert.AreEqual(result, true);

            SetNumCommand setCmd = new SetNumCommand(sheet);
            result = setCmd.AnalysisCmd("N 1 1 100");
            Assert.AreEqual(result, true);
            result = setCmd.ExecuteCmd();
            Assert.AreEqual(result, true);
            Assert.AreEqual(CommonHelper.GetNumberValue(1, 1, sheet._printArr), 100);

            result = setCmd.AnalysisCmd("N 1 2 200");
            Assert.AreEqual(result, true);
            result = setCmd.ExecuteCmd();
            Assert.AreEqual(result, true);
            Assert.AreEqual(CommonHelper.GetNumberValue(1, 2, sheet._printArr), 200);

            result = cmd.AnalysisCmd("S 1 1 1 2 1 3");
            Assert.AreEqual(result, true);
            result = cmd.ExecuteCmd();
            Assert.AreEqual(result, true);
            Assert.AreEqual(CommonHelper.GetNumberValue(1, 3, sheet._printArr), 300);

            Console.WriteLine("Test Complete");
        }

        [TestMethod()]
        public void ExecuteCmd_Test_Error1()
        {
            Sheet sheet = new Sheet();
            SumCommand cmd = new SumCommand(sheet);
            bool result = false;

            try
            {
                result = cmd.AnalysisCmd("S 1 1 1 2 2 2");
                Assert.AreEqual(result, true);
                result = cmd.ExecuteCmd();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Please Creaet Table First!", ex.Message);
            }
        }

        [TestMethod()]
        public void ExecuteCmd_Test_Error2()
        {
            Sheet sheet = new Sheet();
            SumCommand cmd = new SumCommand(sheet);
            bool result = false;

            try
            {
                result = cmd.AnalysisCmd("S 1 1 1 2 2 2");
                Assert.AreEqual(result, true);
                result = cmd.ExecuteCmd();
            }
            catch(Exception ex)
            {
                Assert.AreEqual("Please Creaet Table First!", ex.Message);
            }

            CreateCommand createCmd = new CreateCommand(sheet);
            result = createCmd.AnalysisCmd("C 3 3");
            Assert.AreEqual(result, true);
            createCmd.ExecuteCmd();
            Assert.AreEqual(result, true);

            SetNumCommand setCmd = new SetNumCommand(sheet);
            result = setCmd.AnalysisCmd("N 1 1 100");
            Assert.AreEqual(result, true);
            result = setCmd.ExecuteCmd();
            Assert.AreEqual(result, true);
            Assert.AreEqual(CommonHelper.GetNumberValue(1, 1, sheet._printArr), 100);

            result = setCmd.AnalysisCmd("N 1 2 200");
            Assert.AreEqual(result, true);
            result = setCmd.ExecuteCmd();
            Assert.AreEqual(result, true);
            Assert.AreEqual(CommonHelper.GetNumberValue(1, 2, sheet._printArr), 200);

            result = cmd.AnalysisCmd("S 1 1 1 2 1 3");
            Assert.AreEqual(result, true);
            result = cmd.ExecuteCmd();
            Assert.AreEqual(result, true);
            Assert.AreEqual(CommonHelper.GetNumberValue(1, 3, sheet._printArr), 300);

            try
            {
                result = cmd.AnalysisCmd("S 1 9 1 2 2 2");
                Assert.AreEqual(result, true);
                result = cmd.ExecuteCmd();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Please enter a valid subscript.", ex.Message);


                Console.WriteLine("Test Complete");
            }
        }
    }
}

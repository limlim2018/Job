using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programming instructions");
            Console.WriteLine("C w h                  Create a table      w:width  h:height");
            Console.WriteLine("N x1 y1 v1             Set a number        x1:X coordinate  y1:X coordinate v1:Value");
            Console.WriteLine("S x1 y1 x2 y2 x3 y3    Sum                 x1,y1:Num1 coordinate x2,y2:Num2 coordinate x3,y3 Sum coordinate");
            Console.WriteLine("Q                      Quit");

            //Create Sheet
            Sheet sheet = new Sheet();

            //Get All Command Types
            var cmdTypes = CommonHelper.GetAllCommandTypes();

            //Command Object
            ICommand cmd;

            while (true)
            {
                DoLoop:

                Console.WriteLine("Enter Command:");
                string cmdText = Console.ReadLine();

                try
                {
                    cmd = null;
                    foreach (var type in cmdTypes)
                    {
                        cmd = (ICommand)Activator.CreateInstance(type, new object[] { sheet });
                        if(cmd.AnalysisCmd(cmdText))
                        {
                            break;
                        }
                        cmd = null;
                    }
                    if(cmd==null)
                    {
                        Console.WriteLine("Command Type Not Support!");
                        goto DoLoop;
                    }
                    
                    if(cmd.CmdType==CommandType.Quit)
                    {
                        break;
                    }
                    else
                    {
                        cmd.ExecuteCmd();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    goto DoLoop;
                }
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPageReader.Process;

namespace WebPageReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //var process = new WebPageReaderProcess();

            //process.StartProcess(args);

            var process2 = new WebPageReaderUsingConsoleInputProcess();

            process2.StartProcess(args);
        }
    }
}

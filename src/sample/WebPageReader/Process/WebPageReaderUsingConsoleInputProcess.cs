using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using MHAT.ConsoleApp.ProcessTemplate;

namespace WebPageReader.Process
{
    public class WebPageReaderUsingConsoleInputProcess :
        BaseReadInputProcessTemplate
    {
        protected override void ProcessLine(string line)
        {
            Output.WriteLine("Getting the page content ...");

            var wc = new WebClient();

            var page = wc.DownloadString(line);

            Output.WriteLine("Getting complete");

            Output.WriteLine("Start process ...");

            Output.WriteLine(page);

            Output.WriteLine("Finish ...");
        }
    }
}
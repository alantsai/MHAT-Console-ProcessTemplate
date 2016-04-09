using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MHAT.ConsoleApp.ProcessTemplate;

namespace WebPageReader.Process
{
    public class WebPageReaderProcess : BaseReadInputProcessTemplate<WebPageReaderOption>
    {
        protected override void PreProcess()
        {
            Output.WriteLine("Getting the page content ...");

            var wc = new WebClient();

            var page = wc.DownloadString(ArugemntOption.Url);

            Input = new StringReader(page);

            Output.WriteLine("Getting complete");

            Output.WriteLine("Start process ...");
        }

        protected override void ProcessLine(string line)
        {
            Output.WriteLine(line);
        }
    }
}

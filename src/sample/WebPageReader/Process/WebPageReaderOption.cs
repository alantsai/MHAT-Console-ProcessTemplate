using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace WebPageReader.Process
{
    public class WebPageReaderOption
    {
        [Option('u', Required = true, HelpText = "Url to download")]
        public string Url { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;

namespace MHAT.ConsoleApp.ProcessTemplate
{
    /// <summary>
    /// Base class for easy create prcoess in console app
    /// </summary>
    /// <typeparam name="TOption">The type of the option class</typeparam>
    public abstract class BaseProcessTemplate<TOption>
        where TOption : new()
    {
        /// <summary>
        /// Gets the error output.
        /// </summary>
        /// <value>
        /// The error output.
        /// </value>
        protected TextWriter ErrorOutput { get; set; }

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <value>
        /// The input.
        /// </value>
        protected TextReader Input { get; set; }

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <value>
        /// The output.
        /// </value>
        protected TextWriter Output { get; set; }

        /// <summary>
        /// Gets or sets the arugemnt option.
        /// </summary>
        /// <value>
        /// The arugemnt option.
        /// </value>
        protected TOption ArugemntOption { get; set; }

        protected string[] Args { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseProcessTemplate" /> class.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <param name="errorOutput">The error output.</param>
        public BaseProcessTemplate(TextReader input = null,
            TextWriter output = null, TextWriter errorOutput = null)
        {
            Input = input ?? System.Console.In;
            Output = output ?? System.Console.Out;
            ErrorOutput = errorOutput ?? System.Console.Error;

            ArugemntOption = new TOption();
        }

        /// <summary>
        /// Action perform before process start
        /// </summary>
        protected virtual void PreProcess()
        {
        }

        /// <summary>
        /// Action perform after process finish
        /// </summary>
        protected virtual void PostProcess()
        {
        }

        /// <summary>
        /// Parses the argument option.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private void ParseArgOption(string[] args)
        {
            Args = args;

            Parser.Default.ParseArgumentsStrict(args, ArugemntOption);
        }

        /// <summary>
        /// Determines whether process can start
        /// Last method entry point before prcoess start running
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsStartProcess()
        {
            return true;
        }

        /// <summary>
        /// Processes the input.
        /// </summary>
        private void ProcessInput()
        {
             var line = Input.ReadLine();

            while (line != null)
            {
                ProcessLine(line);

                line = Input.ReadLine();
            }
        }

        /// <summary>
        /// Processes the line.
        /// </summary>
        /// <param name="line">The line.</param>
        protected virtual void ProcessLine(string line)
        {
        }

        /// <summary>
        /// Start Process
        /// </summary>
        public void Process(string[] args)
        {
            ParseArgOption(args);

            if (IsStartProcess())
            {
                PreProcess();

                ProcessInput();

                PostProcess();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using MHAT.ConsoleApp.ProcessTemplate.Model;

namespace MHAT.ConsoleApp.ProcessTemplate.Base
{
    /// <summary>
    /// Base class for easy create prcoess in console app
    /// This class is internal base class
    /// </summary>
    /// <typeparam name="TOption">The type of the option class</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
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
        protected virtual TOption ArugemntOption { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        protected string[] Args { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseProcessTemplate" /> class.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <param name="errorOutput">The error output.</param>
        internal BaseProcessTemplate(TextReader input = null,
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
        /// Determine whether argument should be parse into class
        /// </summary>
        /// <returns></returns>
        private bool IsCallObjectParse()
        {
            return typeof(TOption) != typeof(EmptyOption);
        }

        /// <summary>
        /// Parses the argument option.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private void ParseArgOption(string[] args)
        {
            Args = args;

            if (IsCallObjectParse())
            {
                Parser.Default.ParseArgumentsStrict(args, ArugemntOption);
            }
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
        protected virtual void Process()
        {
        }

        /// <summary>
        /// Start Process
        /// </summary>
        /// <param name="args">The arguments.</param>
        public void StartProcess(string[] args)
        {
            ParseArgOption(args);

            if (IsStartProcess())
            {
                PreProcess();

                Process();

                PostProcess();
            }
        }
    }
}
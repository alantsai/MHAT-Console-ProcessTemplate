using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MHAT.ConsoleApp.ProcessTemplate
{
    /// <summary>
    /// Base class for easy create prcoess in console app
    /// </summary>
    public abstract class BaseProcessTemplate
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
        }
    }
}
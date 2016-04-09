using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHAT.ConsoleApp.ProcessTemplate.Base;

namespace MHAT.ConsoleApp.ProcessTemplate
{
    /// <summary>
    /// Process template which deal with reading and outputing
    /// Terminate when input is null
    /// </summary>
    /// <typeparam name="TOption">The type of the option.</typeparam>
    /// <seealso cref="MHAT.ConsoleApp.ProcessTemplate.Base.BaseProcessTemplate{TOption}" />
    public abstract class BaseReadInputProcessTemplate<TOption>
        : BaseProcessTemplate<TOption> where TOption : new()
    {
        /// <summary>
        /// Gets or sets a value indicating whether should stop reading input
        /// which means stop process
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is stop reading input; otherwise, <c>false</c>.
        /// </value>
        protected bool IsStopReadingInput { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReadProcessInputTemplate{TOption}"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <param name="errorOutput">The error output.</param>
        public BaseReadInputProcessTemplate(TextReader input = null,
                TextWriter output = null, TextWriter errorOutput = null)
            : base(input, output, errorOutput)
        {
            IsStopReadingInput = false;
        }

        /// <summary>
        /// Start reading input until a null is given
        /// </summary>
        protected sealed override void Process()
        {
            var line = Input.ReadLine();

            while (line != null && IsStopReadingInput == false)
            {
                ProcessLine(line);

                line = Input.ReadLine();
            }
        }

        /// <summary>
        /// Method overrid to process each line
        /// </summary>
        /// <param name="line">The line.</param>
        protected virtual void ProcessLine(string line)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHAT.ConsoleApp.ProcessTemplate
{
    /// <summary>
    /// Process template which deal with reading and outputing
    /// Terminate when input is null
    /// </summary>
    /// <typeparam name="TOption">The type of the option.</typeparam>
    /// <seealso cref="MHAT.ConsoleApp.ProcessTemplate.BaseProcessTemplate{TOption}" />
    public abstract class BaseReadInputProcessTemplate<TOption>
        : BaseProcessTemplate<TOption> where TOption : new()
    {
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
        }

        /// <summary>
        /// Start reading input until a null is given
        /// </summary>
        protected sealed override void Process()
        {
            var line = Input.ReadLine();

            while (line != null)
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

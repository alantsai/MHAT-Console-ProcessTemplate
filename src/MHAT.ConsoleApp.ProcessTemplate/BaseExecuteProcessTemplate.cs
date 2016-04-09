using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHAT.ConsoleApp.ProcessTemplate.Base;

namespace MHAT.ConsoleApp.ProcessTemplate
{
    /// <summary>
    /// Base class to inherit for easy execute non read input
    /// </summary>
    /// <typeparam name="TOption">The type of the option.</typeparam>
    /// <seealso cref="MHAT.ConsoleApp.ProcessTemplate.Base.BaseProcessTemplate{TOption}" />
    public abstract class BaseExecuteProcessTemplate<TOption> :
        BaseProcessTemplate<TOption> where TOption : new()
    {
    }
}

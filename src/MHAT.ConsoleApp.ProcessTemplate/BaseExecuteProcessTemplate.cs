using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHAT.ConsoleApp.ProcessTemplate.Base;
using MHAT.ConsoleApp.ProcessTemplate.Model;

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

    /// <summary>
    /// Base class to inherit for easy execute non read input
    /// This one does not need argument as option
    /// </summary>
    /// <seealso cref="MHAT.ConsoleApp.ProcessTemplate.Base.BaseProcessTemplate{TOption}" />
    public abstract class BaseExecuteProcessTemplate :
         BaseProcessTemplate<EmptyOption>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected sealed override EmptyOption ArugemntOption
        {
            get
            {
                return base.ArugemntOption;
            }

            set
            {
                base.ArugemntOption = value;
            }
        }
    }
}

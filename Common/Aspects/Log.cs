using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Diagnostics;

namespace Common.Aspects
{
    [PSerializable]
    public class Log : OnMethodBoundaryAspect
    {
        /// <summary>
        /// Method executed before the body of methods to which this aspect is applied.
        /// </summary>
        /// <param name="args"></param>
        public override void OnEntry(MethodExecutionArgs args)
        {
            Debug.WriteLine($"{args.Method.DeclaringType.FullName}_{args.Method.Name} - Starting.");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, but
        /// only when the method successfully returns (i.e. when no exception flies out the method.).
        /// </summary>
        /// <param name="args"></param>
        public override void OnSuccess(MethodExecutionArgs args)
        {
            Debug.WriteLine($"{args.Method.DeclaringType.FullName}_{args.Method.Name} - Succeeded.");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, even
        /// when the method exists with an exception (this method is invoked from the finally block).
        /// </summary>
        /// <param name="args"></param>
        public override void OnExit(MethodExecutionArgs args)
        {
            Debug.WriteLine($"{args.Method.DeclaringType.FullName}_{args.Method.Name} - Exited.");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, in
        /// case that the method resulted with an exception.
        /// </summary>
        /// <param name="args"></param>
        public override void OnException(MethodExecutionArgs args)
        {
            Debug.WriteLine($"{args.Method.DeclaringType.FullName}_{args.Method.Name} - Failed.");
        }
    }
}

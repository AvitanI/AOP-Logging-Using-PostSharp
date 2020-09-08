using PostSharp.Aspects;
using PostSharp.Serialization;
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
            args.MethodExecutionTag = Stopwatch.StartNew();

            Debug.WriteLine($"The {args.Method.Name} method has been entered.");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, but
        /// only when the method successfully returns (i.e. when no exception flies out the method.).
        /// </summary>
        /// <param name="args"></param>
        public override void OnSuccess(MethodExecutionArgs args)
        {
            Debug.WriteLine($"The {args.Method.Name} method executed successfully.");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, even
        /// when the method exists with an exception (this method is invoked from the finally block).
        /// </summary>
        /// <param name="args"></param>
        public override void OnExit(MethodExecutionArgs args)
        {
            var sw = (Stopwatch)args.MethodExecutionTag;
            sw.Stop();

            Debug.WriteLine($"The {args.Method.Name} method has exited (total execution time in MS: {sw.ElapsedMilliseconds}).");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, in
        /// case that the method resulted with an exception.
        /// </summary>
        /// <param name="args"></param>
        public override void OnException(MethodExecutionArgs args)
        {
            Debug.WriteLine($"An exception was thrown in {args.Method.Name}.");
        }
    }
}

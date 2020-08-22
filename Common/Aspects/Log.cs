using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Diagnostics;

namespace Common.Aspects
{
    [PSerializable]
    public class Log : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            args.MethodExecutionTag = Stopwatch.StartNew();

            Debug.WriteLine($"The {args.Method.Name} method has been entered.");
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            Debug.WriteLine($"The {args.Method.Name} method executed successfully.");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            var sw = (Stopwatch)args.MethodExecutionTag;
            sw.Stop();

            Debug.WriteLine($"The {args.Method.Name} method has exited (total execution time in MS: {sw.ElapsedMilliseconds}).");
        }

        public override void OnException(MethodExecutionArgs args)
        {
            Debug.WriteLine($"An exception was thrown in {args.Method.Name}.");
        }
    }
}

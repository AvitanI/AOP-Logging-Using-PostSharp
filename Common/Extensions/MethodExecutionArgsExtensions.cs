using PostSharp.Aspects;

namespace Common.Extensions
{
    public static class MethodExecutionArgsExtensions
    {
        public static string FullMethodName(this MethodExecutionArgs args) => $"{args.Method.DeclaringType.FullName}_{args.Method.Name}";
    }
}

using PostSharp.Aspects;

namespace Common.Extensions
{
    /// <summary>
    /// Get full name (namespace, class and method name)
    /// </summary>
    public static class MethodExecutionArgsExtensions
    {
        public static string FullMethodName(this MethodExecutionArgs args) => $"{args.Method.DeclaringType.FullName}_{args.Method.Name}";
    }
}

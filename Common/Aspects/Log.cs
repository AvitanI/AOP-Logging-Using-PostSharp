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
            args.MethodExecutionTag = Stopwatch.StartNew();

            WriteToLog($"The { DisplayName(args) } method has been entered.");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, but
        /// only when the method successfully returns (i.e. when no exception flies out the method.).
        /// </summary>
        /// <param name="args"></param>
        public override void OnSuccess(MethodExecutionArgs args)
        {
            WriteToLog($"The { DisplayName(args) } method executed successfully.");
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

            WriteToLog($"The { DisplayName(args) } method has exited (total execution time in MS: {sw.ElapsedMilliseconds}).");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, in
        /// case that the method resulted with an exception.
        /// </summary>
        /// <param name="args"></param>
        public override void OnException(MethodExecutionArgs args)
        {
            WriteToLog($"An exception was thrown in { DisplayName(args) }.");
        }

        private static string DisplayName(MethodExecutionArgs args) => $"{args.Method.DeclaringType.FullName}_{args.Method.Name}";

        private static void WriteToLog(string msg) 
        {
            //[{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff")}] 
            Debug.WriteLine($"{msg}");
        }
    }
}

/*
The thread 0x1ea0 has exited with code 0 (0x0).
The AOPLoggingUsingPostSharp.Controllers.ArticleController_.ctor method has been entered.
The Repositories.ArticleRepository_.ctor method has been entered.
The Repositories.ArticleRepository_.ctor method executed successfully.
The Repositories.ArticleRepository_.ctor method has exited (total execution time in MS: 8).
The Services.ArticleService_.ctor method has been entered.
The Services.ArticleService_.ctor method executed successfully.
The Services.ArticleService_.ctor method has exited (total execution time in MS: 4).
The AOPLoggingUsingPostSharp.Controllers.ArticleController_.ctor method executed successfully.
The AOPLoggingUsingPostSharp.Controllers.ArticleController_.ctor method has exited (total execution time in MS: 23).
The AOPLoggingUsingPostSharp.Controllers.ArticleController_Get method has been entered.
The Services.ArticleService_GetArticle method has been entered.
The Repositories.ArticleRepository_GetArticle method has been entered.
Exception thrown: 'System.InvalidOperationException' in System.Linq.dll
An exception was thrown in Repositories.ArticleRepository_GetArticle.
Exception thrown: 'System.InvalidOperationException' in Repositories.dll
The Repositories.ArticleRepository_GetArticle method has exited (total execution time in MS: 69).
An exception was thrown in Services.ArticleService_GetArticle.
Exception thrown: 'System.InvalidOperationException' in Services.dll
The Services.ArticleService_GetArticle method has exited (total execution time in MS: 104).
An exception was thrown in AOPLoggingUsingPostSharp.Controllers.ArticleController_Get.
Exception thrown: 'System.InvalidOperationException' in AOPLoggingUsingPostSharp.dll
An exception of type 'System.InvalidOperationException' occurred in AOPLoggingUsingPostSharp.dll but was not handled in user code
Sequence contains no matching element
*/

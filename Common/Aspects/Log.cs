﻿using Common.Extensions;
using Newtonsoft.Json;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            var logDescription = $"{args.FullMethodName()} - Starting.";

            if (args.Arguments != null && args.Arguments.Count > 0)
            {
                var parameters = args.Method.GetParameters().ToDictionary(key => key.Name, value => args.Arguments[value.Position]);

                // Serialize to JSON (Newtonesof lib)
                logDescription += $" args: {JsonConvert.SerializeObject(parameters)}";
            }

            Debug.WriteLine(logDescription);
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, but
        /// only when the method successfully returns (i.e. when no exception flies out the method.).
        /// </summary>
        /// <param name="args"></param>
        public override void OnSuccess(MethodExecutionArgs args)
        {
            Debug.WriteLine($"{args.FullMethodName()} - Succeeded.");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, even
        /// when the method exists with an exception (this method is invoked from the finally block).
        /// </summary>
        /// <param name="args"></param>
        public override void OnExit(MethodExecutionArgs args)
        {
            Debug.WriteLine($"{args.FullMethodName()} - Exited.");
        }

        /// <summary>
        /// Method executed after the body of methods to which this aspect is applied, in
        /// case that the method resulted with an exception.
        /// </summary>
        /// <param name="args"></param>
        public override void OnException(MethodExecutionArgs args)
        {
            var logDescription = $"{args.FullMethodName()} - Failed.";

            if (args.Exception != null)
            {
                logDescription += $" message: {args.Exception.Message}";
            }

            Debug.WriteLine(logDescription);
        }
    }
}

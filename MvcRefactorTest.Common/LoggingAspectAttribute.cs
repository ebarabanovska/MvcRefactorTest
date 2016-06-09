using System;

using PostSharp.Aspects;

namespace MvcRefactorTest.Common
{
    using System.IO;
    using System.Reflection;
    using System.Text;

    using log4net;
    using log4net.Config;

    [Serializable]
    public class LoggingAspectAttribute : OnMethodBoundaryAspect
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LoggingAspectAttribute));

        public override void OnEntry(MethodExecutionArgs args)
        {
            this.InitializeLogger();
            log.InfoFormat("Entering {0}.{1}.", args.Method.DeclaringType.Name, args.Method.Name);
            log.Debug(DisplayObjectInfo(args));
        }

        public override void OnException(MethodExecutionArgs args)
        {
            this.InitializeLogger();
            log.ErrorFormat("Exception {0} in {1}", args.Exception, args.Method);
            args.FlowBehavior = FlowBehavior.Continue;
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            this.InitializeLogger();
            log.DebugFormat(
                "Leaving {0}.{1}. Return value {2}", 
                args.Method.DeclaringType.Name, 
                args.Method.Name, 
                args.ReturnValue);
        }

        private static string DisplayObjectInfo(MethodExecutionArgs args)
        {
            var sb = new StringBuilder();
            var type = args.Arguments.GetType();
            sb.Append("Method " + args.Method.Name);
            sb.Append("\r\nArguments:");
            var fi = type.GetFields();
            if (fi.Length > 0)
            {
                foreach (var f in fi)
                {
                    sb.Append("\r\n " + f + " = " + f.GetValue(args.Arguments));
                }
            }
            else sb.Append("\r\n None");

            return sb.ToString();
        }

        private void InitializeLogger()
        {
            var configFile = new FileInfo(@"E:\GitHub\MvcRefactorTest\MvcRefactorTest.Common\App.config");
            XmlConfigurator.ConfigureAndWatch(configFile);
        }
    }
}
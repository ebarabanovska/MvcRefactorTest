using System;
using System.IO;
using System.Reflection;
using System.Text;

using log4net;
using log4net.Config;

using PostSharp.Aspects;

namespace MvcRefactorTest.Log4Net
{
    
    public class LoggingProfileAttribute : OnMethodBoundaryAspect
    {
        private ILog Log = LogManager.GetLogger(typeof(LoggingProfileAttribute));

        public override void OnEntry(MethodExecutionArgs args)
        {
            this.InitializeLog();
            this.Log.InfoFormat("Entering {0}.{1}", args.Method.DeclaringType.Name, args.Method.Name);
            this.Log.Debug(DisplayObjectInfo(args));
        }

        public override void OnException(MethodExecutionArgs args)
        {
            this.InitializeLog();
            this.Log.ErrorFormat("Exception {0} in {1}", args.Exception, args.Method);
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            this.InitializeLog();
            this.Log.DebugFormat(
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

        private void InitializeLog()
        {
            //var uri = new Uri(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), LogFactory.Log4NetConfig));
            //var configFile = new FileInfo(@"E:\GitHub\MvcRefactorTest\MvcRefactorTest.Log4Net\App.config");
            //XmlConfigurator.ConfigureAndWatch(configFile);
            //this.Log = LogManager.GetLogger(typeof(object));
        }
    }
}
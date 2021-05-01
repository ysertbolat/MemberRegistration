using DevFramework.Core.CrossCuttingConcerns.Logging;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method,TargetExternalMemberAttributes = MulticastAttributes.Instance)]
    //MulticastAttributeUsage = yukarıdaki kod class başına yazılan nesne methodlarının örneklerine uygula demek (constructorlara uygulamasın diye)
    public class LogAspect:OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private LoggerService _loggerService;
        public LogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }
        //Instancelarını da yazmak gerek
        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType.BaseType!=typeof(LoggerService))
            {
                throw new Exception("Wrong logger type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }
        //loglar ihtiyaca göre çalışması değişir örneğin methodun başında da çağırıp (OnEntry'ye koyarak) yapabilirsiniz ya da sonunda çağırabilirsiniz

        //şimdi ise methodun başında loglamayı çalıştırmak için kodlarımızı yazacağız 

        public override void OnEntry(MethodExecutionArgs args)
        {
            if (!_loggerService.IsInfoEnabled)
            {
                return;
            }
            
            //loglama yaparken sistem hata vermesin diye try catch'den yararlanacağız
            try
            {
                //parametrelerimizi listeye çağırmak için bunu yazdık
                var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();

                //parametrelerin detayları için yazmış olduğumuz sınıfı da çağırmamız gerek
                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameters
                };

                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {

            }
        }
    }
}

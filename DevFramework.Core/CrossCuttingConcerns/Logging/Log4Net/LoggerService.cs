using log4net;
using NHibernate.UserTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    //bunu yapmamın sebebi farklı ortamlarda farklı loglama yöntemlerini kullanabilirim 
    [Serializable]
    public class LoggerService 
    {
        private ILog _log; //log4net nuget paketinde olan bir nesne

        public LoggerService(ILog log)
        {
            _log = log;
        }

        //kurallarımızı yazıyoruz 
        public bool IsInfoEnabled //bu şekilde de yazılabilir 
        {
            get { return _log.IsInfoEnabled; }
        }
        public bool IsDebugEnabled => _log.IsDebugEnabled; //bu şekilde de
        public bool IsWarnEnabled => _log.IsWarnEnabled;
        public bool IsFatalEnabled => _log.IsFatalEnabled;
        public bool IsErrorEnabled => _log.IsErrorEnabled;

        //kurallarımızı loglamamız gereken yapıları oluşturuyoruz 
        public void Info(object logMessage)
        {
            if (IsInfoEnabled)
            {
                _log.Info(logMessage);
            }
        }
        public void Debug(object logMessage)
        {
            if (IsDebugEnabled)
            {
                _log.Debug(logMessage);
            }
        }
        public void Warn(object logMessage)
        {
            if (IsWarnEnabled)
            {
                _log.Warn(logMessage);
            }
        }
        public void Fatal(object logMessage)
        {
            if (IsFatalEnabled)
            {
                _log.Fatal(logMessage);
            }
        }
        public void Error(object logMessage)
        {
            if (IsErrorEnabled)
            {
                _log.Error(logMessage);
            }
        }
    }
}

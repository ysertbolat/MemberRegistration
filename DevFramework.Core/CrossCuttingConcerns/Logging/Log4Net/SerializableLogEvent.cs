using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        private LoggingEvent _loggingEvent;
        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string UserName //bu şekilde de yazılabilir 
        {
            get
            {
                return _loggingEvent.UserName;
            }
        }
        //bu şekilde de yazılabilir ikisi de aynı anlam
        public object MessageObject => _loggingEvent.MessageObject;
    }
}

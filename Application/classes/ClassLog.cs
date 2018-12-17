using System;
namespace Application.classes
{
    public class ClassLog : ClassApplicationBase
    {
        private string LogName;
        private string LogSuccessPath;
        private string LogErrorPAth;

        public ClassLog()
        {
            this.LogSuccessPath = this.BasePath + "/logs/success.log";
            this.LogErrorPAth = this.BasePath + "/logs/errors.log";
        }

        public void To(string logName)
        {

        }

        public void Write(string LogContent, string LogType)
        { 
        }


    }
}

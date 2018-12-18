using System;
using System.IO;
namespace Application.classes
{
    public class ClassLog
    {
        public string BasePath;
        private string LogSuccessPath;
        private string LogErrorPAth;

        public ClassLog()
        {
            this.BasePath = Environment.CurrentDirectory;
            this.LogSuccessPath = this.BasePath + "/logs/success.log";
            this.LogErrorPAth = this.BasePath + "/logs/errors.log";
        }

        public void Success(string LogContent)
        {
            DateTime date = new DateTime();
            LogContent = date.ToString("YYYYMMDD - HHmmsss: ") + LogContent;


        }

        public void Errors(string LogContent)
        {
        }


    }
}

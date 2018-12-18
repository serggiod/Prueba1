using System;
using System.IO;
using System.Collections.Generic;

namespace Application.classes
{
    public class ClassLog
    {
        public string BasePath;

        public ClassLog()
        {
            this.BasePath = Environment.CurrentDirectory;


            //this.LogErrorPAth = this.BasePath + "/logs/errors.log";
        }

        public void Success(string LogContent)
        {
            String Log = DateTime.Now.ToString();
            Log += ": ";
            Log += LogContent;

            String Path = this.BasePath;
            Path += "/logs";
            Path += "/success.log";

            /*List<string> Lines = new List<string>();

            StreamReader reader = new StreamReader(Path);
            while (reader.Peek() >= 0) Lines.Add(reader.ReadLine());
            reader.Close();

            Lines.Add(Log);*/

            StreamWriter Writer = new StreamWriter(Path);
            Writer.NewLine = Log;
            Writer.WriteLine();
            Writer.Close();   
        }

        public void Errors(string LogContent)
        {
            String Log = DateTime.Now.ToString();
            Log += ": ";
            Log += LogContent;

            String Path = this.BasePath;
            Path += "/logs";
            Path += "/errors.log";

            StreamWriter Writer = new StreamWriter(Path);
            Writer.NewLine = Log;
            Writer.WriteLine();
            Writer.Close();
        }
    }
}

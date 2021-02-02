using System;

namespace wake
{
    class Program
    {
        static void Main(string[] args)
        {            
            //#region command line vars
            var data = new CommandLine(args);
            var echoText = data.GetValue("echo","");
            var echoRepeat = data.GetValue("repeat",1);
            for(var i=0; i<echoRepeat; i++)Console.WriteLine(echoText);            
        }
    }
}

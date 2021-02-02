using System;
using System.Collections.Generic;
class CommandLine
    {
        /*USAGE:
            var data = new CommandLine(args);                           //parse command line args
            var echoText = data.GetValue("echo","");                    //find "echo" command and get value (string)
            var echoRepeat = data.GetValue("repeat",1);                 //number of times to echo value (int)
            for(var i=0; i<echoRepeat; i++)Console.WriteLine(echoText); //echo the value to the Console
        */

        private Dictionary<string,object> data = new Dictionary<string, object>();
        
        public CommandLine(string[] args)
        {
            for(var i = 0; i < args.Length; i++)
            {
                if(
                    args[i].StartsWith("-")
                    || args[i].StartsWith("/")
                )
                {
                    //found a switch... get the KEY and check args[i+1] for a value
                    var key = args[i].TrimStart(new char[]{'-','/'});
                    //default value is "true"
                    var value = "true";
                    if(
                        (i+1)<args.Length
                        &&!args[i+1].StartsWith("-")
                        &&!args[i+1].StartsWith("/")
                    ){
                        //found actual value
                        value = args[i+1];
                    }
                    this.data.Add(key,value);
                    //Console.WriteLine($"{key}:{value}");
                }
            }
        }

        public T GetValue<T>(string key, T defaultValue)
        {
            var v = this.data.GetValueOrDefault(key, defaultValue);
            T r;
            try
            {
                r = (T)Convert.ChangeType(v, typeof(T));
            }catch(Exception e)
            {
                Console.WriteLine($"Unable to parse value for {key}... using provided default value.");
                Console.WriteLine(e.Message);
                r = defaultValue;
            }
            return r;
        }        
    }
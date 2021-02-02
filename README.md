# CommandLine
class for processing command line arguments in C# console applications

CommandLine.cs parses C# command line arguments and makes them avaliable as variables in the expected TYPE

#Usage
```C#
var data = new CommandLine(args);               //create new CommandLine object with args
string text = data.GetValue("text","");         //will find string after /text or -text
int number = data.GetValue("number",1);         //will find int after /number or -number
bool isTrue = data.GetValue("isTrue",false);    //fill find flag /isTrue or -isTrue
```

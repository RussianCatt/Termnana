using System;
using System.Composition;
using Termnana.Nanas;

[Export(typeof(INana))]
public class HelloWorldNana : INana
{
    public string CommandName => "hello";
    public string Author => "Your Name";
    public string Version => "1.0.0";
    public string Description => "A sample Nana that says hello.";
    public bool RequiresArguments => false;
    public string PluginName => "HelloWorldNana";
    public string[] Dependencies => new string[0];

    public void Execute(string[] args)
    {
        Console.WriteLine("Hello, world!");
    }
}

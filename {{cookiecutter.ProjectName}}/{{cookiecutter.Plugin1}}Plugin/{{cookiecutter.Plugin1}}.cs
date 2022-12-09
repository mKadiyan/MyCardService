using System;
using {{cookiecutter.ProjectName}}PluginBase;

namespace {{cookiecutter.Plugin2}}Plugin;

public class {{cookiecutter.Plugin2}} : ICardPlugin
{
    public void MakePayment()
    {
        Console.WriteLine("The payment is done by Master {{cookiecutter.Plugin1}}");
    }
}

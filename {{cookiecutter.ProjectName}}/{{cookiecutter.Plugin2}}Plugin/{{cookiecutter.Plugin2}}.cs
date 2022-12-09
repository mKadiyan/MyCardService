using {{cookiecutter.ProjectName}}PluginBase;
using System;

namespace {{cookiecutter.Plugin2}}Plugin;

public class {{cookiecutter.Plugin2}}: I{{cookiecutter.ProjectName}}Plugin
{
    public void MakePayment()
    {
        Console.WriteLine("The payment is done by Visa{{cookiecutter.ProjectName}}");
    }

}

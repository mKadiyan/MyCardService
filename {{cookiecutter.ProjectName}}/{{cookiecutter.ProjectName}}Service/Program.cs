// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Runtime.Loader;
using {{cookiecutter.ProjectName}}PluginBase;
namespace {{cookiecutter.ProjectName}}Service
{
    public class Program
    {
        private static Dictionary<string, I{{cookiecutter.ProjectName}}Plugin> Plugins = new Dictionary<string, I{{cookiecutter.ProjectName}}Plugin>();

        private static string PluginPath = Path.GetFullPath(Path.Combine(System.AppContext.BaseDirectory, @"Plugins"));

        public static void Main(string[] args)
        {
            Console.WriteLine("Application Started");
            LoadPlugins();
            foreach (var key in Plugins.Keys)
            {
                Plugins[key].MakePayment();
            }
        }

        public static void LoadPlugins()
        {
            foreach (var dll in Directory.GetFiles(PluginPath, "*.dll"))
            {
                AssemblyLoadContext assemblyLoadContext = new AssemblyLoadContext(dll);
                Assembly assembly = assemblyLoadContext.LoadFromAssemblyPath(dll);
                var {{cookiecutter.ProjectName}}Plugin = Activator.CreateInstance(assembly.GetTypes()[2]) as I{{cookiecutter.ProjectName}}Plugin;
                if ({{cookiecutter.ProjectName}}Plugin != null)
                {
                    Plugins.Add(Path.GetFileNameWithoutExtension(dll), {{cookiecutter.ProjectName}}Plugin);
                }
            }
        }
    }
   
}




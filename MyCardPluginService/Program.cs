// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Runtime.Loader;
using MyCardPluginPluginBase;
namespace MyCardPluginService
{
    public class Program
    {
        private static Dictionary<string, IMyCardPluginPlugin> Plugins = new Dictionary<string, IMyCardPluginPlugin>();

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
                var MyCardPluginPlugin = Activator.CreateInstance(assembly.GetTypes()[2]) as IMyCardPluginPlugin;
                if (MyCardPluginPlugin != null)
                {
                    Plugins.Add(Path.GetFileNameWithoutExtension(dll), MyCardPluginPlugin);
                }
            }
        }
    }
   
}




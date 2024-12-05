using PluginTest.ConsoleApp.Services.Base;
using PluginTest.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace PluginTest.ConsoleApp.Services.Derived
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class PluginSwitchService<T> : ServiceBase<PluginSwitchService<T>>
    {
        [ImportMany]
        private IEnumerable<Lazy<IPlugin, IPluginIdentifier>> AllPlugins { get; set; }

        public PluginSwitchService()
        {
            LoadPlugins();
        }

        public T GetRequiredPlugin(string pluginIdentifier)
        {
            try
            {
                var selectedPlugin = AllPlugins.FirstOrDefault(p => p.Metadata.Name == pluginIdentifier && p.Value is T);

                if (selectedPlugin != null)
                {
                    return (T)selectedPlugin.Value;
                }
            }
            catch (Exception)
            {
                // Log exception
            }

            return default;
        }

        private void LoadPlugins()
        {
            var catalog = new DirectoryCatalog(@"C:\Users\cando\source\repos\PluginTest\PluginTest.ConsoleApp\bin\Debug\Plugins");
            var container = new CompositionContainer(catalog);

            container.ComposeParts(this);
        }
    }
}

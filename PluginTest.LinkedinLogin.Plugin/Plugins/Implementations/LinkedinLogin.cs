using PluginTest.Shared.Interfaces;
using System.ComponentModel.Composition;
using System.Threading.Tasks;

namespace PluginTest.LinkedinLogin.Plugin.Plugins.Implementations
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    [Export(typeof(IPlugin))]
    [ExportMetadata("Name", "LinkedinLoginPlugin")]
    public sealed class LinkedinLogin : IPlugin
    {
        public bool Login(string username, string password)
        {
            if (username == "linkedin" && password == "admin")
            {
                return true;
            }

            return false;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            if (username == "linkedin" && password == "admin")
            {
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
    }
}

using System.Threading.Tasks;

namespace PluginTest.Shared.Interfaces
{
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public interface IPlugin
    {
        Task<bool> LoginAsync(string username, string password);
        bool Login(string username, string password);
    }
}

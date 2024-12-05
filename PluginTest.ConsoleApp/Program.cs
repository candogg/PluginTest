using PluginTest.ConsoleApp.Services.Derived;
using PluginTest.Shared.Interfaces;
using System;

namespace PluginTest.ConsoleApp
{
    /// <summary>
    /// Author: Can DOĞU
    /// All compiled plugins must be inside of Plugins folder
    /// </summary>
    internal class Program
    {
        static void Main()
        {
            Console.Write("Select plugin to login, (1) for Active Directory Login,(2) for LinkedIn Login: ");

            var selectedPlugin = Console.ReadLine().Trim();

            var pluginIdentifier = string.Empty;
            var pluginText = string.Empty;

            switch (selectedPlugin)
            {
                case "1":
                    {
                        pluginIdentifier = "ADLoginPlugin";
                        pluginText = "Active Directory";
                        break;
                    }
                case "2":
                    {
                        pluginIdentifier = "LinkedinLoginPlugin";
                        pluginText = "LinkedIn";
                        break;
                    }
            }

            if (string.IsNullOrEmpty(pluginIdentifier))
            {
                Console.WriteLine("Invalid plugin selection!");
                Console.ReadKey();
                return;
            }

            var injectedPlugin = PluginSwitchService<IPlugin>.DerivedObject.GetRequiredPlugin(pluginIdentifier);

            if (injectedPlugin != default)
            {
                Console.Write($"Enter {pluginText} username: ");

                var username = Console.ReadLine();

                Console.Write($"Enter {pluginText} password: ");

                var password = Console.ReadLine();

                var loginResult = injectedPlugin.Login(username, password);

                Console.WriteLine(loginResult ? "Login successful!" : "Login failed!");
            }
            else
            {
                Console.WriteLine("Plugin not found!");
            }

            Console.ReadKey();
        }
    }
}

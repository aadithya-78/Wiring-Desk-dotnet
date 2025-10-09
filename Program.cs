using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wiring_Desk
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // 1️⃣ Set the centralized DLL path
            string sharedDllPath = @"C:\Program Files (x86)\Phoeneix Process Automation\Wiring Desk Setup";


            if (!Directory.Exists(sharedDllPath))
            {
                MessageBox.Show(
                    "Please install the Wiring Desk Setup package.",
                    "Wiring Desk",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return; // Exit the app safely
            }


            // 2️⃣ Hook up AssemblyResolve to load from that folder
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string assemblyName = new AssemblyName(args.Name).Name + ".dll";
                string assemblyPath = Path.Combine(sharedDllPath, assemblyName);

                if (File.Exists(assemblyPath))
                    return Assembly.LoadFrom(assemblyPath);

                return null;
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                using (loginForm login = new loginForm())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        break; 

                    using (GTI gti = new GTI(login.Username))
                    {
                        if (gti.ShowDialog() != DialogResult.OK)
                            break; 
                    }
                }
            }
        }

    }
}

using System;
using System.Diagnostics;
using System.Linq;
using IWshRuntimeLibrary;
using Microsoft.VisualStudio.OLE.Interop;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace RoulletteMizer
{
    public class MethodClass
    {

        public void DetermineShit(string Filepath)
        {
            Process proccess = new Process();
            ProcessStartInfo startinfoobject = new ProcessStartInfo();
            WshShell shell = new WshShell();

            TextBox textBox2 = new TextBox();
            var @filename = Path.GetFileName(Filepath);
            startinfoobject.UseShellExecute = true;

            if (filename.EndsWith(".lnk"))
            {



                //This creates a new shortcut from the one we are going to get so we can use it and  then with the help of the god sent amazing library of IWshRuntimeLibrary we can find
                // the OG .exe from the lnk and its 2 am nice
                IWshShortcut link = (IWshShortcut)shell.CreateShortcut(Filepath);
                string exefilepath = link.TargetPath;


                textBox2.AppendText(filename);

                proccess = Process.Start(exefilepath);

            }

            else if (Filepath.EndsWith("url"))
            {

                proccess = Process.Start("explorer.exe", filename);
                textBox2.AppendText(filename);


            }

            else if (Filepath.EndsWith("exe"))
            {

                proccess = Process.Start("explorer.exe", filename);

                textBox2.AppendText(filename);
            }

        }




    }
}

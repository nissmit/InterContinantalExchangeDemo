using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ForeCast
{
    internal class RunProcess
    {
        public RunResult RunProcessSync(string fileName,string args)
        {
            using (var process = new Process
            {
                StartInfo =
                {
                    FileName = fileName, Arguments = args,
                    UseShellExecute = false, CreateNoWindow = true,
                    RedirectStandardOutput = true, RedirectStandardError = true
                },
                EnableRaisingEvents = true
            })
            {
                process.Start();
                process.WaitForExit();
                return new RunResult(process.ExitCode, process.StandardOutput.ReadToEnd(), process.StandardError.ReadToEnd());
            }
        }
        public async Task<RunResult> RunProcessAsync(string fileName, string args)
        {
            using (var process = new Process
            {
                StartInfo =
                {
                    FileName = fileName, Arguments = args,
                    UseShellExecute = false, CreateNoWindow = true,
                    RedirectStandardOutput = true, RedirectStandardError = true
                },
                EnableRaisingEvents = true
            })
            {
                process.Start();
                await process.WaitForExitAsync().ConfigureAwait(false);
                return new RunResult(process.ExitCode, process.StandardOutput.ReadToEnd(), process.StandardError.ReadToEnd());
            }
        }
       
    }

   
}

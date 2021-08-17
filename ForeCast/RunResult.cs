namespace ForeCast
{
    internal class RunResult
    {
        public int ExitValue { get; set; }
        public string Output { get; set; }
        public string Error { get; set; }
        public RunResult(int exitCode,string output,string error)
        {
            ExitValue = exitCode;
            Output = output;
            Error = error;
        }
    }

   
}

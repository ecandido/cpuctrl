using System.Diagnostics;

namespace CPUControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool closeConsole = false;

            Process Proc = Process.GetCurrentProcess();
            long affinity = (long)Proc.ProcessorAffinity;

            if (args.Length != 0)
            {
                affinity = args[0] switch
                {
                    "2" => 0x0002,
                    "3" => 0x0004,
                    "4" => 0x0008,
                    _ =>  0x0001
                };
            }
            
            ProcessThread Thread = Proc.Threads[0];
            Thread.ProcessorAffinity = (IntPtr)affinity;
            int i = 1;

            while (!closeConsole)
            {
                Console.WriteLine("Keep it working! {0}", i++);
            }
        }
    }
}
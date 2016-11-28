using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace ConsoleService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<Worker>(s =>
                {
                    s.ConstructUsing(name => new Worker());
                    s.WhenStarted(tc => Worker.Start());
                    s.WhenStopped(tc => Worker.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Тестовый запуск сервиса записи в файл");
                x.SetDisplayName("WorkerTest");
                x.SetServiceName("WorkerTest");
            });
        }
    }

    class Worker
    {
        private static Thread thread;        

        public static void Start()
        {
            thread = new Thread(Process);
            thread.Start();
        }

        public static void Stop()
        {
            thread.Abort();
        }
        private static void Process()
        {
            while (true)
            {
                SaveFile();
                Thread.Sleep(3000);
            }
        }

        private static void SaveFile()
        {
            var time = DateTime.Now.ToString() + "\n";
            var timeBytes = Encoding.ASCII.GetBytes(time);

            using (var file = File.Open("TimeNow.txt", FileMode.Append))
            {
                file.Write(timeBytes, 0, timeBytes.Length);
            }
        }
    }
}

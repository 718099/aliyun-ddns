﻿using CommandLine;
using System;

namespace aliyun_ddns
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Console.WindowWidth <= 10)
            {
                Parser.Default.Settings.MaximumDisplayWidth = 80;
            }

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(op =>
                {
                    Options.Instance = op;
                    DomainUpdater updater = new DomainUpdater();
                    updater.Run();
                });
#if DEBUG
            Console.Read();
#endif
        }
    }
}

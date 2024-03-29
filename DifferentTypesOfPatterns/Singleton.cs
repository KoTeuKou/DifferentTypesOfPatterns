﻿using System;

namespace DifferentTypesOfPatterns
{
    class Singleton
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            comp.Launch("Windows 7");
            Console.WriteLine(comp.OS.Name);
            comp.OS = OS.getInstance("Linux");
            Console.WriteLine(comp.OS.Name);

            Console.ReadLine();
        }
    }
    class Computer
    {
        public OS OS { get; set; }
        public void Launch(string osName)
        {
            OS = OS.getInstance(osName);
        }
    }
    class OS
    {
        private static OS instance;

        public string Name { get; private set; }

        protected OS(string name)
        {
            this.Name = name;
        }

        public static OS getInstance(string name)
        {
            if (instance == null)
                instance = new OS(name);
            return instance;
        }
    }
}
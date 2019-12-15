using System;

namespace DifferentTypesOfPatterns
{
    class Adapter
    {
        static void Main(string[] args)
        {
            // Приложение
            Application app = new Application();
            // Винда
            Windows windows = new Windows();
            // Создаем приложение заточенное под винду
            app.Start(windows);
            // переход на другую платформу, надо адаптировать приложение под линукс
            Linux linux = new Linux();
            // используем адаптер
            ISystem linuxSystem = new LinuxToSystemAdapter(linux);
            // приложение работает на новой системе
            app.Start(linuxSystem);

            Console.Read();
        }
    }

    interface ISystem
    {
        void StartApp();
    }

    class Windows : ISystem
    {
        public void StartApp()
        {
            Console.WriteLine("Приложение работает на винде");
        }
    }

    class Application
    {
        public void Start(ISystem system)
        {
            system.StartApp();
        }
    }

    class Linux
    {
        public void Work()
        {
            Console.WriteLine("Приложение нормально работает на линуксе");
        }
    }

    class LinuxToSystemAdapter : ISystem
    {
        Linux linux;

        public LinuxToSystemAdapter(Linux l)
        {
            linux = l;
        }

        public void StartApp()
        {
            linux.Work();
        }
    }
}
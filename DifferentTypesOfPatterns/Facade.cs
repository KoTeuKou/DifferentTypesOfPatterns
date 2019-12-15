using System;

namespace DifferentTypesOfPatterns
{
    class Facade
    {
        static void Main(string[] args)
        {
            Birth birth = new Birth();
            Education school = new Education();
            Work work = new Work();
            Death death = new Death();

            LifeCycle life = new LifeCycle(birth, school, work, death);

            God god = new God();
            god.CreateApplication(life);

            Console.Read();
        }
    }

    class Birth
    {
        public void birthOfHuman()
        {
            Console.WriteLine("Рождение");
        }
    }

    class Education
    {
        public void educate()
        {
            Console.WriteLine("Обучение");
        }
    }

    class Work
    {
        public void work()
        {
            Console.WriteLine("Работа");
        }
    }

    class Death
    {
        public void endOfLife()
        {
            Console.WriteLine("Смерть");
        }
    }

    class LifeCycle
    {
        Birth birth;
        Education school;
        Work work;
        Death death;

        public LifeCycle(Birth birth, Education school, Work work, Death death)
        {
            this.birth = birth;
            this.school = school;
            this.work = work;
            this.death = death;
        }

        public void Start()
        {
            birth.birthOfHuman();
            school.educate();
            work.work();
        }

        public void Stop()
        {
            death.endOfLife();
        }
    }

    class God
    {
        public void CreateApplication(LifeCycle facade)
        {
            facade.Start();
            facade.Stop();
        }
    }
}
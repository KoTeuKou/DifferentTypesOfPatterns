using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentTypesOfPatterns
{
    class Strategy
    {
    
            static void Main(string[] args)
            {
                LearningStrategy tactics = new LearningStrategy(new Memorization());
                tactics.PassExam();
                Console.WriteLine("Следующий экзамен");
                tactics.Passable = new CopyPaste();
                tactics.PassExam();

                Console.ReadLine();
            }
        }
        interface IPassable
        {
            void PassExam();
        }

        class Memorization : IPassable
        {
            public void PassExam()
            {
                Console.WriteLine("Не зря учил, смог на все ответить.");
            }
        }

        class CopyPaste : IPassable
        {
            public void PassExam()
            {
                Console.WriteLine("Не зря не учил, всё списал.");
            }
        }
        class LearningStrategy
        {

            public LearningStrategy(IPassable pass)
            {
                Passable = pass;
            }
            public IPassable Passable { private get; set; }
            public void PassExam()
            {
                Passable.PassExam();
            }
        }
    }


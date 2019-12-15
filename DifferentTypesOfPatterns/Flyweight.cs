using System;
using System.Collections.Generic;


namespace DifferentTypesOfPatterns
{
    class Flyweight
    {
   
            static void Main(string[] args)
            {
                var n = 4;
                var percentageOfCocoa = 50;

                ChocolateFactory chocoFactory = new ChocolateFactory();
                for (int i = 0; i < n; i++)
                {
                    Chocolate bitterChoco = chocoFactory.GetChocolate("Bitter");
                    if (bitterChoco != null)
                    {
                        percentageOfCocoa = 50;
                        bitterChoco.Cook(percentageOfCocoa);
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    Chocolate milkChoco = chocoFactory.GetChocolate("Milk");
                    if (milkChoco != null)
                    {
                        percentageOfCocoa = 30;
                        milkChoco.Cook(percentageOfCocoa);
                    }
                }

                Console.Read();
            }
        }

        abstract class Chocolate
        {
            protected int numOfSlices; // количество долек на плитке

            public abstract void Cook(double percentageOfCocoa);
        }

        class BitterChoco : Chocolate
        {
            public BitterChoco()
            {
                numOfSlices = 8;
            }

            public override void Cook(double percentageOfCocoa)
            {
                Console.WriteLine("Приготовлен горький шоколад с содержанием какао: {0}",
                    percentageOfCocoa);
            }
        }
        class MilkChoco : Chocolate
        {
            public MilkChoco()
            {
                numOfSlices = 32;
            }

            public override void Cook(double percentageOfCocoa)
            {
                Console.WriteLine("Приготовлен молочный шоколад с содержанием какао: {0}",
                  percentageOfCocoa);
            }
        }

        class ChocolateFactory
        {
            Dictionary<string, Chocolate> chocolates = new Dictionary<string, Chocolate>();
            public ChocolateFactory()
            {
                chocolates.Add("Bitter", new BitterChoco());
                chocolates.Add("Milk", new MilkChoco());
            }

            public Chocolate GetChocolate(string key)
            {
                if (chocolates.ContainsKey(key))
                    return chocolates[key];
                else
                    return null;
            }
        }
    }

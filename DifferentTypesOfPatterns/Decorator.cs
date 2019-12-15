using System;

namespace DifferentTypesOfPatterns
{
    class Decorator
    {
        static void Main(string[] args)
        {
            Cake strawberryCake = new ChocolateCake();
            strawberryCake = new StrawberryCake(strawberryCake);
            Console.WriteLine("Название: {0}", strawberryCake.Name);
            Console.WriteLine("Цена: {0}", strawberryCake.GetCost());

            Cake raspberryCake = new ChocolateCake();
            raspberryCake = new RaspberryCake(raspberryCake);
            Console.WriteLine("Название: {0}", raspberryCake.Name);
            Console.WriteLine("Цена: {0}", raspberryCake.GetCost());

            Cake multiCake = new BananaCake();
            multiCake = new StrawberryCake(multiCake);
            multiCake = new RaspberryCake(multiCake);
            Console.WriteLine("Название: {0}", multiCake.Name);
            Console.WriteLine("Цена: {0}", multiCake.GetCost());

            Console.ReadLine();
        }
    }

    abstract class Cake
    {
        public Cake(string name)
        {
            this.Name = name;
            this.CostOfBase = 25;
        }

        public string Name { get; protected set; }
        public int CostOfBase { get; protected set; }
        public abstract int GetCost();
    }

    class ChocolateCake : Cake
    {
        public ChocolateCake() : base("Шоколадный тортик")
        {
            this.CostOfChocolate = 15;
        }

        public int CostOfChocolate { get; protected set; }

        public override int GetCost()
        {
            return CostOfBase + CostOfChocolate;
        }
    }

    class BananaCake : Cake
    {
        public BananaCake()
            : base("Банановый тортик")
        {
            this.CostOfBananas = 10;
        }

        public int CostOfBananas { get; protected set; }

        public override int GetCost()
        {
            return CostOfBase + CostOfBananas;
        }
    }

    abstract class CakeDecorator : Cake
    {
        protected Cake cake;

        public CakeDecorator(string name, Cake cake) : base(name)
        {
            this.cake = cake;
        }
    }

    class StrawberryCake : CakeDecorator
    {
        private int priceOfStrawberry;

        public StrawberryCake(Cake cake)
            : base(cake.Name + ", с клубникой", cake)
        {
            this.priceOfStrawberry = 5;
        }

        public override int GetCost()
        {
            return cake.GetCost() + priceOfStrawberry;
        }
    }

    class RaspberryCake : CakeDecorator
    {
        private int priceOfRaspberry;

        public RaspberryCake(Cake p)
            : base(p.Name + ", с малиной", p)
        {
            this.priceOfRaspberry = 17;
        }

        public override int GetCost()
        {
            return cake.GetCost() + priceOfRaspberry;
        }
    }
}
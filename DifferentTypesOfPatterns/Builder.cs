using System;
using System.Text;

namespace DifferentTypesOfPatterns
{
    class Builder
    {
        static void Main(string[] args)
        {
          
            Manufacturer manufacturer = new Manufacturer();     
            JuiceBuilder builder = new OrangeJuiceBuilder();
            Juice orangeJuice = manufacturer.Make(builder);
            Console.WriteLine("Состав апельсинового сока:");
            Console.WriteLine(orangeJuice.ToString());

            builder = new GrapeJuiceBuilder();
            Juice grapeJuice = manufacturer.Make(builder);
            Console.WriteLine("Состав виноградного сока:");
            Console.WriteLine(grapeJuice.ToString());
            Console.Read();
        }
    }


    abstract class JuiceBuilder
    {
        public Juice Juice { get; private set; }

        public void CreateJuice()
        {
            Juice = new Juice();
        }

        public abstract void SetFruit();
        public abstract void SetSugar();
        public abstract void SetAdditives();
    }


    class Manufacturer
    {
        public Juice Make(JuiceBuilder juiceBuilder)
        {
            juiceBuilder.CreateJuice();
            juiceBuilder.SetFruit();
            juiceBuilder.SetSugar();
            juiceBuilder.SetAdditives();
            return juiceBuilder.Juice;
        }
    }


    class OrangeJuiceBuilder : JuiceBuilder
    {
        public override void SetFruit()
        {
            this.Juice.Fruit = new Fruit {Sort = "Апельсинки"};
        }

        public override void SetSugar()
        {
            this.Juice.Sugar = new Sugar();
        }

        public override void SetAdditives()
        {
            // не используется
        }
    }


    class GrapeJuiceBuilder : JuiceBuilder
    {
        public override void SetFruit()
        {
            this.Juice.Fruit = new Fruit {Sort = "Виноград"};
        }

        public override void SetSugar()
        {
            this.Juice.Sugar = new Sugar();
        }

        public override void SetAdditives()
        {
            this.Juice.Additives = new Additives {Name = "E238"};
        }
    }


    class Fruit
    {
      
        public string Sort { get; set; }
    }


    class Sugar
    {
    }


    class Additives
    {
        public string Name { get; set; }
    }

    class Juice
    {      
        public Fruit Fruit { get; set; }

        public Sugar Sugar { get; set; }

        public Additives Additives { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Fruit != null)
                sb.Append(Fruit.Sort + "\n");
            if (Sugar != null)
                sb.Append("Сахар \n");
            if (Additives != null)
                sb.Append("Вкусовые усилители: " + Additives.Name + " \n");
            return sb.ToString();
        }
    }
}
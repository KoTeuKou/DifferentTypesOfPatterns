using System;

namespace DifferentTypesOfPatterns
{
    class AbstractFactory
    {
        static void Main(string[] args)
        {
            Book romance = new Book(new RomanceHC());
            romance.ChooseGenre();
            romance.ChooseCover();
            Console.WriteLine();
            Book detective = new Book(new DetectivePB());
            detective.ChooseGenre();
            detective.ChooseCover();

            Console.ReadLine();
        }
    }

    abstract class Genre
    {
        public abstract void Write();
    }

// абстрактный класс обложка
    abstract class Cover
    {
        public abstract void Create();
    }

    class Romance : Genre
    {
        public override void Write()
        {
            Console.WriteLine("Пишем роман");
        }
    }

    class Detective : Genre
    {
        public override void Write()
        {
            Console.WriteLine("Пишем детектив");
        }
    }

// твердая обложка
    class Hardсover : Cover
    {
        public override void Create()
        {
            Console.WriteLine("Создаем твердую обложку");
        }
    }

// мягкая обложка
    class Paperback : Cover
    {
        public override void Create()
        {
            Console.WriteLine("Создаем мягкую обложку");
        }
    }

// класс абстрактной фабрики
    abstract class BookFactory
    {
        public abstract Cover CreateCover();
        public abstract Genre ChooseGenre();
    }

    class RomanceHC : BookFactory
    {
        public override Cover CreateCover()
        {
            return new Hardсover();
        }

        public override Genre ChooseGenre()
        {
            return new Romance();
        }
    }

    class DetectivePB : BookFactory
    {
        public override Cover CreateCover()
        {
            return new Paperback();
        }

        public override Genre ChooseGenre()
        {
            return new Detective();
        }
    }

    class Book
    {
        private Genre genre;
        private Cover cover;

        public Book(BookFactory factory)
        {
            genre = factory.ChooseGenre();
            cover = factory.CreateCover();
        }

        public void ChooseCover()
        {
            cover.Create();
        }

        public void ChooseGenre()
        {
            genre.Write();
        }
    }
}
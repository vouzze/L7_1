using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Console2_Lab7
{
    public class Magazine : IComparable
    {
        public string Title; 
        public int Price;
        public int Pages;
        public int Rating; 
        public string GetTitle() { return Title; }
        public int GetPrice() { return Price; }
        public int GetPages() { return Pages; }
        public int GetRating() { return Rating; }
        public Magazine(string N, int Pr, int Pa, int R)
        {
            this.Title = N;
            this.Price = Pr;
            this.Pages = Pa;
            this.Rating = R;
        }
        public int CompareTo(object mag)
        {
            Magazine m = (Magazine)mag;
            if (this.Price > m.Price) return 1;
            if (this.Price < m.Price) return -1;
            return 0;
        }
        public class SortByPages : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Magazine m1 = (Magazine)ob1;
                Magazine m2 = (Magazine)ob2;
                if (m1.Pages > m2.Pages) return 1;
                if (m1.Pages < m2.Pages) return -1;
                return 0;
            }
        }
        public class SortByRating : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Magazine m1 = (Magazine)ob1;
                Magazine m2 = (Magazine)ob2;
                if (m1.Rating > m2.Rating) return 1;
                if (m1.Rating < m2.Rating) return -1;
                return 0;
            }
        }
        virtual public void Passport()
        {
            Console.WriteLine("Title = {0}\nPrice = ${1}\nPages = {2}\nRating - {3}\n", Title, Price, Pages, Rating);
        }
    }
    public class Magazines : IEnumerable
    {
        private Magazine[] mas;
        private int n;
        public Magazines()
        {
            mas = new Magazine[5];
            n = 0;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < n; ++i) yield return mas[i];
        }
        public void Add(Magazine m)
        {
            if (n >= 5) return;
            mas[n] = m;
            ++n;
        }

    }
    class Program
    {
        static void Main()
        {
            Magazine ex1 = new Magazine("Vogue", 10, 40, 2);
            Magazine ex2 = new Magazine("Taste", 4, 36, 5);
            Magazine ex3 = new Magazine("Listener", 2, 37, 3);
            Magazine ex4 = new Magazine("Metro", 3, 50, 1);
            Magazine ex5 = new Magazine("Glamour", 8, 22, 4);
            Magazine[] group = new Magazine[5];
            Magazines mags = new Magazines();
            group[0] = ex1;
            group[1] = ex2;
            group[2] = ex3;
            group[3] = ex4;
            group[4] = ex5;
            mags.Add(group[0]);
            mags.Add(group[1]);
            mags.Add(group[2]);
            mags.Add(group[3]);
            mags.Add(group[4]);
            Console.WriteLine("Sorting by price: \n");
            Array.Sort(group);
            foreach (Magazine elem in group) elem.Passport();
            Console.WriteLine("_____________________________");
            Console.WriteLine("Sorting by number of pages: \n");
            Array.Sort(group, new Magazine.SortByPages());
            foreach (Magazine elem in group) elem.Passport();
            Console.WriteLine("_____________________________");
            Console.WriteLine("Sorting by sell rating: \n");
            Array.Sort(group, new Magazine.SortByRating());
            foreach (Magazine elem in group) elem.Passport();
            Console.WriteLine("_____________________________");
            Console.WriteLine("INumerable sorting: \n");
            foreach (Magazine x in mags) x.Passport();

            Console.ReadLine();
        }
    }
}

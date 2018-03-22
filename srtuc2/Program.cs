using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace srtuc2
{
    public struct Human
    {
        public char Sex;
        public int Age;
    }

    public struct Cinema
    {
        public Human[,] humans;
        public Random rnd;
        public int countOfPeople;
        public char[] sexes;

        public Cinema(int x, int y, int countOfPeople)
        {
            humans = new Human[x, y];
            rnd = new Random();
            this.countOfPeople = countOfPeople;
            sexes = new char[2] { 'M', 'F' };
        }
        public void SetPeople()
        {
            int x, y;
            for (int i = 0; i < countOfPeople; i++)
            {
                while (true)
                {
                    x = rnd.Next(0, humans.GetLength(0));
                    y = rnd.Next(0, humans.GetLength(1));
                    if (humans[x, y].Age == 0)
                    {
                        humans[x, y] = new Human { Age = rnd.Next(8, 99), Sex = sexes[rnd.Next(0, 2)] };
                        break;
                    }
                }
            }
        }
        public void PrintCinema()
        {
            for (int i = 0; i < humans.GetLength(0); i++)
            {
                for (int j = 0; j < humans.GetLength(1); j++)
                {
                    if (humans[i,j].Age==0)
                        Console.Write(" - ");
                    else
                        Console.Write($" {humans[i,j].Sex} ");
                }
                Console.WriteLine();
            }
            //for (int i = 0; i < humans.GetLength(0); i++)
            //{
            //    for (int j = 0; j < humans.GetLength(1); j++)
            //    {
            //        if (humans[i, j].Age == 0)
            //            Console.Write(" - ");
            //        else
            //            Console.Write($" {humans[i, j].Age} ");
            //    }
            //    Console.WriteLine();
            //}
        }

        public void PrintStatistic()
        {
            float midagemale= 0;
            float midagefemale = 0;
            int male = 0;
            int female = 0;
            for (int i = 0; i < humans.GetLength(0); i++)
            {
                for (int j = 0; j < humans.GetLength(1); j++)
                {
                    if (humans[i, j].Sex == 'M')
                    {
                        male++;
                        midagemale += humans[i, j].Age;
                    }
                    else if (humans[i, j].Sex == 'F')
                    {
                        female++;
                        midagefemale += humans[i, j].Age;
                    }
                }
            }
        Console.WriteLine($" people = {countOfPeople}, midage = {(midagemale+midagefemale)/countOfPeople}, M = {male}, F= {female}, midM = {midagemale/male}, midF={midagefemale/female}" );
        }
}

    class Program
    {
        //static void PrintCinema(Cinema cinema)
        //{
        //    for (int i = 0; i < cinema.humans.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < cinema.humans.GetLength(1); j++)
        //        {
        //            if (cinema.humans[i, j].Age == 0)
        //                Console.Write(" - ");
        //            else
        //                Console.Write($" {cinema.humans[i, j].Sex} ");
        //        }
        //        Console.WriteLine();
        //    }
        //}
        static void Main(string[] args)
        {
            //Human[,] human = new Human[8, 8];
            //Random rand = new Random();
            //int countOfPeople = rand.Next(18, 64);
            //char[] sexes = {'M', 'F' };
            //char empty = '-';
            //for (int i = 0; i < countOfPeople; i++)
            //{
            //    while (true)
            //    {
            //        int x = rand.Next(0, 8);
            //        int y = rand.Next(0, 8);
            //        if (human[x, y].Age == 0)
            //        {
            //            human[x, y] = new Human { Age = rand.Next(12, 100), Sex = sexes[rand.Next(0, 2)] };

            //        }
            //        else 
            //            human[x,y] = new Human { Age = 1, Sex = empty};

            //    }
            //}
            //    for (int i = 0; i < human.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < human.GetLength(1); j++)
            //        {
            //            Console.Write($"{human [i,j].Sex}   ");
            //        }
            //    Console.WriteLine();
            //    }
            Cinema cinema = new Cinema(5,5,15);
            cinema.SetPeople();
            cinema.PrintCinema();
            Console.WriteLine();

            Cinema cinema2 = new Cinema(5,10,50);
            cinema2.SetPeople();
            cinema2.PrintCinema();

            //PrintCinema(cinema);
            //PrintCinema(cinema2);
            cinema.PrintStatistic();
            cinema2.PrintStatistic();
        }
    }
}

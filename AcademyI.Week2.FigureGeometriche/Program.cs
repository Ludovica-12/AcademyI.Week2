using System;

namespace AcademyI.Week2.FigureGeometriche
{
    //Scrivere un programma che calcola perimetro e area delle seguenti figure geometriche
    //Tutte le figure geometriche hanno una proprietà Nome 
    //Cerchio -> coordinate del centro, raggio
    //Rettangolo -> base, altezza
    //Triangolo ->base, altezza, lato1, lato2

    // Tutte le figure geometriche hanno un metodo che stampa il nome,
    // un metodo che stampa il perimetro e
    // un metodo che stampa l'area

    class Program
    {
        static void Main(string[] args)
        {
            //Cerchio

            Cerchio cerchio = new Cerchio();
            cerchio.Nome = "Cerchio";

            Centro centro = new Centro();
            centro.X = 5;
            centro.Y = 2.2;
            cerchio.Coordinate = centro;

            cerchio.Raggio = 12;

            Console.WriteLine($"{cerchio.PrintNome()}");
            Console.WriteLine($"{cerchio.PrintPerimetro()}");
            cerchio.CalcolaArea();
            Console.WriteLine($"{cerchio.PrintArea()}");

            //Rettangolo

            Rettangolo rettangolo = new Rettangolo();
            rettangolo.Nome = "Rettangolo";
            rettangolo.Base = 7.5;
            rettangolo.Altezza = 14.3;

            Console.WriteLine($"{rettangolo.PrintNome()}");
            Console.WriteLine($"{rettangolo.PrintPerimetro()}");
            rettangolo.CalcolaArea();
            Console.WriteLine($"{rettangolo.PrintArea()}");

            //Triangolo

            Triangolo triangolo = new Triangolo();
            triangolo.Nome = "Triangolo";
            triangolo.Lato1 = 6;
            triangolo.Lato2 = 9;
            triangolo.Base = 10;
            triangolo.Altezza = 4.5;

            Console.WriteLine($"{triangolo.PrintNome()}");
            Console.WriteLine($"{triangolo.PrintPerimetro()}");
            triangolo.CalcolaArea();
            Console.WriteLine($"{triangolo.PrintArea()}");




        }
    }
}

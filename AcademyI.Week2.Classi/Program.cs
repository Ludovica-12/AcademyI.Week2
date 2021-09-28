using System;

namespace AcademyI.Week2.Classi
{
    class Program
    {
        static void Main(string[] args)
        {

            Padre p = new Padre();
            p.Id = 1;
            p.Nome = "Padre";

            Figlia f = new Figlia();
            f.Id = 2;
            f.Nome = "Figlia";
            f.Cognome = "Cognome della figlia";

            p.Stampa();
            f.Stampa();













            LaMiaClasse lmc = new LaMiaClasse(); //Chiamo costruttore senza parametri

            lmc.Id = 3; //Set -> salvami il valore 3 alla proprietà Id

            int id = lmc.Id; // Get -> Dammi il valore della proprietà Id

            lmc.Eta = 1995;

            var eta = lmc.Eta;

            var Nome = lmc.Nome;
            lmc.nome = "Ludovica"; //get 

            /* var cognome = lmc.Cognome;*/ //->get
            lmc.Cognome = "Lucidi";

           /* lmc = null;*/ //Libero le risorese e questa variabile non esiste più


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.Classi
{
    //Classe è un reference type e utilizza dei puntatori

    class LaMiaClasse
    {
        //La classe può avere dei campi che sono semplicemnte delle variabili

        public int count;
        public string nome;

        public int id;
        public int eta;

        //Può avere delle proprietà
        public int Id { get; set; } //get-> dammi il valore della proprietà
                                    //set-> settami questa proprietà
                                    //Sono delle abbreviazioni di:
        
        public int IdEsplicito
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public int Eta
        {
            get
            {
                return eta;
            }
            set
            {
                eta = DateTime.Now.Year - value;
            }
        }

        public string Nome { get; private set; }

        public string Cognome { private get; set; }

        //Costruttori
        //Se non li definisco i costruttori "base" esiste implicitamente
        //Mi obbliga a passare dei parametri quando voglio istanziare un oggetto

        public LaMiaClasse()
        {

        }

        public LaMiaClasse(int id)
        {
            Id = id;
        }

        //Metodi

        public string StampaNome()
        {
            return $"{Nome}";
        }

        // Distruttori

        ~LaMiaClasse()
        {
            // Fa in maniera implicita ->  lmc = null;
        }



    }
}

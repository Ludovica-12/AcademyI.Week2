using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.Classi
{
    public abstract class Padre
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public string Stampa()
        {
            return $"{Id} - {Nome}";
        }

        //Metodi astratti
        public abstract void CalcolaEta(); //I figli DEVONO avere e implemntare il metodo
                                           //per avere il metodo astratto anche la classe deve essere astratta
                                           //essendo astratta non può esssere istanziata
        
        //Metodo Virtual
        public virtual string Saluta() //Do la possibilità di eseguire l'override
        {
            return $"Ciao a tutti";
        }

    }
}

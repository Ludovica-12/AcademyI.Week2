using AcademyI.Week2.GestioneEsami.Core.BusinessLayer;
using AcademyI.Week2.GestioneEsami.Core.Entities;
using AcademyI.Week2.GestionEsami.Mock;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyI.Week2.GestioneEsami
{ 
    /*Creare una Console App che gestisca l’iscrizione ad un esame di uno Studente.
Lo studente è definito con:
• Nome ->string
• Cognome -string
• AnnoDiNascita ->int
• Immatricolazione -> altra classe definita
• Esami -> Lista di corsi
• RichiestaLaurea -> bool

L’immatricolazione ha le seguenti caratteristiche:
• Matricola -> int
• DataInizio ->DateTime
• CorsoDiLaurea -> altra classe definita
• FuoriCorso ->bool
• CFUAccumulati ->int

Un Corso di laurea è dato da un 
    Nome, -> enum
    AnniDiCorso, -> int
    i cfu per ottenere la laurea lista di corsi associati. -> altra classe

Un Corso ha un 
    nome -> stringa
    dei CFU ->int

Un Esame si riferisce ad un corso e tiene conto se esso è stato passato.

I possibili nomi dei Corsi di Laurea possono essere solo i seguenti: 
    Matematica, 
    Fisica, 
    Informatica,
    Ingegneria, 
    Lettere.

La matricola dello studente deve essere univoca, autogenerata e read-only.
Uno studente può richiedere un esame solo se esso è presente nel Corso di Laurea associato allo studente,
se i CFU del corso associato all’esame non superino i CFU massimi del Corso di laurea e se non ha il flag
RichiestaLaurea assegnato a vero.
Nel caso le condizioni siano verificate, lo studente aggiunge l’esame alla lista Esami.
Scrivere inoltre un metodo EsamePassato che, dato un esame, vada ad aggiornare i CFU accumulati dallo
studente, metta il flag Passato sull’esame e verifichi se con tale esame sono stati raggiunti i CFU necessari
per richiedere la laurea (e quindi metta il flag Richiestalaurea a true);*/

    class Program
    {
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryCorsi(), new RepositoryCorsiDiLaurea(), 
                            new RepositoryImmatricolazione(), new RepositoryStudenti(), new RepositoryEsami());

        static void Main(string[] args)
        {
            bool continuare = true;
            int scelta;
            bool uscita = true;

            Studente s = new Studente();
            do
            {
                do
                {
                    Console.WriteLine("Premi 1 per immatricolarti");
                    Console.WriteLine("Premi 2 per accedere");
                    Console.WriteLine("Premi 3 per iscriverti ad un esame");
                    Console.WriteLine("Premi 0 per uscire");

                    continuare = int.TryParse(Console.ReadLine(), out scelta);

                } while (continuare);


                switch (scelta)
                {
                    case '1':
                        s = Immatricolazione();
                        break;
                    case '2':
                        s = Accedi(s);
                        break;
                    case '3':
                        IscriversiAdUnEsame(s);
                        break;
                    case '0':
                        uscita = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata");
                        break;
                }
            } while (uscita);

        }

        private static Studente Accedi(Studente s)
        {
            string nome, cognome;
            int matricolaDaInserire;
            bool continuare = true;
            do
            {
                Console.WriteLine("inserisci nome:");
                nome = Console.ReadLine();
                if (!String.IsNullOrEmpty(nome))

                    continuare = false;
            } while (continuare);



            continuare = true;
            do
            {
                Console.WriteLine("inserisci cognome:");

                cognome = Console.ReadLine();
                if (!String.IsNullOrEmpty(cognome))

                    continuare = false;
            } while (continuare);



            continuare = true;
            do
            {
                Console.WriteLine("inserisci la tua matricola:");
                continuare = int.TryParse(Console.ReadLine(), out matricolaDaInserire);

            } while (!continuare);



            List<Studente> studenti = new List<Studente>();
            foreach (var studente in studenti)
            {
                if ((nome == studente.Nome) && (cognome == studente.Cognome) &&
                (matricolaDaInserire == studente._Immatricolazione.Matricola))
                {
                    Console.WriteLine("LoginEffettuato");
                }
                else
                {
                    Console.WriteLine("credenziali inesistenti o non valide");
                }
            }
            return s;
        }

        private static void IscriversiAdUnEsame(Studente s)
        {
            var immatricolazione = s._Immatricolazione;
            var corsoDiLaurea = immatricolazione._CorsoDiLaurea;
            var corsi = corsoDiLaurea.Corsi;

            foreach (var corso in corsi)
            {
                Console.WriteLine(corso.Print());
            }

            string esame = String.Empty;
            Corso corsoScelto;

            do
            {
                Console.WriteLine("A quale esame vuoi iscriverti?");
                esame = Console.ReadLine();

                corsoScelto = corsi.Where(c => c.Nome == esame).SingleOrDefault();

            } while (corsoScelto == null);

            bool possibileIscriversi = bl.VerificaCfuPerIscrizioneEsame(corsoScelto, s);

            if (possibileIscriversi)
            {
                Esame esameDaSostenere = new Esame();
                esameDaSostenere.Nome = corsoScelto.Nome;
                esameDaSostenere.Passato = false;
                esameDaSostenere.IdStudente = s.Id;
                esameDaSostenere = bl.AggiungiEsame(esameDaSostenere); //Insert + return id;


                bool esamePassato = bl.RandomEsamePassato(esameDaSostenere); //esameDaSostenere.Passato = true;

                if (esameDaSostenere.Passato)
                {
                    bl.UpdateEsamePassato();
                }

            }
        }

        private static Studente Immatricolazione()
        {
            string nome = String.Empty;
            bool continuare = true;

            do
            {
                Console.WriteLine("Inserisci il tuo nome");
                nome = Console.ReadLine();

                if (!String.IsNullOrEmpty(nome))
                    continuare = false;

            } while (continuare);

            string cognome = String.Empty;
            continuare = true;

            do
            {
                Console.WriteLine("Inserisci il tuo cognome");
                cognome = Console.ReadLine();

                if (!String.IsNullOrEmpty(cognome))
                    continuare = false;

            } while (continuare);

            int annoNascita;
            continuare = true;

            do
            {
                Console.WriteLine("Inserisci l'anno di nascita");
                continuare = int.TryParse(Console.ReadLine(), out annoNascita);

            } while (!continuare);

            Studente s = new Studente(nome, cognome, annoNascita);

            List<CorsoDiLaurea> corsiDiLaurea = bl.FetchCorsiDiLaurea();

            foreach (var corsoDiLaurea in corsiDiLaurea)
            {
                Console.WriteLine(corsoDiLaurea.Print());
            }

            var nomeCdL = Console.ReadLine();

            CorsoDiLaurea cdl = corsiDiLaurea.Where(c => c.Nome == nomeCdL).SingleOrDefault();

            s = bl.CreaImmatricolazione(s, cdl);
            Console.WriteLine();

            //bl.GetCorsi(cdl);

            return s;

        }
    }
}

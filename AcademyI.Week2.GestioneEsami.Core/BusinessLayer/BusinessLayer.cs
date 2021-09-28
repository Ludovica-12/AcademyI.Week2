using AcademyI.Week2.GestioneEsami.Core.Entities;
using AcademyI.Week2.GestioneEsami.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyI.Week2.GestioneEsami.Core.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryCorsi corsiRepo;
        private readonly IRepositoryCorsiDiLaurea corsiDiLaureaRepo;
        private readonly IRepositoryImmatricolazione immatricolazioneRepo;
        private readonly IRepositoryStudenti studentiRepo;
        private readonly IRepositoryEsami esamiRepo;

        public BusinessLayer(IRepositoryCorsi corsi, IRepositoryCorsiDiLaurea corsiDiLaurea,
            IRepositoryImmatricolazione immatricolazione, IRepositoryStudenti studenti, IRepositoryEsami esami)
        {
            corsiRepo = corsi;
            corsiDiLaureaRepo = corsiDiLaurea;
            immatricolazioneRepo = immatricolazione;
            studentiRepo = studenti;
            esamiRepo = esami;
        }

        public Esame AggiungiEsame(Esame esameDaSostenere)
        {
            esamiRepo.AddEsami(esameDaSostenere);
            return esameDaSostenere;
        }

        public Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl)
        {
            Immatricolazione imm = new Immatricolazione();
            imm.DataInizio = DateTime.Now;
            imm._CorsoDiLaurea = GetCorsi(cdl);

            int ore = imm.DataInizio.Hour;
            int minuti = imm.DataInizio.Minute;
            var secondi = imm.DataInizio.Second;
            var matricola = String.Concat(ore, minuti, imm.Id);

            imm.Matricola = Convert.ToInt32(matricola);

            immatricolazioneRepo.Insert(imm);
            imm = immatricolazioneRepo.GetByDate(imm);           

            s._Immatricolazione = imm;

            s.IdImmatricolazione = imm.Id;
            s._Immatricolazione= imm;

            s.Id = studentiRepo.Insert(s);

            return s;
        }

        public List<CorsoDiLaurea> FetchCorsiDiLaurea()
        {
            return corsiDiLaureaRepo.Fetch();
        }

        public CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl)
        {
            List<Corso> corsi = corsiRepo.GetCorsiByCorsoDiLaurea(cdl);
            cdl.Corsi = corsi;
            var cfuTotali = corsi.Sum(c => c.CreditiFormativi);
            cdl.Cfu = cfuTotali;

            return cdl;
        }

        public bool RandomEsamePassato(Esame esameDaSostenere)
        {
            Random random = new Random();
            bool esamePassato = Convert.ToBoolean(random.Next(1));

            return esamePassato;
            
        }

        public void UpdateEsamePassato()
        {
            throw new NotImplementedException();
        }

        public bool VerificaCfuPerIscrizioneEsame(Corso corsoScelto, Studente s)
        {
            var cfuOk = s._Immatricolazione.CfuAccumulati + corsoScelto.CreditiFormativi <= s._Immatricolazione._CorsoDiLaurea.Cfu;

            if (cfuOk && s.LaureaRichiesta)
                return true;
            else
                return false;
        }
    }
}

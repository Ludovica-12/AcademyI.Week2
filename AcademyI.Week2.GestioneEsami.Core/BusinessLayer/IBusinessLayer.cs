using AcademyI.Week2.GestioneEsami.Core.Entities;
using System.Collections.Generic;

namespace AcademyI.Week2.GestioneEsami.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<CorsoDiLaurea> FetchCorsiDiLaurea();
        CorsoDiLaurea GetCorsi(CorsoDiLaurea cdl);
        Studente CreaImmatricolazione(Studente s, CorsoDiLaurea cdl);
        bool VerificaCfuPerIscrizioneEsame(Corso corsoScelto, Studente s);
        Esame AggiungiEsame(Esame esameDaSostenere);
        bool RandomEsamePassato(Esame esameDaSostenere);
        void UpdateEsamePassato();
    }
}
using Data.Code.Medias;
using System;

namespace Data.Code
{
    public class Emprunt
    {
        #region Privates Members
        public string m_MediaName { get; set; }
        public int m_MediaNumRef { get; set; }
        public string m_NomUtilisateur { get; set; }
        public DateTime m_DateEmprunt { get; set; }
        public DateTime m_DateEcheance { get; set; }
        public bool m_Retourne { get; set; }
        public DateTime m_DateRetour { get; set; }
        #endregion

        #region Public Méthodes : accesseurs
        public string GetMediaName()
        {
            return m_MediaName;
        }

        public int GetMediaNumRef()
        {
            return m_MediaNumRef;
        }

        public string GetNomUtilisateur()
        {
            return m_NomUtilisateur;
        }

        public DateTime GetDateEmprunt()
        {
            return m_DateEmprunt;
        }

        public DateTime GetDateEcheance()
        {
            return m_DateEcheance;
        }

        public DateTime GetDateRetour()
        {
            return m_DateRetour;
        }

        public void SetDateRetour(DateTime p_DateDeRetour)
        {
            m_DateRetour = p_DateDeRetour;
        }

        public bool IsRetourned()
        {
            return m_Retourne;
        }

        public void SetRetour(bool isRetourne)
        {
            m_Retourne = isRetourne;
        }
        #endregion

        #region Constructeurs
        public Emprunt(Media p_media, string p_nomUtilisateur, DateTime p_dateEmprunt, DateTime p_dateEcheance)
        {
            m_MediaName = p_media.GetTitre();
            m_MediaNumRef = p_media.GetNumeroReference();
            m_NomUtilisateur = p_nomUtilisateur;
            m_DateEmprunt = p_dateEmprunt;
            m_DateEcheance = p_dateEcheance;
        }

        public Emprunt()
        {
        }

        public void AfficherInfos()
        {
            Console.WriteLine($"Titre : {m_MediaName}");
            Console.WriteLine($"Numéro de Référence : {m_MediaNumRef}");
            Console.WriteLine($"Utilisateur : {m_NomUtilisateur}");
            Console.WriteLine($"Date d'emprunt : {m_DateEmprunt}");
            Console.WriteLine($"Date d'écheance : {m_DateEcheance}");
            Console.WriteLine($"Retourné : {(m_Retourne ? "Oui" : "Non")}");
            if(m_Retourne) Console.WriteLine($"Date de retour : {m_DateRetour}");
        }
        #endregion
    }
}
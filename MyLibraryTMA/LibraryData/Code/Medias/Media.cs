using System;

namespace Data.Code.Medias
{
    public class Media
    {
        #region Privates Members
        public string m_Titre { get; set; }
        public int m_NumeroReference { get; set; }
        public int m_NombreExemplairesDisponibles { get; set; }
        #endregion

        #region Constructeur
        public Media(string p_titre, int p_numeroReference, int p_nombreExemplairesDisponibles)
        {
            m_Titre = p_titre;
            m_NumeroReference = p_numeroReference;
            m_NombreExemplairesDisponibles = p_nombreExemplairesDisponibles;
        }

        public Media()
        {
        }
        #endregion

        #region Public Méthodes : accesseurs
        public string GetTitre()
        {
            return m_Titre;
        }

        public int GetNExemplairesDispo()
        {
            return m_NombreExemplairesDisponibles;
        }

        public int GetNumeroReference()
        {
            return m_NumeroReference;
        }
        #endregion

        #region Public Méthodes : Tools
        public virtual void AfficherInfos()
        {
            Console.WriteLine($"Titre : {m_Titre}");
            Console.WriteLine($"Numéro de Référence : {m_NumeroReference}");
            Console.WriteLine($"Nombre d'Exemplaires Disponibles : {m_NombreExemplairesDisponibles}");
        }

        public void AddExemplaire()
        {
            m_NombreExemplairesDisponibles++;
        }

        public void TakeOffExemplaire()
        {
            m_NombreExemplairesDisponibles--;
        }
        #endregion
    }

}
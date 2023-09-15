using System;

namespace Data.Code.Medias
{
    public class Livre : Media
    {
        #region Privates Members
        private string m_Auteur { get; set; }
        #endregion

        #region Constructeur
        public Livre(string p_titre, int p_numeroReference, int p_nombreExemplairesDisponibles, string p_auteur)
            : base(p_titre, p_numeroReference, p_nombreExemplairesDisponibles)
        {
            m_Auteur = p_auteur;
        }
        #endregion

        #region Public M�thodes : accesseurs
        public string GetAuteur()
        {
            return m_Auteur;
        }
        #endregion

        #region Public M�thodes : Tools
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Auteur : {m_Auteur}");
        }
        #endregion
    }
}
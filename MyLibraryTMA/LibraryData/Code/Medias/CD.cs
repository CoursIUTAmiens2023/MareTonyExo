using System;

namespace Data.Code.Medias
{
    public class Cd : Media
    {
        #region Privates Members
        public string m_Artiste { get; set; }
        #endregion

        #region Constructeur
        public Cd(string p_titre, int p_numeroReference, int p_nombreExemplairesDisponibles, string p_artiste)
            : base(p_titre, p_numeroReference, p_nombreExemplairesDisponibles)
        {
            m_Artiste = p_artiste;
        }
        #endregion

        #region Public Méthodes : accesseurs
        /// <summary>
        /// 
        /// </summary>
        /// <returns>string</returns>
        public string GetArtiste()
        {
            return m_Artiste;
        }
        #endregion

        #region Public Méthodes : Tools
        public override void AfficherInfos()
        {
            base.AfficherInfos();
            Console.WriteLine($"Artiste : {m_Artiste}");
        }
        #endregion
    }

}
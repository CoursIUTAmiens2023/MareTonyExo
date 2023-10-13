using Code.LibraryManager;
using Data.Code.Medias;

namespace LibraryBDD.StepDefinitions
{
    [Binding]
    public sealed class LibraryStepDefinitions
    {
        private Library m_Library;
        private string m_MediaName;
        private string m_UserName;
        private int m_NbExemplaire;
        private Media m_MediaTest;
        private Interface m_menu;

        public void Init()
        {
            m_Library = new Library();
            m_menu = new Interface(m_Library);
            m_MediaName = "Media de test";
            m_MediaTest = new Media(m_MediaName, 1502, 17);
            m_UserName = "Tony Maré";
            m_NbExemplaire = 17;
        }
        public void Clean()
        {
            m_Library = new Library();
        }

    }
}
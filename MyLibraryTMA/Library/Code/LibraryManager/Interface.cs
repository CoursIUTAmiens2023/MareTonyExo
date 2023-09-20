using Data.Code;
using Data.Code.Medias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Code.LibraryManager
{
    internal class Interface
    {
        internal Library m_Library;

        public Interface(Library library)
        {
            m_Library = library;
        }

        public enum ResponseType
        {
            Choice,
            String,
            Integer
        }
        public void MainMenu()
        {
            string v_response = GetUserResponse(ResponseType.Choice, String.Concat(
                "# 1. Ajout d'un média à la librairie.", "\n",
                "# 2. Retirer un média à la librairie.", "\n",
                "# 3. Nouvel emprunt.", "\n",
                "# 4. Retour emprunt.", "\n",
                "# 5. Afficher les médias.", "\n",
                "# 6. Afficher les emprunts.", "\n",
                "# 7. Rechercher un média.", "\n",
                "# 8. Recherche un emprunt.", "\n",
                "# 9. Charger les informations de la librairie.", "\n",
                "# 10. Sauvegarder les informations de la librairie.", "\n",
                "# 11. Quitter.", "\n"
                ),
                11
            );

            switch (v_response)
            {
                case "1":
                    AjouterMedia();
                    WaitToMenu();
                    break;
                case "2":
                    RetirerMedia();
                    WaitToMenu();
                    break;
                case "3":
                    NouvelEmprunt();
                    WaitToMenu();
                    break;
                case "4":
                    RetourEmprunt();
                    WaitToMenu();
                    break;
                case "5":
                    AfficherMedia();
                    WaitToMenu();
                    break;
                case "6":
                    AfficherEmprunt();
                    WaitToMenu();
                    break;
                case "7":
                    RechercherMedia();
                    WaitToMenu();
                    break;
                case "8":
                    RechercherEmprunt();
                    WaitToMenu();
                    break;
                case "9":
                    Charger();
                    WaitToMenu();
                    break;
                case "10":
                    Sauvegarder();
                    WaitToMenu();
                    break;
                case "11":
                    Quitter();
                    break;
                default:
                    ;
                    break;
            }
        }

        public void WaitToMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }

        private void AjouterMedia()
        {            
            string v_typeMedia = GetUserResponse(ResponseType.Choice, String.Concat(
                "# Quelle Média souhaitez-vous ajouter ?", "\n",
                "# 1. Livre", "\n",
                "# 2. CD", "\n",
                "# 3. DVD", "\n",
                "# 4. Quitter.", "\n"
                )
            );
            string v_titre = GetUserResponse(ResponseType.String, "# Quel en est le titre ?");
            string v_reference = GetUserResponse(ResponseType.Integer, "# Quel en est le numéro de référence ?");
            int v_intReference = int.Parse(v_reference);
            string v_exemplaire = GetUserResponse(ResponseType.Integer, "# Combien d'exemplaire sont ajoutés ?");
            int v_intExemplaire = int.Parse(v_exemplaire);
            switch (v_typeMedia)
            {
                case "1":                     
                    string v_auteur = GetUserResponse(ResponseType.String, "# Quel en est l'auteur ?");
                    m_Library.AjouterMedia(new Livre(v_titre, v_intReference, v_intExemplaire, v_auteur));
                    break;
                case "2":
                    string v_artiste = GetUserResponse(ResponseType.String, "# Quel en est l'artiste ?");
                    m_Library.AjouterMedia(new Cd(v_titre, v_intReference, v_intExemplaire, v_artiste));
                    break;
                case "3":
                    string v_duree = GetUserResponse(ResponseType.Integer, "# Quel en est la durée (en minutes) ?");
                    int v_intDuree = int.Parse(v_exemplaire);
                    m_Library.AjouterMedia(new Dvd(v_titre, v_intReference, v_intExemplaire, v_intDuree));
                    break;
                default: Console.WriteLine("ERREUR");
                    break;
            }
            
        }

        private void RetirerMedia()
        {
            Media v_media = new Media();
            v_media = RechercherMedia();
            m_Library.RetirerMedia(v_media);
        }

        private void NouvelEmprunt()
        {
            Media v_media = new Media();
            v_media = RechercherMedia();
            m_Library -= v_media;
        }

        private void RetourEmprunt()
        {
            Media v_media = new Media();
            v_media = m_Library[RechercherEmprunt().GetMediaNumRef()];
            m_Library += v_media;
        }

        private void AfficherMedia()
        {
            m_Library.AfficherTousLesMedias();
        }

        private void AfficherEmprunt()
        {
            m_Library.AfficherTousLesEmprunts();
        }

        private Media RechercherMedia()
        {
            Media v_media = new Media();
            string v_result = String.Empty;
            string v_typeSearch = GetUserResponse(ResponseType.Choice, String.Concat(
                "# Rechercher un média :", "\n",
                "# 1. Par titre", "\n",
                "# 2. Par numéro de référence", "\n",
                "# 4. Quitter.", "\n"
                )
            );
            
            if (v_typeSearch == "1")
            {
                v_result = GetUserResponse(ResponseType.String, "# Quel en est le titre ?");
                v_media = m_Library[v_result];
            }
            else if(v_typeSearch == "2")
            {
                v_result = GetUserResponse(ResponseType.Integer, "# Quel en est le numéro de référence ?");
                v_media = m_Library[int.Parse(v_result)];
            }
            return v_media;

        }

        private Emprunt RechercherEmprunt()
        {
            Emprunt v_emprunt = new Emprunt();
            string v_resultUsr, v_resultNmref = String.Empty;
            string v_typeSearch = GetUserResponse(ResponseType.Choice, String.Concat(
                "# Rechercher un emprunt :", "\n",
                "# 1. Saisir l'utilisateur et le numéro de référence du média", "\n",
                "# 2. Quitter.", "\n"
                )
            );

            if (v_typeSearch == "1")
            {
                v_resultUsr = GetUserResponse(ResponseType.String, "# Quel en est l'utilisateur ?");
                v_resultNmref = GetUserResponse(ResponseType.Integer, "# Quel en est le numéro de référence ?");
                v_emprunt = m_Library.RechercherEmpruntParNumeroDeReference(int.Parse(v_resultNmref), v_resultUsr).FirstOrDefault();
            }

            return v_emprunt;
        }

        private void Charger()
        {
            m_Library.LoadLibrary();
        }

        private void Sauvegarder()
        {
            m_Library.SaveLibrary();
        }

        private void Quitter()
        {
            Console.WriteLine();
        }

        public string GetUserResponse(ResponseType responseType, string p_questions, int p_choiceLimite = 0)
        {
            string v_response, v_pattern = String.Empty;
            bool IsGood = false;
            do
            {
                Console.WriteLine("##### PROGRAMME LIBRAIRIE #####");
                Console.WriteLine(p_questions);
                v_response = Console.ReadLine();
                Console.Clear();

                switch (responseType)
                {
                    case ResponseType.String:
                        v_pattern = @"^[a-zA-Z0-9]{*}$";
                        break;
                    case ResponseType.Integer:
                        v_pattern = @"^[0-9]{*}$";
                        break;
                    case ResponseType.Choice:
                        if(p_choiceLimite < 10)
                        {
                            v_pattern = @"^[0-" + p_choiceLimite + "]{1}$";
                        }
                        else
                        {
                            v_pattern = @"^[0-9]{2}$";
                        }
                        
                        break;                        
                }
                if (Regex.IsMatch(v_response, v_pattern))
                {
                    IsGood = true;
                }
            }
            while (v_response == String.Empty && !IsGood);
            return v_response;
        }
    }
}

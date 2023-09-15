using System;
using System.Collections.Generic;
using System.IO;
using Data.Code.Medias;
using System.Text.Json;
using LibraryData.Code;

namespace Data.Code.Tools
{
    public class DataManager
    {
        private readonly Constantes m_constantes = new Constantes();
        // Méthode pour sauvegarder l'état de la bibliothèque dans un fichier JSON
        public void SauvegarderBibliothèque(List<Media> p_medias, List<Emprunt> p_emprunts)
        {
            // Sérialisez la bibliothèque et les emprunts en JSON
            string json = JsonSerializer.Serialize(p_medias);
            // Écrivez le JSON dans un fichier
            File.WriteAllText($"{m_constantes.NOM_FICHIER}_Medias.json", json);
            // Sérialisez la bibliothèque et les emprunts en JSON
            json = JsonSerializer.Serialize(p_emprunts);
            // Écrivez le JSON dans un fichier
            File.WriteAllText($"{m_constantes.NOM_FICHIER}_Emprunts.json", json);
        }

        // Méthode pour charger la bibliothèque à partir d'un fichier JSON
        public void ChargerBibliothèque(out List<Media> Medias, out List<Emprunt> Emprunts)
        {
            Medias = new List<Media>();
            Emprunts = new List<Emprunt>();

            if (File.Exists($"{m_constantes.NOM_FICHIER}_Medias.json"))
            {
                // Lisez le contenu du fichier JSON
                string json = File.ReadAllText($"{m_constantes.NOM_FICHIER}_Medias.json");

                try
                {
                    // Désérialisez la bibliothèque et les emprunts à partir du JSON
                    var data = JsonSerializer.Deserialize<List<Media>>(json);
                    Console.WriteLine($"Médias chargées : {json}");
                    // Remplacez les données actuelles par les données désérialisées
                    if (data != null)
                    {
                        Medias = data;
                    }
                }
                catch(InvalidOperationException ex)
                {
                    Console.WriteLine("Le fichier de sauvegarde des médias est invalide ou corrompu.");
                }                
            }

            if (File.Exists($"{m_constantes.NOM_FICHIER}_Emprunts.json"))
            {
                // Lisez le contenu du fichier JSON
                string json = File.ReadAllText($"{m_constantes.NOM_FICHIER}_Emprunts.json");
                try
                {                
                    // Désérialisez la bibliothèque et les emprunts à partir du JSON
                    var data = JsonSerializer.Deserialize<List<Emprunt>>(json);
                    Console.WriteLine($"Emprunts chargés : {json}");
                    // Remplacez les données actuelles par les données désérialisées
                    if (data != null)
                    {
                        Emprunts = data;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Le fichier de sauvegarde des emprunts est invalide ou corrompu.");
                }
        }
            else
            {
                Console.WriteLine("Le fichier de sauvegarde n'existe pas.");
            }
        }
    }
}

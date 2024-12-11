using System;

namespace Analisateur_text // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Veuillez entrer un texte :");
            string inputText = Console.ReadLine();

            // Vérification si le texte n'est pas vide
            if (string.IsNullOrWhiteSpace(inputText))
            {
                Console.WriteLine("Le texte fourni est vide.");
                return;
            }

            // Étape 2 : Analyse du texte
            AnalyzeText(inputText);
        }
        static void AnalyzeText(string text)
        {
            // Compter les caractères
            int charCount = text.Length;

            // Compter les mots
            string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' },
             StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;

            // Identifier les mots les plus fréquents
            var wordFrequency = words
                .GroupBy(word => word.ToLower()) // Ignorer la casse
                .ToDictionary(group => group.Key, group => group.Count());

            // Trier les mots par fréquence décroissante
            var mostFrequentWords = wordFrequency
                .OrderByDescending(pair => pair.Value)
                .Take(3); // Prendre les 3 mots les plus fréquents

            // Afficher les résultats
            Console.WriteLine($"\nAnalyse du texte :");
            Console.WriteLine($"Nombre total de caractères : {charCount}");
            Console.WriteLine($"Nombre total de mots : {wordCount}");

            Console.WriteLine("\nLes mots les plus fréquents :");
            foreach (var pair in mostFrequentWords)
            {
                Console.WriteLine($"- {pair.Key} : {pair.Value} occurrence(s)");
            }
        }

    }


}

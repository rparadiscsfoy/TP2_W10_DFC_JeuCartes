﻿using System;

namespace TP2
{
    public class Game
    {
        #region Constants
        public const int HEART = 0;
        public const int DIAMOND = 1;
        public const int SPADE = 2;
        public const int CLUB = 3;

        public const int ACE = 0;
        public const int TWO = 1;
        public const int THREE = 2;
        public const int FOUR = 3;
        public const int FIVE = 4;
        public const int SIX = 5;
        public const int SEVEN = 6;
        public const int EIGHT = 7;
        public const int NINE = 8;
        public const int TEN = 9;
        public const int JACK = 10;
        public const int QUEEN = 11;
        public const int KING = 12;

        public const int NUM_SUITS = 4;
        public const int NUM_CARDS_PER_SUIT = 13;
        public const int NUM_CARDS = NUM_SUITS * NUM_CARDS_PER_SUIT;
        public const int NUM_CARDS_IN_HAND = 3;

        public const int FACES_SCORE = 10;
        public const int ACES_SCORE = 11;

        public const int MAX_SCORE = 31;
        public const int ALL_SAME_CARDS_VALUE_SCORE = 30;
        public const int ALL_FACES_SCORE = 30;
        public const int ONLY_FACES_SCORE = 28;
        public const int SAME_COLOR_SEQUENCE_SCORE = 28;
        public const int SEQUENCE_SCORE = 26;
        public const int SAME_COLOR_SCORE = 24;
        #endregion

        public static int GetSuitFromCardIndex(int index)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            return 0;
        }
        public static int GetValueFromCardIndex(int index)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            return 0;
        }

        public static void DrawFaces(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            // PROF : À COMPLETER.
        }
        public static int GetScoreFromCardValue(int cardValue)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            return 0;
        }

        public static int GetHandScore(int[] cardIndexes)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            return 0;
        }

        // A COMPLETER
        // ...
        // Il manque toutes les méthodes pour trouver les différentes combinaisons.
        // Référez-vous aux tests pour les noms de fonctions appropriés.
        // ATTENTION! Suivez bien les noms dans les tests, car je vais utiliser mon propre fichier
        // (qui est exactement comme le vôtre, mais vous ne pourrez pas me faire parvenir un fichier
        // de tests avec vos noms de fonctions).





        public static void ShowScore(int[] cardIndexes)
        {
            int hand = GetHandScore(cardIndexes);
            Display.WriteTextAt($"Votre score est de : {hand}", 0, Display.CARD_HEIGHT + 14, ConsoleColor.Black);
        }
    }
}

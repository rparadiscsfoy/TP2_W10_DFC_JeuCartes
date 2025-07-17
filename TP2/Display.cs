using System.Collections.Generic;

namespace TP2
{
    class Display
    {
        public const int CARD_WIDTH = 30;
        public const int CARD_HEIGHT = 14;
        public const string FULL_BORDER = "*****************************";
        public const string EMPTY_BORDER = "*                           *";

        public const ConsoleColor DEFAULT_COLOR = ConsoleColor.White;

        #region SuitSymbols

        private static readonly string[] HEART_SYMBOL =
        {
            "XX XX",
            "XXXXX",
            "XXXXX",
            " XXX ",
            "  X  ",
        };

        private static readonly string[] DIAMOND_SYMBOL =
        {
            "  X  ",
            " XXX ",
            "XXXXX",
            " XXX ",
            "  X  ",
        };

        private static readonly string[] SPADE_SYMBOL =
        {
            "  X  ",
            " XXX ",
            "XXXXX",
            "X X X",
            " XXX ",
        };

        private static readonly string[] CLUB_SYMBOL =
        {
            " XXX ",
            "XXXXX",
            "XXXXX",
            "X X X",
            " XXX ",
        };

        public static readonly string[][] SUIT_SYMBOLS =
        {
            HEART_SYMBOL,
            DIAMOND_SYMBOL,
            SPADE_SYMBOL,
            CLUB_SYMBOL,
        };

        #endregion

        #region ValueSymbols

        private static readonly string[] ACE_SYMBOL =
        {
            " XXX ",
            "X   X",
            "XXXXX",
            "X   X",
            "X   X",
        };

        private static readonly string[] TWO_SYMBOL =
        {
            "XXXX ",
            "    X",
            " XXX ",
            "X    ",
            "XXXXX",
        };

        private static readonly string[] THREE_SYMBOL =
        {
            " XXX ",
            "X  XX",
            "  XX ",
            "X  XX",
            " XXX ",
        };

        private static readonly string[] FOUR_SYMBOL =
        {
            "X  X ",
            "X  X ",
            "X  X ",
            "XXXXX",
            "   X ",
        };

        private static readonly string[] FIVE_SYMBOL =
        {
            "XXXXX",
            "X    ",
            "XXXX ",
            "    X",
            "XXXX ",
        };

        private static readonly string[] SIX_SYMBOL =
        {
            " XXX ",
            "X    ",
            "XXXX ",
            "X   X",
            " XXX ",
        };

        private static readonly string[] SEVEN_SYMBOL =
        {
            "XXXXX",
            "    X",
            "   X ",
            "  X  ",
            "  X  ",
        };

        private static readonly string[] EIGHT_SYMBOL =
        {
            " XXX ",
            "X   X",
            " XXX ",
            "X   X",
            " XXX ",
        };

        private static readonly string[] NINE_SYMBOL =
        {
            " XXX ",
            "X   X",
            " XXXX",
            "    X",
            "XXXX ",
        };

        private static readonly string[] TEN_SYMBOL =
        {
            "X XXX",
            "X X X",
            "X X X",
            "X X X",
            "X XXX",
        };

        private static readonly string[] JACK_SYMBOL =
        {
            "XXXXX",
            "   X ",
            "   X ",
            "X  X ",
            " XX  ",
        };

        private static readonly string[] QUEEN_SYMBOL =
        {
            " XXX ",
            "X   X",
            "X   X",
            "X  X ",
            " XX X",
        };

        private static readonly string[] KING_SYMBOL =
        {
            "X   X",
            "X  X ",
            "XXX  ",
            "X  X ",
            "X   X",
        };

        public static readonly string[][] VALUE_SYMBOLS =
        {
            ACE_SYMBOL,
            TWO_SYMBOL,
            THREE_SYMBOL,
            FOUR_SYMBOL,
            FIVE_SYMBOL,
            SIX_SYMBOL,
            SEVEN_SYMBOL,
            EIGHT_SYMBOL,
            NINE_SYMBOL,
            TEN_SYMBOL,
            JACK_SYMBOL,
            QUEEN_SYMBOL,
            KING_SYMBOL,
        };

        #endregion

        public static void DrawCard(int value, int suit, int posX, int posY)
        {
            DrawCardBorder(posX, posY);

            // haut gauche
            DrawSuit(posX + 3, posY + 1, suit);

            // Bas droite
            DrawCardValue(posX + 22, posY + 9, value, suit);

            Console.BackgroundColor = ConsoleColor.White;
        }

        private static void DrawCardBorder(int posX, int posY)
        {
            Console.ForegroundColor = ConsoleColor.Black;

            WriteTextAt(FULL_BORDER, posX, posY);
            for (int i = 1; i < CARD_HEIGHT; i++)
            {
                WriteTextAt(EMPTY_BORDER, posX, posY + i);
            }
            WriteTextAt(FULL_BORDER, posX, posY + CARD_HEIGHT);
        }


        public static void DrawSuit(int posX, int posY, int suit)
        {
            ConsoleColor suitColor = suit > Game.DIAMOND ? ConsoleColor.Black : ConsoleColor.Red;

            for (int i = 0; i < SUIT_SYMBOLS[suit].Length; i++)
            {
                for (int j = 0; j < SUIT_SYMBOLS[suit][i].Length; j++)
                {
                    DrawSuitPixel(SUIT_SYMBOLS[suit][i][j], posX + j, posY + i, suitColor);
                }
            }
        }

        public static void DrawSuitPixel(char marker, int posX, int posY, ConsoleColor drawColor)
        {
            DrawColorAt(posX, posY, marker == 'X' ? drawColor : DEFAULT_COLOR);
        }

        public static void DrawCardValue(int posX, int posY, int value, int suit)
        {
            ConsoleColor suitColor = suit > Game.DIAMOND ? ConsoleColor.Black : ConsoleColor.Red;

            for (int i = 0; i < VALUE_SYMBOLS[value].Length; i++)
            {
                for (int j = 0; j < VALUE_SYMBOLS[value][i].Length; j++)
                {
                    DrawSuitPixel(VALUE_SYMBOLS[value][i][j], posX + j, posY + i, suitColor);
                }
            }
        }

        public static void WriteTextAt(string message, int posX, int posY, ConsoleColor color = ConsoleColor.Black)
        {
            Console.SetCursorPosition(posX, posY);
            Console.ForegroundColor = color;
            Console.Write(message);
        }

        public static void DrawColorAt(int posX, int posY, ConsoleColor color = ConsoleColor.Black)
        {
            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = color;
            Console.Write(" ");
        }

        public static void Clear()
        {
            Console.BackgroundColor = DEFAULT_COLOR;
            Console.Clear();
            Console.CursorVisible = false;
        }
        public static void ShowCards(int[] cardValues)
        {
            Clear();
            for (int i = 0; i < cardValues.Length; i++)
            {
                DrawCard(Game.GetValueFromCardIndex(cardValues[i]),
                         Game.GetSuitFromCardIndex(cardValues[i]), i * CARD_WIDTH, 0);
            }
        }

        public static void ShowSelectedMarks(bool[] selectedCards)
        {
            for (int i = 0; i < selectedCards.Length; i++)
            {
                string text = "[ ]";
                if (selectedCards[i])
                    text = "[X]";
                WriteTextAt(text, (CARD_WIDTH - text.Length) / 2 + i * CARD_WIDTH, CARD_HEIGHT + 2, ConsoleColor.Black);
            }
        }
        public static bool IsKeyAvailable()
        {
            return Console.KeyAvailable;
        }
        public static void HighlightText(string message, int posX, int posY)
        {
            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
        }
        public static void SelectCards(bool[] selectedCards)
        {
            ShowSelectedMarks(selectedCards);
            int current = 0;
            String symbol = " ";
            if (selectedCards[current])
                symbol = "X";
            HighlightText(symbol, (Display.CARD_WIDTH - symbol.Length) / 2 + current * Display.CARD_WIDTH, Display.CARD_HEIGHT + 2);

            while (true)
            {
                if (IsKeyAvailable())
                {
                    ConsoleKey currentKey = Console.ReadKey().Key;
                    if (currentKey == ConsoleKey.Enter)
                        break;
                    if (currentKey == ConsoleKey.Tab)
                    {
                        current = (current + 1) % selectedCards.Length;
                    }
                    if (currentKey == ConsoleKey.Spacebar)
                        selectedCards[current] = !selectedCards[current];

                    ShowSelectedMarks(selectedCards);
                    symbol = " ";
                    if (selectedCards[current])
                        symbol = "X";
                    HighlightText(symbol, (CARD_WIDTH - symbol.Length) / 2 + current * CARD_WIDTH, CARD_HEIGHT + 2);
                }
            }
        }
        public static void ShowInstructions()
        {
            WriteTextAt("Appuyez sur espace pour sélectionner/désélectionner la carte.", 0, CARD_HEIGHT + 10, ConsoleColor.Black);
            WriteTextAt("Appuyez sur tab pour passer à la carte suivante.", 0, CARD_HEIGHT + 11, ConsoleColor.Black);
            WriteTextAt("Appuyez sur enter pour relancer les cartes non sélectionnées.", 0, CARD_HEIGHT + 12, ConsoleColor.Black);
        }

        public static void ShowRemainingDraws(int remainingDraws)
        {
            WriteTextAt($"Il vous reste {remainingDraws} relance{AddPlural(remainingDraws)}", 0, CARD_HEIGHT + 13, ConsoleColor.Black);
        }

        public static string AddPlural(int quantity)
        {
            return quantity > 1 ? "s" : "";
        }

    }
}

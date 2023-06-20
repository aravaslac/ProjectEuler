using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex0054
{

    enum Hand
    {
        HighCard, OnePair, TwoPairs, ThreeOfAKind, Straight,
        Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush
    }

    static class HandEvaluator
    {
        static Dictionary<char, int> _cardValues = new Dictionary<char, int>
        {
            {'T', 10 }, {'J', 11 }, {'Q', 12 }, {'K', 13 }, {'A', 14 }
        };
        static HandEvaluator()
        {
            for (int i = 2; i < 10;  i++)
            {
                _cardValues.Add((char)(i + '0'), i);
            }
        }

        public static int GetVictor(List<string> player1, List<string> player2)
        {
            (Hand, int, int) player1Score = GetScore(player1);
            (Hand, int, int) player2Score = GetScore(player2);

            if ((int) player1Score.Item1 > (int)player2Score.Item1)
            {
                return 1;
            }
            if ((int)player1Score.Item1 < (int)player2Score.Item1)
            {
                return 2;
            }

            if (player1Score.Item2 > player2Score.Item2)
            {
                return 1;
            }
            if (player1Score.Item2 < player2Score.Item2)
            {
                return 2;
            }

            if (player1Score.Item3 > player2Score.Item3)
            {
                return 1;
            }
            return 2;
        }

        private static (Hand, int, int) GetScore(List<string> cards)
        {
            //Hand, rank highest, highest card

            //Get card values
            List<int> handCardValues = new List<int>();
            foreach (string card in cards)
            {
                handCardValues.Add(_cardValues[card[0]]);
            }
            handCardValues.Sort();

            //Get repetitions
            Dictionary<char, int> cardCount = new Dictionary<char, int>();
            foreach (string card in cards)
            {
                if (cardCount.ContainsKey(card[0]))
                {
                    cardCount[card[0]]++;
                    continue;
                }
                cardCount[card[0]] = 1;
            }

            //Check if it's a flush
            bool flush = true;
            char suit = cards[0][1];
            for (int i = 1; i < 5; i++)
            {
                if (cards[i][1] !=  suit)
                {
                    flush = false;
                    break;
                }
            }

            //Check if it's a straight
            bool straight = false;
            if (cardCount.Keys.Count == 5)
            {
                straight = true;
                for (int j = 1; j < 5; j++)
                {
                    if (!(handCardValues[j] == handCardValues[j - 1] + 1))
                    {
                        straight = false;
                        break;
                    }
                }
            }

            //Return the type of hand
            if (straight && flush && handCardValues[4] == 14)
            {
                return (Hand.RoyalFlush, 14, 14);
            }

            if (straight && flush)
            {
                return (Hand.StraightFlush, handCardValues[4], handCardValues[4]);
            }

            if (cardCount.ContainsValue(4))
            {
                int quadValue = 0;
                foreach (char key in cardCount.Keys)
                {
                    if (cardCount[key] == 4)
                    {
                        quadValue = _cardValues[key];
                        break;
                    }
                }
                return (Hand.FourOfAKind, quadValue, handCardValues[4]);
            }

            if (cardCount.ContainsValue(3) && cardCount.ContainsValue(2))
            {
                int trioValue = 0;
                foreach (char key in cardCount.Keys)
                {
                    if (cardCount[key] == 3)
                    {
                        trioValue = _cardValues[key];
                        break;
                    }
                }
                return (Hand.FullHouse, trioValue, handCardValues[4]);
            }

            if (flush)
            {
                return (Hand.Flush, handCardValues[4], handCardValues[4]);
            }

            if (straight)
            {
                return (Hand.Straight, handCardValues[4], handCardValues[4]);
            }

            if (cardCount.ContainsValue(3))
            {
                int trioValue = 0;
                foreach (char key in cardCount.Keys)
                {
                    if (cardCount[key] == 3)
                    {
                        trioValue = _cardValues[key];
                        break;
                    }
                }
                return (Hand.ThreeOfAKind, trioValue, handCardValues[4]);
            }

            if (cardCount.Keys.Count == 3)
            {
                int pairValue = 0;
                foreach (char key in cardCount.Keys)
                {
                    if (cardCount[key] == 2 && _cardValues[key] > pairValue)
                    {
                        pairValue = _cardValues[key];
                    }
                }
                return (Hand.TwoPairs, pairValue, handCardValues[4]);
            }

            if (cardCount.Values.Contains(2))
            {
                int pairValue = 0;
                foreach (char key in cardCount.Keys)
                {
                    if (cardCount[key] == 2)
                    {
                        pairValue = _cardValues[key];
                        break;
                    }
                }
                return (Hand.OnePair, pairValue, handCardValues[4]);
            }

            return (Hand.HighCard, handCardValues[4], handCardValues[4]);
        }
    }
}

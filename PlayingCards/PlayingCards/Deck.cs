using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    public class Deck
    {
        private const int DECK_SIZE = 52;
        private Card[] m_deck = new Card[DECK_SIZE];
        private Random rand = new Random(System.DateTime.Now.Millisecond);
        private SortedDictionary<CardValue, int> usedCards = new SortedDictionary<CardValue, int>();
        private SortedDictionary<CardValue, Suit[]> usedSuits = new SortedDictionary<CardValue, Suit[]>();

        public Deck()
        {
            m_deck = CreateDeck();
        }

        public void Shuffle()
        {
            m_deck = new Card[DECK_SIZE];
            usedCards = new SortedDictionary<CardValue, int>();
            usedSuits = new SortedDictionary<CardValue, Suit[]>();
            rand = new Random(System.DateTime.Now.Millisecond);
            m_deck = CreateDeck();
        }

        private Card[] CreateDeck()
        {
            for (int i = 0; i < m_deck.Length; i++)
            {
                setCardsValue(i);
            }
            return m_deck;
        }

        public Card[] getDeck() { return m_deck; }

        public Card drawCard()
        {
            Card returnCard = m_deck[0];
            Card[] remainingCards = new Card[m_deck.Length - 1];

            for (int i = 1; i < m_deck.Length; i++)
            {
                remainingCards[i - 1] = m_deck[i];
            }

            m_deck = new Card[remainingCards.Length];

            for (int i = 0; i < remainingCards.Length; i++)
            {
                m_deck[i] = remainingCards[i];
            }
            return returnCard;
        }

        private void setCardsValue(int i)
        {
            Suit suit = Suit.NONE;

            switch (getRandomValue(1, 14))
            {
                case 1:
                    suit = setSuit(CardValue.A);
                    createCard(CardValue.A, suit, i);
                    break;
                case 2:
                    suit = setSuit(CardValue.TWO);
                    createCard(CardValue.TWO, suit, i);
                    break;
                case 3:
                    suit = setSuit(CardValue.THREE);
                    createCard(CardValue.THREE, suit, i);
                    break;
                case 4:
                    suit = setSuit(CardValue.FOUR);
                    createCard(CardValue.FOUR, suit, i);
                    break;
                case 5:
                    suit = setSuit(CardValue.FIVE);
                    createCard(CardValue.FIVE, suit, i);
                    break;
                case 6:
                    suit = setSuit(CardValue.SIX);
                    createCard(CardValue.SIX, suit, i);
                    break;
                case 7:
                    suit = setSuit(CardValue.SEVEN);
                    createCard(CardValue.SEVEN, suit, i);
                    break;
                case 8:
                    suit = setSuit(CardValue.EIGHT);
                    createCard(CardValue.EIGHT, suit, i);
                    break;
                case 9:
                    suit = setSuit(CardValue.NINE);
                    createCard(CardValue.NINE, suit, i);
                    break;
                case 10:
                    suit = setSuit(CardValue.TEN);
                    createCard(CardValue.TEN, suit, i);
                    break;
                case 11:
                    suit = setSuit(CardValue.J);
                    createCard(CardValue.J, suit, i);
                    break;
                case 12:
                    suit = setSuit(CardValue.Q);
                    createCard(CardValue.Q, suit, i);
                    break;
                case 13:
                    suit = setSuit(CardValue.K);
                    createCard(CardValue.K, suit, i);
                    break;
            }
        }

        private void createCard(CardValue value, Suit suit, int i)
        {
            // If the card value hasn't been entered into the tracker create an entry for it
            if (!usedCards.ContainsKey(value))
            {
                usedCards.Add(value, 1);
                m_deck[i] = new Card(suit, value);
            }
            // if the card has been entered into the tracker and there are less than 4 of them create a new one
            else if (usedCards[value] < 4)
            {
                usedCards[value] += 1;
                m_deck[i] = new Card(suit, value);
            }
            // if the card has been entered into the tracker but there are already 4 of them 
            else
            {
                setCardsValue(i);
            }
        }

        private Suit setSuit(CardValue value)
        {
            Suit suit = Suit.NONE;
            bool breakOut = false;

            // if the card value has not been entered into the tracker create an entry for it and set the array of suits for
            // that card value to null
            if (!usedSuits.ContainsKey(value))
            {
                usedSuits.Add(value, new Suit[4] { Suit.NONE, Suit.NONE, Suit.NONE, Suit.NONE });
            }

            switch (getRandomValue(1, 5))
            {
                case 1:
                    // for the length of the array of suits
                    for (int i = 0; i < usedSuits[value].Length; i++)
                    {
                        // if CLUBS is present, break the for loop
                        if (usedSuits[value][i] == Suit.CLUBS)
                        {
                            breakOut = true;
                        }
                    }

                    if (breakOut)
                    {
                        break;
                    }

                    for (int i = 0; i < usedSuits[value].Length; i++)
                    {
                        if (usedSuits[value][i] == Suit.NONE)
                        {
                            usedSuits[value][i] = Suit.CLUBS;
                            suit = Suit.CLUBS;
                            break;
                        }
                    }

                    break;
                case 2:
                    // if this suit has already been used for this card value fall through the statement
                    for (int i = 0; i < usedSuits[value].Length; i++)
                    {
                        if (usedSuits[value][i] == Suit.DIAMONDS)
                        {
                            breakOut = true;
                        }
                    }

                    if (breakOut)
                    {
                        break;
                    }

                    for (int i = 0; i < usedSuits[value].Length; i++)
                    {
                        if (usedSuits[value][i] == Suit.NONE)
                        {
                            usedSuits[value][i] = Suit.DIAMONDS;
                            suit = Suit.DIAMONDS;
                            break;
                        }
                    }
                    break;
                case 3:
                    // if this suit has already been used for this card value fall through the statement
                    for (int i = 0; i < usedSuits[value].Length; i++)
                    {
                        if (usedSuits[value][i] == Suit.HEARTS)
                        {
                            breakOut = true;
                        }
                    }

                    if (breakOut)
                    {
                        break;
                    }

                    for (int i = 0; i < usedSuits[value].Length; i++)
                    {
                        if (usedSuits[value][i] == Suit.NONE)
                        {
                            usedSuits[value][i] = Suit.HEARTS;
                            suit = Suit.HEARTS;
                            break;
                        }
                    }
                    break;
                case 4:
                    // if this suit has already been used for this card value fall through the statement
                    for (int i = 0; i < usedSuits[value].Length; i++)
                    {
                        if (usedSuits[value][i] == Suit.SPADES)
                        {
                            breakOut = true;
                        }
                    }

                    if (breakOut)
                    {
                        break;
                    }

                    for (int i = 0; i < usedSuits[value].Length; i++)
                    {
                        if (usedSuits[value][i] == Suit.NONE)
                        {
                            usedSuits[value][i] = Suit.SPADES;
                            suit = Suit.SPADES;
                            break;
                        }
                    }
                    break;
            }

            bool allSuitsIssuedToThisValue = true;
            for (int i = 0; i < usedSuits[value].Length; i++)
            {
                if (usedSuits[value][i] == Suit.NONE)
                {
                    allSuitsIssuedToThisValue = false;
                }
            }

            if (!allSuitsIssuedToThisValue && suit == Suit.NONE)
            {
                suit = setSuit(value);
            }

            return suit;
        }

        private int getRandomValue(int inclusiveMin, int exclusiveMax)
        {
            return rand.Next(inclusiveMin, exclusiveMax);
        }
    }
}

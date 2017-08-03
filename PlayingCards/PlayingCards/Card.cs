using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayingCards
{
    public enum Suit
    {
        NONE = 0,
        CLUBS = 1,
        DIAMONDS = 2,
        HEARTS = 3,
        SPADES = 4
    }

    public enum CardValue
    {
        NONE = 0,
        A = 1,
        TWO = 2,
        THREE = 3,
        FOUR = 4,
        FIVE = 5,
        SIX = 6,
        SEVEN = 7,
        EIGHT = 8,
        NINE = 9,
        TEN = 10,
        J = 11,
        Q = 12,
        K = 13
    }

    public class Card
    {
        private Suit m_suit = Suit.NONE;
        private CardValue m_value = CardValue.NONE;

        public Card(Suit suit, CardValue value)
        {
            m_suit = suit;
            m_value = value;
        }

        public string ToString()
        {
            return m_value + " of " + m_suit;
        }

        public Suit getSuit() { return m_suit; }

        public CardValue getCardValue() { return m_value; }
    }
}

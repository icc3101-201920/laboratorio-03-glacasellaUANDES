using Laboratorio_2_OOP_201902;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            this.cards = new List<Card>();
        }

        public List<Card> Cards { get => this.cards; set => this.cards = value; }

        // Como ahora la lista acepta cartas de tipo Card, no es
        // necesario tener dos addCard, podemos ahorrar codigo
        public void AddCard(Card card)
        {
            this.cards.Add(card);
            return;
        }

        // Tampoco hace falta tener dos Destroy, sino uno solo con el cardId
        public void DestroyCard(int cardId)
        {
            cards.RemoveAt(cardId);
            return;
        }

        public void Shuffle()
        { 
            throw new NotImplementedException();
        }
    }
}

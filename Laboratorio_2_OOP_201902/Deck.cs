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

        // para el addCard y el DestroyCard no hace falta tener 4 metodos. Como 
        // la lista acepta tipo card, podemos usar 2 y listo!!! Ahorramos codigo
        public void AddCard(Card card)
        {
            this.cards.Add(card);
        }
        public void DestroyCard(int CardId)
        {
            this.cards.RemoveAt(CardId);
        }
        
        public void Shuffle()
        { 
            throw new NotImplementedException();
        }

    }
}

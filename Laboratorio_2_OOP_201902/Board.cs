using Laboratorio_2_OOP_201902;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Board
    {
        //Constantes
        private const int DEFAULT_NUMBER_OF_PLAYERS = 2;

        //Atributos
        

        private Dictionary<string, List<Card>>[] playerCards;

        private List<SpecialCard> weatherCards;

        //Propiedades
        public Dictionary<string, List<Card>>[] PlayerCards { get => this.playerCards; set => this.playerCards = value; }

        public List<SpecialCard> WeatherCards
        {
            get
            {
                return this.weatherCards;
            }
        }


        //Constructor
        public Board()
        {
            this.weatherCards = new List<SpecialCard>();
            this.playerCards = new Dictionary<string, List<Card>>[
            DEFAULT_NUMBER_OF_PLAYERS]; //Inicializa el arreglo de diccionarios.
            this.playerCards[0] = new Dictionary<string, List<Card>>(); // Inicializa los diccionarios.
            this.playerCards[1] = new Dictionary<string, List<Card>>(); // Inicializa los diccionarios.
        }


        //Metodos
        public void AddCard(Card card, int playerId = -1, string buffType = null)
        {
            //Revisar si la carta recibida en el parmetro es Combat o Special
            if (card.GetType().Name == nameof(CombatCard))
            {

                //En caso de que sea de combate , agregarla al diccionario del jugador correspondiente , revisando el parmetro playerId
                if (playerId == 0 || playerId == 1)
                {
                    //Se revisa si el diccionario ya tiene alguna carta del tipo que se quiere agregar, por ejemplo melee.
                    //Constainskey revisa si existe la llave en el diccionario.En caso de existir retorna true. Por ejemlo, si la carta es de tipo "melee",
                    //el mtodo buscar si existe la llave "melee" en el diccionario.
                    if (playerCards[playerId].ContainsKey(card.Type))
                    {
                        //Si es que existe no es necesario crear la lista cartas, por lo que se agrega directamente
                        playerCards[playerId][card.Type].Add(card);
                    }
                    else
                    {
                        //Si no existe , se agrega un nuevo par "Llave": Valor al diccionario.
                        //Este par tiene como "Llave" el tipo de la carta , ejemplo "melee".
                        //Este par tiene como valor la lista de cartas , con la primera carta que se va a agregar.
                        playerCards[playerId].Add(card.Type , new List<Card>() { card });
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("No player id given");
                }
            }
            else
            {
                // Asumimos que la carta es Special, por el else
                // Revisamos si la carta es captain
                if (card.GetType().Name == "captain")
                {
                    // Revisamos si el playerId es valido
                    if (playerId == 0 || playerId == 1)
                    {
                        // Revisamos si el diccionario ya contiene el key. Como dice el enunciado,
                        // si contiene el key no dejamos que agregue la carta
                        if (playerCards[playerId].ContainsKey("captain"))
                        {
                            throw new Exception("El jugador ya tiene una carta captain");
                        }
                        // Si no, le agregamos el capitan. De esta forma el capitan se agrega una sola vez durante el juego
                        else
                        {
                            playerCards[playerId].Add("captain", new List<Card>() { card });
                        }
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("No player id given");
                    }
                }
                // Revisamos si el tipo de cart es buffer
                else if (card.GetType().Name == "buffer")
                {
                    // Revisamos coincidencias de player Id
                    if (playerId == 0 || playerId == 1)
                    {
                        // Si ya tiene el player card, tiramos un exception
                        if (playerCards[playerId].ContainsKey("buffer" + buffType))
                        {
                            throw new Exception("No se puede agregar la carta");
                        }
                        // SI no, agregamos la carta
                        else
                        {
                            playerCards[playerId].Add("buffer", new List<Card>() { card });
                        }
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("No player id given");
                    }
                }
                else if (card.GetType().Name == "weather")
                {
                    if (playerId == 0 || playerId == 1)
                    {
                        playerCards[playerId]["weather"].Add(card);
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("No player id given");
                    }
                }
            }
        }

        public void DestroyCards()
        {
            //Guardar las cartas de capitan en una variable temporal
            List<Card>[] captainCards = new List<Card>[DEFAULT_NUMBER_OF_PLAYERS]
            {
                new List<Card>(playerCards[0]["captain"]),
                new List<Card>(playerCards[1]["captain"])
            };

            //Destruir todas las cartas
            // Recorremos todas las entrys de los diccionarios de cada jugador y limpiamos las listas
            foreach (KeyValuePair<string, List<Card>> entry in playerCards[0])
            {
                entry.Value.Clear();
            }

            foreach (KeyValuePair<string, List<Card>> entry in playerCards[1])
            {
                entry.Value.Clear();
            }

            //Agregar nuevamente los capitanes
            playerCards[0]["captain"] = captainCards[0];
            playerCards[1]["captain"] = captainCards[1];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public abstract class Card
    {
        //Atributos
        protected string name;
        protected string type;
        protected string effect;

        //Propiedades
        public abstract string Name { get; set; }
        public abstract string Type { get; set; }
        public abstract string Effect { get; set; }
    }
}

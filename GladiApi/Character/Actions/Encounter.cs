using GladiApiLibrary.Character.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GladiApi
{
    /// <summary>
    /// Represents any kind of enemy-encounter
    /// </summary>
    public class Encounter
    {
        protected bool _successful;
        protected int _gold;
        protected int _rubies;

        protected Item _drop;
        protected Item _secondaryDrop;


        public Encounter()
        {
            
        }
    }
}

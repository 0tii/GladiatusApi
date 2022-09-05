using GladiApi;
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
        protected string name;
        protected EncounterType type;
        protected bool successful;
        protected int gold;
        protected int rubies;

        protected BaseItem? primaryDrop;
        protected BaseItem? secondaryDrop;

        protected (int, int)? location;

        public Encounter(EncounterType t, bool success, int g, int r, (int, int) loc)
        {
            type = t;
            gold = g;
            rubies = r;
            successful = success;
            location = loc;
        }

        public Encounter(EncounterType t, bool success, int g, int r)
        {
            type = t;
            gold = g;
            rubies = r;
            successful = success;
        }

        public void AddRubies(int count) => rubies = count;
        public void AddPrimaryDrop(BaseItem item) => primaryDrop = item;
        public void AddSecondaryDrop(BaseItem item) => secondaryDrop = item;

        public EncounterType Type { get => type; }
        public bool Successful { get => successful; }
        public int Gold { get => gold; }
        public int Rubies { get => rubies; }
        public BaseItem? PrimaryDrop { get => primaryDrop; }
        public BaseItem? SecondaryDrop { get => secondaryDrop; }
        public (int, int)? Location { get => location; }
        public string Name { get => name; set => name = value; }
    }
}

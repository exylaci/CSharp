using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteInnerJoinPeldaJegyek
{
    internal class Jegy
    {
        Tanar tanar;
        int id;
        byte jegyErtek;

        internal Tanar Tanar
        {
            get => tanar;
            set => tanar = value;
        }
        public int Id
        {
            get => id;
            set
            {
                if (id == 0)
                {
                    id = value;
                }
                else
                {
                    throw new ArgumentException("A jegy azonosítója nem módosítható!");
                }
            }
        }
        public byte JegyErtek
        {
            get => jegyErtek;
            set
            {
                if (value >= 1 && value <= 5)
                {
                    jegyErtek = value;
                }
                else
                {
                    throw new ArgumentException("A jegy értékének 1 és 5 között kell lennie!");
                }
            }
        }



        public Jegy(byte jegyErtek, Tanar tanar)
        {
            Tanar = tanar;
            JegyErtek = jegyErtek;
        }
        public Jegy(int id, byte jegyErtek, Tanar tanar) : this(jegyErtek, tanar)
        {
            Id = id;
        }

        public override string ToString()
        {
            return JegyErtek.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTermekekDLL
{
    public class LogoltLista : List<InfoTermek>
    {
        public new void Add(InfoTermek item)
        {
            base.Add(item);
            File.AppendAllText("log.txt", "Egy terméket felvettek a listába" + Environment.NewLine);
        }

        public new void Remove(InfoTermek item)
        {
            base.Remove(item);
            File.AppendAllText("log.txt", "Egy terméket érték alapján töröltek a listából" + Environment.NewLine);
        }

        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            File.AppendAllText("log.txt", "Egy terméket index alapján töröltek a listából" + Environment.NewLine);
        }
    }
}

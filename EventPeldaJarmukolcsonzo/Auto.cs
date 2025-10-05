using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPeldaJarmukolcsonzo
{
    public enum MotorTipus
    {
        Otto,
        Diesel,
        Boxer,
        V
    }
    internal class Auto : Jarmu
    {
        MotorTipus tipus;
        public MotorTipus Tipus { get => tipus; private set => tipus = value; }

        public Auto(string rendszam, int futottKm, MotorTipus tipus) : base(rendszam, futottKm)
        {
            Tipus = tipus;
        }
    }
}

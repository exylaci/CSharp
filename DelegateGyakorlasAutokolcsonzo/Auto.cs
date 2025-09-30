using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateGyakorlasAutokolcsonzo
{
    internal class Auto : Jarmu
    {
        public enum MotorTipusok
        {
            Diesel,
            Benzin,
            Hidrogen,
            Elektromos
        }

        MotorTipusok motorTipusa;

        public MotorTipusok MotorTipusa { get => motorTipusa; set => motorTipusa = value; }

        public Auto(string rendszam, MotorTipusok motorTipus) : base(rendszam)
        {
            MotorTipusa = motorTipusa;
        }
        public Auto(string rendszam, int kmora, bool kolcsonozheto, MotorTipusok motorTipus) : base(rendszam, kmora, kolcsonozheto)
        {
            MotorTipusa = motorTipusa;
        }

        public override string ToString()
        {
            return "Autó:   " + base.ToString();
        }

    }
}

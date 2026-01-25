using DependencyInjectedPattern.interfaces;
using System;

namespace DependencyInjectedPattern
{
    public sealed class SystemDateTimeProvider : IDateTimeProvider  //Itt implementáljuk az interfészt, hogy példányosítani lehessen.
    {                                                               //sealed - Jelzés magunknak, hogy nem szeretnénk tovább származtatni
                                                                    //ezért lezárjuk az osztályt.
                                                                    //Pattern osztályt amúgy is mindig lezárjuk, mert a leszármazottja már nem hatékony.)
        public DateTime Now
        {
            get { return DateTime.Now; }                             //A függvény megvalósítása.
        }
    }
}

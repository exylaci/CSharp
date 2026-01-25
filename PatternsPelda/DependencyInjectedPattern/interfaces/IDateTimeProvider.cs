using System;

namespace DependencyInjectedPattern.interfaces
{
    public interface IDateTimeProvider              //Az adattal kapcsolatosan megfogalmazott fontos igényeketre interfészt készítünk.
                                                    //Pattern-t mindig interfésszel kezdjük, így egy későbbi bűvítés esetén innen könnyedén el lehet indulni.
    {
        DateTime Now { get; }                       //Pl.: Kelleni fog a pillanatnyi pontos idő.
    }
}

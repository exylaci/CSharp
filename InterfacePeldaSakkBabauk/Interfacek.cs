namespace InterfacePeldaSakkBabauk
{
    interface IFuggolegesenMozog
    {
        void FuggolegesMozgas(sbyte lepesSzam = 1);
    }

    interface IVizszintesenMozog
    {
        void VizszintesMozgas(sbyte lepesSzam = 1);
    }

    interface IAtlosanMozog
    {
        void AtlosMozgas(bool irany, sbyte lepesSzam = 1);
    }

    interface ILAlakbanMozog
    {
        void LAlakuMozgas(sbyte irany, bool lAlakVege);
    }
}

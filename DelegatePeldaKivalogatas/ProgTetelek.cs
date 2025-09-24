using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePeldaKivalogatas
{
    delegate bool KeresesiFeltetel(int elem);

    enum LogikaiKombinacio
    {
        Mind,
        Vagy
    }

    static class ProgTetelek
    {
        public static int LinearisKereses(int[] tomb, KeresesiFeltetel feltetel)
        {
            int i = 0;
            while (i < tomb.Length && !feltetel(tomb[i]))
            {
                ++i;
            }
            return i < tomb.Length ? i : -1;
        }

        public static int[] Kivalogatas(int[] tomb, KeresesiFeltetel feltetel)
        {
            List<int> kivalogatott = new List<int>();
            for (int i = 0; i < tomb.Length; ++i)
            {
                if (feltetel(tomb[i]))
                {
                    kivalogatott.Add(tomb[i]);
                }
            }
            return kivalogatott.ToArray();
        }

        public static bool MulticastAnd(KeresesiFeltetel feltetelek, int elem)
        {
            if (feltetelek == null)
            {
                return false;
            }
            foreach (Delegate item in feltetelek.GetInvocationList())
            {
                KeresesiFeltetel d = (KeresesiFeltetel)item;
                if (!d(elem))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool MulticastOr(KeresesiFeltetel feltetelek, int elem)
        {
            if (feltetelek == null)
            {
                return false;
            }
            foreach (Delegate item in feltetelek.GetInvocationList())
            {
                KeresesiFeltetel d = (KeresesiFeltetel)item;
                if (!d(elem))
                {
                    return true;
                }
            }
            return false;
        }

        public static int LinearisKereses(int[] tomb, KeresesiFeltetel multicastFeltetelek, LogikaiKombinacio logika)
        {
            for (int i = 0; i < tomb.Length; ++i)
            {
                bool megfelel = (logika == LogikaiKombinacio.Mind)
                    ? MulticastAnd(multicastFeltetelek, tomb[i])
                    : MulticastOr(multicastFeltetelek, tomb[i]);
                if (megfelel)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int[] Kivalogatas(int[] tomb, KeresesiFeltetel multicastFeltetelek, LogikaiKombinacio logika)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < tomb.Length; ++i)
            {
                bool megfelel = (logika == LogikaiKombinacio.Mind)
                    ? MulticastAnd(multicastFeltetelek, tomb[i])
                    : MulticastOr(multicastFeltetelek, tomb[i]);
                if (megfelel)
                {
                    list.Add(tomb[i]);
                }
            }
            return list.ToArray();
        }
    }
}

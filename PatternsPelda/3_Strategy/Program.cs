using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Strategy
{
    internal class Program
    {
        public interface IDiscountStrategy
        {
            decimal Apply(int price);
        }
        public class NoDiscount : IDiscountStrategy
        {
            public decimal Apply(int price) { return price; }
        }
        public class PercentageDiscount : IDiscountStrategy
        {
            private readonly decimal _percent;
            public PercentageDiscount(decimal percent) { _percent = percent; }
            public decimal Apply(int price) { return price * (1 - _percent); }
        }

        public class CheckOut
        {
            private readonly IDiscountStrategy strategy;
            public CheckOut(IDiscountStrategy strategy) { this.strategy = strategy; }
            public decimal Total(int price) { return strategy.Apply(price); }
        }

        static void Main(string[] args)
        {
            CheckOut c1 = new CheckOut(new NoDiscount());
            Console.WriteLine("nincs kedvezmény: " + c1.Total(10000));

            CheckOut c2 = new CheckOut(new PercentageDiscount(0.1m));
            Console.WriteLine("van kedvezmény:   " + c2.Total(10000));
        }
    }
}


using System;

namespace _2_Factory
{
    internal class Program
    {
        public interface IReport
        {
            void Print();
        }
        public class PdfReport : IReport
        {
            public void Print() { Console.WriteLine("PDF nyomtatása"); }
        }
        public class HtmlReport : IReport
        {
            public void Print() { Console.WriteLine("HTML nyomtatása"); }
        }
        public static class ReportFactory
        {
            public static IReport Create(string type)
            {
                if (type == "PDF") { return new PdfReport(); }
                if (type == "HTML") { return new HtmlReport(); }
                throw new ArgumentException("Nincs ilyen típus!");
            }
        }

        static void Main(string[] args)
        {
            IReport report = ReportFactory.Create("PDF");
            report.Print();

            IReport report2 = new PdfReport();                  //Így ne!
            report2.Print();
            IReport report3 = new HtmlReport();                 //Így ne!
            report3.Print();
        }
    }
}

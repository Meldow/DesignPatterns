namespace InterfaceSegregationPrinciple
{
    //    Don’t put too much into an interface; split into separate interfaces
    //-	YAGNI – You Ain’t Going to Need It

    public class Document
    {

    }

    // This big interface violates the InterfaceSegregationPrinciple

    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            // ...
        }

        public void Print(Document d)
        {
            // ...
        }

        public void Scan(Document d)
        {
            // ...
        }
    }

    public class OldFashionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            // ????
        }

        public void Print(Document d)
        {
            // ...
        }

        public void Scan(Document d)
        {
            // ????
        }
    }

    // Suggestion!!

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            throw new System.NotImplementedException();
        }

        public void Scan(Document d)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IMultiFunctionDevice : IScanner, IPrinter // ... 
    {
    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        //delegate!
        private IPrinter printer;
        private IScanner scanner;

        public void Print(Document d)
        {
            printer.Print(d);
            // decorator pattern
        }

        public void Scan(Document d)
        {
            scanner.Scan(d);
            // decorator pattern
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

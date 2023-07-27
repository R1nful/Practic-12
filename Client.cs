using System.Collections.ObjectModel;

namespace Practic_12
{
    internal class Client
    {
        public string Name { get; private set; }

        public ObservableCollection<Invoice> ClientInvoices ;
        public Client(string name, ObservableCollection<Invoice> clientInvoices)
        {
            Name = name;
            ClientInvoices = clientInvoices;
        }
    }
}

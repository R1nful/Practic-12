using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Practic_12
{
    internal class Client
    {
        public string Name { get; set;}

        public ObservableCollection<Invoice> ClientInvoices;

        public Client(string name, ObservableCollection<Invoice> invoice)
        {
            Name = name;
            ClientInvoices = invoice;
        }
    }
}

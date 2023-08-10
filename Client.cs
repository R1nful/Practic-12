using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Practic_12
{
    public enum ClientStatus
    {
        vip,
        classic,
        legal
    }

    internal class Client
    {
        public string Name { get; private set; }

        public ClientStatus Status { get; set; } = ClientStatus.classic;

        public ObservableCollection<Invoice> ClientInvoices { get; private set; }

        public Client(string name, ObservableCollection<Invoice> clientInvoices, int status)
        {
            Name = name;
            ClientInvoices = clientInvoices;
            Status = (ClientStatus)status;
        }

        public void AddNewInvoice(Invoice invoice)
        {
            if(ClientInvoices.Count<2)
                if(ClientInvoices.Count==1 && ClientInvoices[0].TypeInvoice=="deposit")
                ClientInvoices.Add(invoice);

            else
                MessageBox.Show("Больше счетов сделать нельзя");
        }

        public void RemoveInvoice(Invoice invoice)
        {
            ClientInvoices.Remove(invoice);
        }
    }
}

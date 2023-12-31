﻿using System.Windows;
using System.Windows.Controls;

namespace Practic_12
{
    public partial class MainWindow : Window
    {
        string path = "data.json";

        public MainWindow()
        {
            InitializeComponent();
            ClientRepository.Initial(path);

            ClientCB.ItemsSource = ClientRepository.clients;
        }

        private void ClientCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InvoiceLV.ItemsSource = (ClientCB.SelectedItem as Client)?.ClientInvoices;
        }

        private void BlockInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
                (InvoiceLV.SelectedItem as Invoice)?.ChangeOpen();
        }

        private void TransferBtn_Click(object sender, RoutedEventArgs e)
        {
            TransferMoney transferMoney = new TransferMoney();

            transferMoney.ShowDialog();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientRepository.SaveinDoc(path);
            MessageBox.Show("Данные сохранены");
        }

        private void AddInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if(decimal.TryParse(AddBalanceTB.Text, out decimal result))
            {
                ITransaction<decimal> trans = (InvoiceLV.SelectedItem as Invoice);
                trans.AddBalanse(result);
            }
                //(InvoiceLV.SelectedItem as Invoice)?.AddBalanse(result);
        }

        private void CreateInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateInvoice createInvoice = new CreateInvoice();

            createInvoice.ShowDialog();
        }

        private void CreateClientBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateClient createClient = new CreateClient();
            
            createClient.ShowDialog();
        }

        private void DeliteInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (InvoiceLV.SelectedItem != null)
            {
                ClientRepository.clients[ClientCB.SelectedIndex].RemoveInvoice(InvoiceLV.SelectedItem as Invoice);
                MessageBox.Show("Счет удален");
            }
        }
    }
}

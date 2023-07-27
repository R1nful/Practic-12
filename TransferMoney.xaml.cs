using System.Windows;
using System.Windows.Controls;

namespace Practic_12
{
    /// <summary>
    /// Логика взаимодействия для TransferMoney.xaml
    /// </summary>
    public partial class TransferMoney : Window
    {

        public TransferMoney()
        {
            InitializeComponent();
            BaseInvoice.ItemsSource = ClientRepository.clients;
            TransferInvoice.ItemsSource = ClientRepository.clients;
        }

        private void TransferBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BaseInvoiceLV.SelectedItem != null && TransferInvoiceLV.SelectedItem!= null)
            {
                if (decimal.TryParse(TransferSumTB.Text, out decimal result))
                {
                    Invoice transfer = (Invoice)TransferInvoiceLV.SelectedItem;

                    ((Invoice)BaseInvoiceLV.SelectedItem).TransferMoney(ref transfer, result);
                }
            }
        }

        private void BaseInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BaseInvoiceLV.ItemsSource = (BaseInvoice.SelectedItem as Client).ClientInvoices;
        }

        private void TransferInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TransferInvoiceLV.ItemsSource = (TransferInvoice.SelectedItem as Client).ClientInvoices;
        }
    }
}

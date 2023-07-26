using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            BaseInvoice.ItemsSource = Repository.clients;
            TransferInvoice.ItemsSource = Repository.clients;
        }

        private void TransferBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BaseInvoiceLV.SelectedItems.Count != 0 && TransferInvoiceLV.SelectedItems.Count != 0)
            {
                Invoice transfer = (Invoice)TransferInvoiceLV.SelectedItems[0];

                ((Invoice)BaseInvoiceLV.SelectedItems[0]).TransferMoney(ref transfer, decimal.Parse(TransferSumTB.Text));
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

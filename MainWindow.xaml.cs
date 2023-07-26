using System.Windows;
using System.Windows.Controls;

namespace Practic_12
{
    public partial class MainWindow : Window
    {
        string path = "data.json";

        public MainWindow()
        {
            InitializeComponent();
            Repository.Initial(path);

            ClientCB.ItemsSource = Repository.clients;
        }

        private void ClientCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InvoiceLV.ItemsSource = (ClientCB.SelectedItem as Client).ClientInvoices;
        }

        private void BlockInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (InvoiceLV.SelectedItems.Count != 0)
                (InvoiceLV.SelectedItems[0] as Invoice).ChangeOpen();
        }

        private void TransferBtn_Click(object sender, RoutedEventArgs e)
        {
            TransferMoney tsw = new TransferMoney();

            tsw.ShowDialog();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Repository.SaveinDoc(path);
        }
    }
}

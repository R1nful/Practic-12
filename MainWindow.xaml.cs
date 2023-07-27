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
            ClientRepository.Initial(path);

            ClientCB.ItemsSource = ClientRepository.clients;
        }

        private void ClientCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InvoiceLV.ItemsSource = (ClientCB.SelectedItem as Client).ClientInvoices;
        }

        private void BlockInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (InvoiceLV.SelectedItem != null)
                (InvoiceLV.SelectedItem as Invoice).ChangeOpen();
        }

        private void TransferBtn_Click(object sender, RoutedEventArgs e)
        {
            TransferMoney tsw = new TransferMoney();

            tsw.ShowDialog();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientRepository.SaveinDoc(path);
            MessageBox.Show("Данные сохранены");
        }

        private void AddInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if(InvoiceLV.SelectedItem != null)
            {
                if(decimal.TryParse(AddBalanceTB.Text, out decimal result))
                    (InvoiceLV.SelectedItem as Invoice).AddBalanse(result);
            }
        }

        private void CreateInvoiceBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateInvoice ciw = new CreateInvoice();

            ciw.ShowDialog();
        }
    }
}

using System.Windows;

namespace Practic_12
{
    /// <summary>
    /// Логика взаимодействия для CreateClient.xaml
    /// </summary>
    public partial class CreateClient : Window
    {
        public CreateClient()
        {
            InitializeComponent();
            string[] dt = new string[] {  "Classic", "Vip", "Legal" };
            StatusClientCB.ItemsSource = dt;
        }

        private void CreateClientBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = ClientNameTB.Text;

            if(name.Trim() != "")
            {
                ClientRepository.AddNewClient(new Client(name, new System.Collections.ObjectModel.ObservableCollection<Invoice> { }, StatusClientCB.SelectedIndex));
                MessageBox.Show("Ноывй клиент создан");
                this.Close();
            }
        }
    }
}

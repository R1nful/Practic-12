using System.Collections.ObjectModel;

namespace Practic_12
{
    static internal class ClientRepository
    {
        static public ObservableCollection<Client> clients { get; private set; } = new ObservableCollection<Client>();

        /// <summary>
        /// Заполняте ObservableCollection клиентов клиентами
        /// </summary>
        /// <param name="path"></param>
        static public void Initial(string path)
        {
            clients = DataBase<Client>.LoadDB(path);
        }

        /// <summary>
        /// Метод сохранения данных в документ
        /// </summary>
        /// <param name="path"></param>
        static public void SaveinDoc(string path)
        {
            DataBase<Client>.SaveDB(path, clients);
        }

        /// <summary>
        /// Добавление клиента в лист
        /// </summary>
        /// <param name="client"></param>
        public static void AddNewClient(Client client)
        {
            clients.Add(client);
        }

        /// <summary>
        /// Удаление клиента из листа
        /// </summary>
        /// <param name="client"></param>
        public static void RemoveNewClient(Client client) 
        {
            clients.Remove(client); 
        }
    }
}

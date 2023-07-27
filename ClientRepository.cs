using System.Collections.ObjectModel;

namespace Practic_12
{
    static internal class ClientRepository
    {
        static public ObservableCollection<Client> clients = new ObservableCollection<Client>();

        /// <summary>
        /// Заполняте ObservableCollection клиентов клиентами
        /// </summary>
        /// <param name="path"></param>
        static public void Initial(string path)
        {
            DataBase<Client>.LoadDB(path, out clients);
        }

        /// <summary>
        /// Метод сохранения данных в документ
        /// </summary>
        /// <param name="path"></param>
        static public void SaveinDoc(string path)
        {
            DataBase<Client>.SaveDB(path, clients);
        }
    }
}

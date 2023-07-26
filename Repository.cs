using System.Collections.ObjectModel;

namespace Practic_12
{
    static internal class Repository
    {
        // лист клиентов
        static public ObservableCollection<Client> clients = new ObservableCollection<Client>();


        /// <summary>
        /// Заполняте ObservableCollection клиентов клиентами
        /// </summary>
        /// <param name="path"></param>
        static public void Initial(string path)
        {
            FileBase.ReadFromFile(path, ref clients);
        }

        /// <summary>
        /// Метод сохранения данных в документ
        /// </summary>
        /// <param name="path"></param>
        static public void SaveinDoc(string path)
        {
            FileBase.SaveinFile(path, clients);
        }
    }
}

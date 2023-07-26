using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace Practic_12
{
    static internal class FileBase
    {
        /// <summary>
        /// Записывает данные из ObservableCollection в файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clients"></param>
        static public void SaveinFile(string path, ObservableCollection<Client> clients)
        {
            string json = JsonConvert.SerializeObject(clients);

            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Чтание из файла и возвращает значание в ObservableCollection
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clients"></param>
        static public void ReadFromFile(string path, ref ObservableCollection<Client> clients)
        {
            string json = File.ReadAllText(path);

            clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(json);
        }
    }
}

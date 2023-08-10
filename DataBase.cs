using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace Practic_12
{
    static internal class DataBase<T>
    {
        /// <summary>
        /// Записывает данные из ObservableCollection в файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clients"></param>
        static public void SaveDB(string path, ObservableCollection<T> clients)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings 
            {
                TypeNameHandling = TypeNameHandling.All
            };

            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string text = JsonConvert.SerializeObject(clients, Formatting.Indented);
                streamWriter.WriteLine(text);
            }
        }

        /// <summary>
        /// Чтание из файла и возвращает значание в ObservableCollection
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clients"></param>
        static public ObservableCollection<T> LoadDB(string path)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            ObservableCollection<T> clients;

            using (StreamReader streamReader = new StreamReader(path))
            {
                string text = streamReader.ReadToEnd();
                clients = JsonConvert.DeserializeObject<ObservableCollection<T>>(text);
            }

            return clients;
        }
    }
}

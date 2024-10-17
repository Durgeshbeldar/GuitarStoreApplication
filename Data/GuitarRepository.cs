using GuitarStoreApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuitarStoreApplication.Data
{
    internal class GuitarRepository
    {
        private const string FilePath = @"S:\Office Work\Monocept Training\Assignments\GuitarStoreApplication\GuitarStoreApplication\Files\Inventory.json";

        // Load guitars from the JSON file using Newtonsoft.Json
        public List<Guitar> LoadGuitars()
        {
            if (!File.Exists(FilePath))
                return new List<Guitar>();

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Guitar>>(json);
        }

        // Save guitars to the JSON file using Newtonsoft.Json
        public void SaveGuitars(List<Guitar> guitars)
        {
            string json = JsonConvert.SerializeObject(guitars, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}

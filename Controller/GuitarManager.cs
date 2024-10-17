using GuitarStoreApplication.Data;
using GuitarStoreApplication.Models;
using GuitarStoreApplication.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStoreApplication.Controller
{
    internal class GuitarManager
    {
        private readonly Inventory inventory;
        private readonly GuitarRepository guitarRepository;

        public GuitarManager()
        {
            guitarRepository = new GuitarRepository();
            inventory = new Inventory();
            var guitars = guitarRepository.LoadGuitars();
            if (guitars != null)
            {
                foreach (var guitar in guitars)
                {
                    inventory.AddGuitar(guitar.SerialNumber, guitar.Price, guitar.Spec.Builder, guitar.Spec.Model, guitar.Spec.Type, guitar.Spec.BackWood, guitar.Spec.TopWood);
                }
            }

        }

        // 1. Add Guitar - Auto-generated Serial Number
        public void AddGuitar(double price, Builder builder, string model, GuitarType type, Wood backWood, Wood topWood)
        {
            string serialNumber = GenerateSerialNumber();
            inventory.AddGuitar(serialNumber, price, builder, model, type, backWood, topWood);
            guitarRepository.SaveGuitars(inventory.GetAllGuitars());
        }

        // 2. Search Guitar by Builder, Wood, Type
        public List<Guitar> SearchGuitars(Builder builder, Wood backWood, GuitarType type)
        {
            GuitarSpec searchSpec = new GuitarSpec(builder, "", type, backWood, backWood);  // Empty model, only filtering by builder, wood, and type
            return inventory.Search(searchSpec);
        }

        // 3. Get Guitar Information by Serial Number
        public Guitar GetGuitarBySerialNumber(string serialNumber)
        {
            return inventory.GetGuitar(serialNumber);
        }

        // 4. Show All Guitars
        public List<Guitar> GetAllGuitars()
        {
            return inventory.GetAllGuitars();
        }

        // 5. Delete Guitar by Serial Number
        public bool DeleteGuitar(string serialNumber)
        {
            bool removed = inventory.RemoveGuitar(serialNumber);
            if (removed)
            {
                guitarRepository.SaveGuitars(inventory.GetAllGuitars());
            }
            return removed;
        }

        // Auto-generate Serial Number
        private string GenerateSerialNumber()
        {
            return $"SN-{System.Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }
}

using GuitarStoreApplication.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStoreApplication.Models
{
    internal class Inventory
    {
        private List<Guitar> guitars;

        public Inventory()
        {
            guitars = new List<Guitar>();
        }

        // Add Guitar
        public void AddGuitar(string serialNumber, double price, Builder builder, string model, GuitarType type, Wood backWood, Wood topWood)
        {
            GuitarSpec spec = new GuitarSpec(builder, model, type, backWood, topWood);
            Guitar guitar = new Guitar(serialNumber, price, spec);
            guitars.Add(guitar);
        }

        // Get Guitar by Serial Number
        public Guitar GetGuitar(string serialNumber)
        {
            return guitars.Find(guitar => guitar.SerialNumber == serialNumber);
        }

        // Remove Guitar by Serial Number
        public bool RemoveGuitar(string serialNumber)
        {
            var guitar = GetGuitar(serialNumber);
            if (guitar != null)
            {
                guitars.Remove(guitar);
                return true;
            }
            return false;
        }

        // Get All Guitars
        public List<Guitar> GetAllGuitars()
        {
            return guitars;
        }

        // Search Guitars by Spec
        public List<Guitar> Search(GuitarSpec searchSpec)
        {
            List<Guitar> matchingGuitars = new List<Guitar>();
            foreach (var guitar in guitars)
            {
                if (guitar.Spec.Builder == searchSpec.Builder &&
                    guitar.Spec.Type == searchSpec.Type &&
                    guitar.Spec.BackWood == searchSpec.BackWood)
                {
                    matchingGuitars.Add(guitar);
                }
            }
            return matchingGuitars;
        }

        // Override ToString to display Guitar details
        public override string ToString()
        {
            string result = "";
            foreach (var guitar in guitars)
            {
                result += $"Serial: {guitar.SerialNumber}, Builder: {guitar.Spec.Builder}, Model: {guitar.Spec.Model}, Type: {guitar.Spec.Type}, Price: {guitar.Price}\n";
            }
            return result;
        }
    }
}

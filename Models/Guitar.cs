using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarStoreApplication.Models
{
    internal class Guitar
    {
        public string SerialNumber { get; }
        public double Price { get; set; }
        public GuitarSpec Spec { get; }

        public Guitar(string serialNumber, double price, GuitarSpec spec)
        {
            SerialNumber = serialNumber;
            Price = price;
            Spec = spec;
        }
        public override string ToString()
        {
            return $"\nSerial Number : {SerialNumber}\n" +
                $"Model : {Spec.Model}\n" +
                $"Guitar Type : {Spec.Type}\n" +
                $"Builder : {Spec.Builder}\n" +
                $"Price : {Price}\n" +
                $"Backwood : {Spec.BackWood} and Top Wood : {Spec.TopWood}\n\n";
        }
    }
}

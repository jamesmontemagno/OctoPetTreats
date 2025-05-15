using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WpfPetTreats.Models;

namespace WpfPetTreats.Services
{
    public class PetTreatManager
    {
        /// <summary>
        /// Serializes the PetTreat object to a JSON string and returns it as base64 encoded string
        /// </summary>
        /// <param name="petTreat">The pet treat to serialize</param>
        /// <returns>Base64 encoded JSON string</returns>
        public string Serialize(PetTreat petTreat)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(petTreat, options);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString));
        }

        /// <summary>
        /// Deserializes a base64 encoded JSON string back to a PetTreat object
        /// </summary>
        /// <param name="petTreatString">Base64 encoded JSON string</param>
        /// <returns>The deserialized PetTreat object</returns>
        public PetTreat Deserialize(string petTreatString)
        {
            var bytes = Convert.FromBase64String(petTreatString);
            string jsonString = Encoding.UTF8.GetString(bytes);
            return JsonSerializer.Deserialize<PetTreat>(jsonString);
        }
    }
}
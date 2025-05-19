using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using WpfPetTreats.Models;

namespace WpfPetTreats.Services
{
    public class PetTreatManager
    {
        /// <summary>
        /// Uses binaryFormatter to serialize the object, and return a string that is base64 encoded
        /// </summary>
        /// <param name="anyMovie"></param>
        /// <returns></returns>
        public string Serialize(PetTreat anyMovie)
        {
            // TODO: Replaced BinaryFormatter with System.Text.Json for serialization. This fix assumes the object is compatible with JSON serialization.
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            using (var stream = new System.IO.MemoryStream())
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                var jsonString = System.Text.Json.JsonSerializer.Serialize(anyMovie, options);
                var bytes = System.Text.Encoding.UTF8.GetBytes(jsonString);
                stream.Write(bytes, 0, bytes.Length);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                return Convert.ToBase64String(stream.ToArray());
            }

        }

        /// <summary>
        /// Reverses the serialize operation to recreate a movie object
        /// </summary>
        /// <param name="movieString"></param>
        /// <returns></returns>
        public PetTreat Deserialize(string movieString)
        {
            // TODO: Replaced BinaryFormatter with System.Text.Json for deserialization. This fix assumes the object is compatible with JSON deserialization, but may not work with the current format.
            var options = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var bytes = Convert.FromBase64String(movieString);
            using (var stream = new System.IO.MemoryStream(bytes))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                var jsonString = System.Text.Encoding.UTF8.GetString(stream.ToArray());
                return System.Text.Json.JsonSerializer.Deserialize<PetTreat>(jsonString, options);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
    }
}
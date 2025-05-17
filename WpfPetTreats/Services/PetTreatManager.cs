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
            // TODO: Replaced BinaryFormatter with System.Text.Json for serialization. This fix is a proposal and may not work with the current format during deserialization.
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            using (var stream = new System.IO.MemoryStream())
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                var jsonString = System.Text.Json.JsonSerializer.Serialize(anyMovie, options);
                var writer = new System.IO.StreamWriter(stream);
                writer.Write(jsonString);
                writer.Flush();
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
            // TODO: Replaced BinaryFormatter with System.Text.Json for deserialization. This fix is a proposal and may not work with the current format during deserialization.
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            var bytes = Convert.FromBase64String(movieString);
            using (var stream = new System.IO.MemoryStream(bytes))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                var reader = new System.IO.StreamReader(stream);
                var jsonString = reader.ReadToEnd();
                return System.Text.Json.JsonSerializer.Deserialize<PetTreat>(jsonString, options);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
    }
}
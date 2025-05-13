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
            var formatter = new BinaryFormatter();
            using (var stream = new System.IO.MemoryStream())
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(stream, anyMovie);
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
            var formatter = new BinaryFormatter();
            var bytes = Convert.FromBase64String(movieString);
            using (var stream = new System.IO.MemoryStream(bytes))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                return (PetTreat)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
    }
}
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
        /// <param name="anyPetTreat"></param>
        /// <returns></returns>
        public string Serialize(PetTreat anyPetTreat)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new System.IO.MemoryStream())
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                formatter.Serialize(stream, anyPetTreat);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                return Convert.ToBase64String(stream.ToArray());
            }

        }

        /// <summary>
        /// Reverses the serialize operation to recreate a pet treat object
        /// </summary>
        /// <param name="petTreatString"></param>
        /// <returns></returns>
        public PetTreat Deserialize(string petTreatString)
        {
            var formatter = new BinaryFormatter();
            var bytes = Convert.FromBase64String(petTreatString);
            using (var stream = new System.IO.MemoryStream(bytes))
            {
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                return (PetTreat)formatter.Deserialize(stream);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPetTreats.Models;
using WpfPetTreats.Services;

namespace WpfPetTreats.Tests
{
    internal class PetTreatManagerTests
    {
        private PetTreatManager stateManager;

        [SetUp]
        public void SetUp()
        {
            stateManager = new PetTreatManager();
        }

        [Test]
        public void Serialize_ShouldCreateString()
        {
            // Arrange
            string title = "Test Title";
            string description = "Test Description";
            var aPetTreat = new PetTreat
            {
                Title = title,
                Description = description
            };

            // Act
            var petTreatString = stateManager.Serialize(aPetTreat);

            // Assert
            Assert.NotNull(petTreatString);
            Assert.IsNotEmpty(petTreatString);
        }

        [Test]
        public void Deserialize_ShouldCreateMovie()
        {
            // Arrange
            var petTreatString = "AAEAAAD/////AQAAAAAAAAAMAgAAAD9XcGZNb3ZpZSwgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGwFAQAAABVXcGZNb3ZpZS5Nb2RlbHMuTW92aWUCAAAABXRpdGxlC2Rlc2NyaXB0aW9uAQECAAAABgMAAAAKVGVzdCBUaXRsZQYEAAAAEFRlc3QgRGVzY3JpcHRpb24L";
            
            // Act
            var netPetTreat = stateManager.Deserialize(petTreatString);
            
            // Assert
            Assert.IsNotNull(netPetTreat);
            Assert.AreEqual("Test Title", netPetTreat.Title);
            Assert.AreEqual("Test Description", netPetTreat.Description);
        }

        [Test]
        public void Serialize_IsIdempotent()
        {
            // Arrange
            string title = "Test Title";
            string description = "Test Description";
            var aPetTreat = new PetTreat
            {
                Title = title,
                Description = description
            };

            // Act
            var petTreatString = stateManager.Serialize(aPetTreat);
            var newPetTreat = stateManager.Deserialize(petTreatString);

            // Assert
            Assert.IsNotNull(newPetTreat);
            Assert.AreEqual(aPetTreat.Title, newPetTreat.Title);
            Assert.AreEqual(aPetTreat.Description, newPetTreat.Description);
        }
    }
}

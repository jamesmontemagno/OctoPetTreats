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
            Assert.That(petTreatString, Is.Not.Null);
            Assert.That(petTreatString, Is.Not.Empty);
        }

        [Test]
        public void Deserialize_ShouldCreateMovie()
        {
            // Arrange
            // Create a valid JSON-based Base64 string for a PetTreat
            string jsonString = "{\n  \"Title\": \"Test Title\",\n  \"Description\": \"Test Description\"\n}";
            string petTreatString = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString));
            
            // Act
            var netPetTreat = stateManager.Deserialize(petTreatString);
            
            // Assert
            Assert.That(netPetTreat, Is.Not.Null);
            Assert.That(netPetTreat.Title, Is.EqualTo("Test Title"));
            Assert.That(netPetTreat.Description, Is.EqualTo("Test Description"));
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
            Assert.That(newPetTreat, Is.Not.Null);
            Assert.That(newPetTreat.Title, Is.EqualTo(aPetTreat.Title));
            Assert.That(newPetTreat.Description, Is.EqualTo(aPetTreat.Description));
        }
    }
}

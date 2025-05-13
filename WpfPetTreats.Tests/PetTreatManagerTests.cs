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
            var aMovie = new PetTreat
            {
                Title = title,
                Description = description
            };

            // Act
            var movieString = stateManager.Serialize(aMovie);

            // Assert
            Assert.NotNull(movieString);
            Assert.IsNotEmpty(movieString);
        }

        [Test]
        public void Deserialize_ShouldCreateMovie()
        {
            // Arrange
            var movieString = "AAEAAAD/////AQAAAAAAAAAMAgAAAD9XcGZNb3ZpZSwgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGwFAQAAABVXcGZNb3ZpZS5Nb2RlbHMuTW92aWUCAAAABXRpdGxlC2Rlc2NyaXB0aW9uAQECAAAABgMAAAAKVGVzdCBUaXRsZQYEAAAAEFRlc3QgRGVzY3JpcHRpb24L";
            
            // Act
            var newMovie = stateManager.Deserialize(movieString);
            
            // Assert
            Assert.IsNotNull(newMovie);
            Assert.AreEqual("Test Title", newMovie.Title);
            Assert.AreEqual("Test Description", newMovie.Description);
        }

        [Test]
        public void Serialize_IsIdempotent()
        {
            // Arrange
            string title = "Test Title";
            string description = "Test Description";
            var aMovie = new PetTreat
            {
                Title = title,
                Description = description
            };

            // Act
            var movieString = stateManager.Serialize(aMovie);
            var newMovie = stateManager.Deserialize(movieString);

            // Assert
            Assert.IsNotNull(newMovie);
            Assert.AreEqual(aMovie.Title, newMovie.Title);
            Assert.AreEqual(aMovie.Description, newMovie.Description);
        }
    }
}

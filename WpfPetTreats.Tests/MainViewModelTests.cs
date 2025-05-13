using WpfPetTreats.Models;
using WpfPetTreats.ViewModels;

namespace WpfPetTreats.Tests
{
    public class MainViewModelTests
    {
        private MainViewModel viewModel;

        [SetUp]
        public void SetUp()
        {
            viewModel = new MainViewModel();
        }

        [Test]
        public void AddTodoItem_ShouldAddItemToList()
        {
            // Arrange
            string title = "Test Title";
            string description = "Test Description";

            // Act
            viewModel.AddTodoItem(title, description);

            // Assert
            Assert.AreEqual(1, viewModel.PetTreats.Count);
            Assert.AreEqual(title, viewModel.PetTreats[0].Title);
            Assert.AreEqual(description, viewModel.PetTreats[0].Description);
        }

        [Test]
        public void EditTodoItem_ShouldUpdateItemInList()
        {
            // Arrange
            var item = new PetTreat { Title = "Old Title", Description = "Old Description" };
            viewModel.PetTreats.Add(item);
            string newTitle = "New Title";
            string newDescription = "New Description";

            // Act
            viewModel.EditTodoItem(item, newTitle, newDescription);

            // Assert
            Assert.AreEqual(newTitle, item.Title);
            Assert.AreEqual(newDescription, item.Description);
        }

        [Test]
        public void DeleteTodoItem_ShouldRemoveItemFromList()
        {
            // Arrange
            var item = new PetTreat { Title = "Test Title", Description = "Test Description" };
            viewModel.PetTreats.Add(item);

            // Act
            viewModel.DeleteTodoItem(item);

            // Assert
            Assert.AreEqual(0, viewModel.PetTreats.Count);
        }
    }
}
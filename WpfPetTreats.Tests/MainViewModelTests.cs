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
            Assert.That(viewModel.PetTreats.Count, Is.EqualTo(1));
            Assert.That(viewModel.PetTreats[0].Title, Is.EqualTo(title));
            Assert.That(viewModel.PetTreats[0].Description, Is.EqualTo(description));
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
            Assert.That(item.Title, Is.EqualTo(newTitle));
            Assert.That(item.Description, Is.EqualTo(newDescription));
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
            Assert.That(viewModel.PetTreats.Count, Is.EqualTo(0));
        }
    }
}
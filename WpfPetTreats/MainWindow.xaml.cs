using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPetTreats.Models;
using WpfPetTreats.ViewModels;

namespace WpfPetTreats;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private MainViewModel viewModel;

    public MainWindow()
    {
        InitializeComponent();
        viewModel = new MainViewModel();
        DataContext = viewModel;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        viewModel.AddTodoItem(TitleTextBox.Text, DescriptionTextBox.Text);
        TitleTextBox.Clear();
        DescriptionTextBox.Clear();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (PetTreatListBox.SelectedItem is PetTreat selectedItem)
        {
            viewModel.EditTodoItem(selectedItem, TitleTextBox.Text, DescriptionTextBox.Text);
            TitleTextBox.Clear();
            DescriptionTextBox.Clear();
        }
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (PetTreatListBox.SelectedItem is PetTreat selectedItem)
        {
            viewModel.DeleteTodoItem(selectedItem);
        }
    }
}
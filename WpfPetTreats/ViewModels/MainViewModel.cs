using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPetTreats.Models;

namespace WpfPetTreats.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<PetTreat> PetTreats { get; set; }

        public MainViewModel()
        {
            PetTreats = new ObservableCollection<PetTreat>();
        }

        public void AddTodoItem(string title, string description)
        {
            var newItem = new PetTreat { Title = title, Description = description };
            PetTreats.Add(newItem);
        }

        public void EditTodoItem(PetTreat item, string newTitle, string newDescription)
        {
            if (item != null)
            {
                item.Title = newTitle;
                item.Description = newDescription;
            }
        }

        public void DeleteTodoItem(PetTreat item)
        {
            if (item != null)
            {
                PetTreats.Remove(item);
            }
        }
    }
}
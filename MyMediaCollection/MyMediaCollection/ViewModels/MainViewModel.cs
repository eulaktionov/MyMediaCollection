using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using MyMediaCollection.Enums;
using MyMediaCollection.Model;

namespace MyMediaCollection.ViewModels
{
    public class MainViewModel : BindableBase
    {
        IList<string> _mediums;
        string _selectedMedium;
        
        ObservableCollection<MediaItem> _items;
        ObservableCollection<MediaItem> _allItems;
        MediaItem _selectedItem;

        public ICommand DeleteCommand { get; set; }
        public ICommand AddEditCommand { get; set; }

        int _additionaItemCount = 1;

        public MainViewModel()
        {
            PopulateData();
            DeleteCommand = new RelayCommand(DeleteItem, CanDeleteItem);
            AddEditCommand = new RelayCommand(AddOrEditItem);
        }

        public IList<string> Mediums
        {
            get => _mediums;
            set => SetProperty(ref _mediums, value);
        }

        public string SelectedMedium
        {
            get => _selectedMedium;
            set
            {
                SetProperty(ref _selectedMedium, value);

                //Items.Clear();
                //foreach(var item in _allItems)
                //{
                //    if(string.IsNullOrWhiteSpace(_selectedMedium) ||
                //        _selectedMedium == "All" ||
                //        _selectedMedium == item.MediaType.ToString())
                //    {
                //        Items.Add(item);
                //    }
                //}
                var selected = _allItems.Where(x => 
                    _selectedMedium is null ||
                    string.IsNullOrWhiteSpace(_selectedMedium) ||
                    _selectedMedium == "All" ||
                    _selectedMedium.ToString() == x.MediaType.ToString()
                    );
                Items = new ObservableCollection<MediaItem>(selected);
            }
        }

        public ObservableCollection<MediaItem> Items
        { 
            get => _items; 
            set => SetProperty(ref _items, value);  
        }

        public MediaItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                ((RelayCommand)DeleteCommand).RaiseCanExecuteChanged();
            }
        }

        public void PopulateData()
        {
            _mediums = new List<string>
            {
                "All",
                nameof(ItemType.Book),
                nameof(ItemType.Music),
                nameof(ItemType.Video)
            };
            _selectedMedium = Mediums[0];

            var cd = new MediaItem()
            {
                Id = 1,
                Name = "Classical Pavorites",
                MediaType = ItemType.Music,
                MediumInfo = new Medium
                {
                    Id = 1,
                    MediaType = ItemType.Music,
                    Name = "CD"
                }
            };

            var book = new MediaItem()
            {
                Id = 2,
                Name = "Classic Fairy Tales",
                MediaType = ItemType.Book,
                MediumInfo = new Medium
                {
                    Id = 2,
                    MediaType = ItemType.Book,
                    Name = "Book"
                }
            };

            var bluRay = new MediaItem()
            {
                Id = 3,
                Name = "The Mummy",
                MediaType = ItemType.Video,
                MediumInfo = new Medium
                {
                    Id = 3,
                    MediaType = ItemType.Video,
                    Name = "Blu Ray"
                }
            };

            _allItems = new ObservableCollection<MediaItem>()
            {
                cd,
                book,
                bluRay
            };

            _items = new ObservableCollection<MediaItem>(_allItems);
        }

        void DeleteItem()
        {
            _allItems.Remove(SelectedItem);
            Items.Remove(SelectedItem);
        }
        bool CanDeleteItem() => _selectedItem != null;

        void AddOrEditItem()
        {
            const int startingItemCount = 3;
            var newItem = new MediaItem
            {
                Id = startingItemCount + _additionaItemCount,
                Location = LocationType.InCollection,
                MediaType = ItemType.Music,
                MediumInfo = new()
                {
                    Id = 1,
                    MediaType = ItemType.Music,
                    Name = "CD"
                },
                Name = $"CD {_additionaItemCount}"
            };
            _allItems.Add(newItem);
            Items.Add(newItem);
            _additionaItemCount++;
        }
    }
}

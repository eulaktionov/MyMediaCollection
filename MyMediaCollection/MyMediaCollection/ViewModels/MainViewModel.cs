using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyMediaCollection.Enums;
using MyMediaCollection.Model;

namespace MyMediaCollection.ViewModels
{
    public class MainViewModel : BindableBase
    {
        IList<string> _mediums;
        string _selectedMedium;
        ObservableCollection<MediaItem> _items;

        public MainViewModel()
        {
            PopulateData();
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

            _items = new ObservableCollection<MediaItem>()
            {
                cd,
                book,
                bluRay
            };
        }


    }
}

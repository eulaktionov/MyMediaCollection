using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

using Windows.Foundation;
using Windows.Foundation.Collections;

using MyMediaCollection.Enums;
using MyMediaCollection.Model;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MyMediaCollection
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        IList<MediaItem> _items { get; set; }
        IList<string> _mediums { get; set; }
        bool _isLoaded;

        public MainWindow()
        {
            this.InitializeComponent();
            ItemList.Loaded += ItemList_Loaded;
            ItemFilter.Loaded += ItemFilter_Loaded;
            ItemFilter.SelectionChanged += ItemFilter_SelectionChanged;
        }

        private void ItemFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ItemList.ItemsSource = _items.Where(x => ItemFilter.SelectedItem is null
                || string.IsNullOrWhiteSpace(ItemFilter.SelectedItem.ToString())
                || ItemFilter.SelectedItem.ToString() == "All"
                || ItemFilter.SelectedItem.ToString() == x.MediaType.ToString());
        }

        private void ItemFilter_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateData();
            var filterCombo = (ComboBox)sender;
            filterCombo.ItemsSource = _mediums;
            filterCombo.SelectedIndex = 0;
        }

        private void ItemList_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateData();
            var listView = (ListViewBase)sender;
            listView.ItemsSource = _items;
        }

        public void PopulateData()
        {
            if (_isLoaded) return;

            _mediums = new List<string>
            {
                "All",
                nameof(ItemType.Book),
                nameof(ItemType.Music),
                nameof(ItemType.Video)
            };

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

            _items = new List<MediaItem>() 
            { 
                cd, 
                book, 
                bluRay 
            };

            _isLoaded = true;
        }
    }
}

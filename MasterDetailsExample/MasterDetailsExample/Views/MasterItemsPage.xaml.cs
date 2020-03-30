using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using MasterDetailsExample.Core.Models;
using MasterDetailsExample.Core.Services;

using Microsoft.Toolkit.Uwp.UI.Controls;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace MasterDetailsExample.Views
{
    public sealed partial class MasterItemsPage : Page, INotifyPropertyChanged
    {
        public static readonly DependencyProperty InEditModeProperty = DependencyProperty.Register("InEditMode", typeof(bool), typeof(MasterItemsPage), null);

        public bool InEditMode
        {
            get { return (bool)GetValue(InEditModeProperty); }
            set { SetValue(InEditModeProperty, value); }
        }

        //private  bool _inEditMode;
        //public  bool InEditMode
        //{
        //    get { return _inEditMode; }
        //    set
        //    {
        //        _inEditMode = value;
        //        OnPropertyChanged("InEditMode");
        //    }
        //}


        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set(ref _selected, value); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

        public MasterItemsPage()
        {
            InitializeComponent();
            Loaded += MasterItemsPage_Loaded;
        }

        private async void MasterItemsPage_Loaded(object sender, RoutedEventArgs e)
        {
            SampleItems.Clear();

            var data = await SampleDataService.GetMasterDetailDataAsync();

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }

            if (MasterDetailsViewControl.ViewState == MasterDetailsViewState.Both)
            {
                Selected = SampleItems.FirstOrDefault();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            InEditMode = !InEditMode;
        }

        private void MasterCommandBar_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}

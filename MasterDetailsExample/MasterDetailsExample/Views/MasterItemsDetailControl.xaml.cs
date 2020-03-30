using System;

using MasterDetailsExample.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MasterDetailsExample.Views
{
    public sealed partial class MasterItemsDetailControl : UserControl
    {
        public SampleOrder MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as SampleOrder; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(MasterItemsDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public MasterItemsDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as MasterItemsDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}

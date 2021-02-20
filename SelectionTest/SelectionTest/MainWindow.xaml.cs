using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SelectionTest
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
    }


    public class Viewmodel
    {
        public ObservableCollection<SubViewmodel> Items { get; } = new ObservableCollection<SubViewmodel>();

        public ICollectionView ViewSource { get; }

        public Viewmodel()
        {
            this.ViewSource = new CollectionViewSource() { Source = Items }.View;


            var counter = 0;
            this.Items.Add(new SubViewmodel() { Text = $"Item{++counter}" });
            this.Items.Add(new SubViewmodel() { Text = $"Item{++counter}" });
            this.Items.Add(new SubViewmodel() { Text = $"Item{++counter}" });
            this.Items.Add(new SubViewmodel() { Text = $"Item{++counter}" });
        }

    }

    public class SubViewmodel : DependencyObject
    {


        public string Text
        {
            get { return (string)this.GetValue(TextProperty); }
            set { this.SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SubViewmodel), new PropertyMetadata(string.Empty));



        public bool IsActive
        {
            get { return (bool)this.GetValue(IsActiveProperty); }
            set { this.SetValue(IsActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(SubViewmodel), new PropertyMetadata(true, Changed));

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine(d);
        }

        public override string ToString()
        {
            return $"{this.Text}  {this.IsActive}";
        }
    }
}

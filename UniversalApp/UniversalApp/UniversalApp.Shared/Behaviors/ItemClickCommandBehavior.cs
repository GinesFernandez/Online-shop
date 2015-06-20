using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UniversalApp.Behaviors
{
    /// <summary>
    /// https://javiersuarezruiz.wordpress.com/2015/03/16/tips-and-tricks-universal-apps-evento-itemclick-a-comando/
    /// Permite convertir el evento ItemClick de GridView y ListView en un Command
    /// Para usar añadir en xaml xmlns:behaviors="using:UniversalApp.Behaviors".
    /// Añadir al GridView o ListView: IsItemClickEnabled="True" behaviors:ItemClickCommandBehavior.ItemClickCommand="{Binding ClickCommand}"
    /// </summary>
    public static class ItemClickCommandBehavior
    {
        public static readonly DependencyProperty ItemClickCommandCommandProperty =
            DependencyProperty.RegisterAttached("ItemClickCommand", typeof(ICommand),
            typeof(ItemClickCommandBehavior), new PropertyMetadata(null, OnItemClickCommandPropertyChanged));

        public static void SetItemClickCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(ItemClickCommandCommandProperty, value);
        }

        public static ICommand GetItemClickCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(ItemClickCommandCommandProperty);
        }

        private static void OnItemClickCommandPropertyChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var control = d as ListViewBase;
            if (control != null)
                control.ItemClick += OnItemClick;
        }

        private static void OnItemClick(object sender, ItemClickEventArgs e)
        {
            var control = sender as ListViewBase;
            var itemClickCommand = GetItemClickCommand(control);

            if (itemClickCommand != null && itemClickCommand.CanExecute(e.ClickedItem))
                itemClickCommand.Execute(e.ClickedItem);
        }
    }
}

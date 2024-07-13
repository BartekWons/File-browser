using System.Collections.ObjectModel;

namespace File_browser.Model.Utils
{
    public static class ObservableCollectionExtensions
    {
        public static void ExtendCollection<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));

            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
            {
                if (!collection.Contains(item)) 
                {
                    collection.Add(item);
                }
            }
        }
    }
}

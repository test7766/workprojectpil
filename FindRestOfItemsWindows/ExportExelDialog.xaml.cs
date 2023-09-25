using DevExpress.Xpf.Bars;
using System.Windows;

namespace FindRestOfItemsWindows
{
    public partial class ExportExelDialog : Window
    {
        public bool CurrentClick { get; private set; }
        public ExportExelDialog() => InitializeComponent();      
        private void CanselPages_ItemClick(object sender, ItemClickEventArgs e) => DialogResult = false;
        
        private void CurrentlePage_ItemClick(object sender, ItemClickEventArgs e)
        {
            CurrentClick = (sender != Allpages) ? true : false;
            DialogResult = true;
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;

namespace Uniation.Models
{
    public partial class RadioButtons: ObservableObject
    {
        [ObservableProperty]
        private string content;
        [ObservableProperty]
        public string comParameter;
        [ObservableProperty]
        public bool isChecked;
    }
}

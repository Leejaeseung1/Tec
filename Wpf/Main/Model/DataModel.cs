using CommunityToolkit.Mvvm.ComponentModel;

namespace Main.Model
{
    /// <summary>
    /// model send change to viewmodel
    /// </summary>
    internal partial class DataModel : ObservableObject //ObservableObject is check variable monitor
    {
        private int _id1;
        public int Id1
        {
            get { return _id1; }
            set { SetProperty(ref _id1, value); }
        }

        private int _id2;
        public int Id2
        {
            get => _id2;
            set => SetProperty(ref _id2, value);
        }

        [ObservableProperty] //is one line, same up code
        private int _id3;
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using Main.Model;

namespace Main.ViewModel
{
    internal partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private IList<DataModel> _data;

        [ObservableProperty]
        private DataModel? _selectedId; //no new(), assign initial -> view text 0, 0

        internal MainWindowViewModel()
        {
            Data = new List<DataModel>
            {
                new DataModel{Id1 = 1, Id2 = 4356, Id3 = 6},
                new DataModel{Id1 = 2, Id2 = 5342, Id3 = 5},
                new DataModel{Id1 = 3, Id2 = 6547, Id3 = 4},
                new DataModel{Id1 = 4, Id2 = 5674, Id3 = 3},
                new DataModel{Id1 = 5, Id2 = 3465, Id3 = 2},
                new DataModel{Id1 = 6, Id2 = 4556, Id3 = 1},
            };
        }
    }
}

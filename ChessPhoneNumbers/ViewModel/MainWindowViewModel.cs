using ChessPhoneNumbers.ComponentModel;
using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Paths;
using ChessPhoneNumbers.PhoneNumbers;
using ChessPhoneNumbers.Trees;
using ChessPhoneNumbers.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers
{
    class MainWindowViewModel : NotifyPropertyChangedEntity
    {
        private int? _numberOfPhoneNumbers;
        private PathFinderResult _result;
        private IEnumerable<TreeNodeViewModel> _trees;

        public MainWindowViewModel()
        {
            AllPieces = Pieces.GetValues();
        }

        public void Find()
        {
            _result = new PhoneNumberService().FindAllPhoneNumbers(SelectedPiece.Piece);
            NumberOfPhoneNumbers = _result.AllPaths.Count;
            Trees = (from t in _result.PathTrees select new TreeNodeViewModel(t.Root));
        }

        public int? NumberOfPhoneNumbers
        {
            get { return _numberOfPhoneNumbers; }

            set
            {
                _numberOfPhoneNumbers = value;
                OnPropertyChanged(nameof(NumberOfPhoneNumbers));
            }
        }

        public IEnumerable<TreeNodeViewModel> Trees
        {
            get { return _trees; }

            set
            {
                _trees = value;
                OnPropertyChanged(nameof(Trees));
            }
        }

        public IEnumerable<Pieces> AllPieces { get; private set; }

        public Pieces SelectedPiece { get; set; }
    }
}

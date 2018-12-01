using ChessPhoneNumbers.ComponentModel;
using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.PhoneNumbers;
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

        public MainWindowViewModel()
        {
            AllPieces = Pieces.GetValues();
        }

        public void Find()
        {
            NumberOfPhoneNumbers = new PhoneNumberService().FindAllPhoneNumbers(SelectedPiece.Piece);
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

        public IEnumerable<Pieces> AllPieces { get; private set; }

        public Pieces SelectedPiece { get; set; }
    }
}

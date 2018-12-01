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
        public MainWindowViewModel()
        {
            AllPieces = Pieces.GetValues();
        }

        public void Find()
        {
            new PhoneNumberService().FindAllPhoneNumbers(new Bishop());
        }

        public int NumberOfPhoneNumbers { get; }

        public IEnumerable<Pieces> AllPieces { get; private set; }

        public Pieces SelectedPiece { get; set; }
    }
}

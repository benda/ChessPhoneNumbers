﻿using ChessPhoneNumbers.ComponentModel;
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

namespace ChessPhoneNumbers.ViewModel
{
    class MainWindowViewModel : NotifyPropertyChangedEntity
    {
        private int? _numberOfPhoneNumbers;
        private PathFinderResult _result;
        private IEnumerable<TreeNodeViewModel> _trees;
        private List<string> _phoneNumbers;

        public MainWindowViewModel()
        {
            AllPieces = Pieces.GetValues();
        }

        public void Find()
        {
            _result = new PhoneNumberService().FindAllPhoneNumbers(SelectedPiece.Piece);
            NumberOfPhoneNumbers = _result.AllPaths.Count;
            Trees = (from t in _result.PathTrees select new TreeNodeViewModel(t.Root));
            List<string> phoneNumbers = new List<string>();

            foreach(Path p in _result.AllPaths)
            {
                StringBuilder phoneNumber = new StringBuilder();
                foreach(Key k in p.Keys)
                {
                    phoneNumber.Append(k.Digit);
                }
                phoneNumbers.Add(phoneNumber.ToString());
            }

            phoneNumbers.Sort();
            PhoneNumbers = phoneNumbers;
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

        public List<string> PhoneNumbers
        {
            get { return _phoneNumbers; }

            set
            {
                _phoneNumbers = value;
                OnPropertyChanged(nameof(PhoneNumbers));
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

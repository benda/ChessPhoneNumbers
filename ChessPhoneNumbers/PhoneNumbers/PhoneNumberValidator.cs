using ChessPhoneNumbers.Domain;
using ChessPhoneNumbers.Paths;
using ChessPhoneNumbers.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.PhoneNumbers
{
    class PhoneNumberValidator : IPathValidator
    {
        private const int MaximumNumberOfDigitsInPhoneNumber = 7;

        public bool IsValid(TreeNode<Key> currentPosition, int currentDepth)
        {
            if(currentDepth > MaximumNumberOfDigitsInPhoneNumber)
            {
                return false;
            }

            if(currentDepth == 1)
            {
                if(currentPosition.Item.IsValue(0) || currentPosition.Item.IsValue(1))
                {
                    return false;
                }
            }

            if(currentPosition.Item.IsCharacter)
            {
                return false;
            }

            return true;
        }
    }
}

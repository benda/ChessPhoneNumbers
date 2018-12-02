using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Domain
{
    class Path
    {
        public LinkedList<Key> Keys { get; } = new LinkedList<Key>();

        public Path()
        {
        }      
    }
}

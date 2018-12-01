using ChessPhoneNumbers.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChessPhoneNumbers.Graphs
{
    class GraphReader
    {
        public Graph<Key> Read(String resourceName)
        {
            string graph = new ResourceReader().Get(resourceName);


        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessPhoneNumbers.Graphs
{
    class Graph<T>
    {
        public List<Vertex<T>> Vertices { get; } = new List<Vertex<T>>();

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessPhoneNumbers.Domain;

namespace ChessPhoneNumbers.Trees
{
    class TreeNode<T>
    {
        public T Item { get; }

        public TreeNode(T item, TreeNode<T> parent)
        {
            Item = item;
            Parent = parent;
        }

        public HashSet<TreeNode<T>> Children { get; } = new HashSet<TreeNode<T>>();
        public TreeNode<T> Parent { get; }

        public TreeNode<T> AddChild(T item)
        {
            TreeNode<T> child = new TreeNode<T>(item, this);
            Children.Add(child);
            return child;
        }

        public override string ToString()
        {
            return $"{Item}";
        }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode<T>;
            return node != null &&
                   EqualityComparer<T>.Default.Equals(Item, node.Item);
        }

        public override int GetHashCode()
        {
            return -979861770 + EqualityComparer<T>.Default.GetHashCode(Item);
        }
    }
}

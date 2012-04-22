using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HuffmanCoding
{
    [Serializable]
    public class BinaryTreeNode
    {
        public enum NodeDirection
        {
            Left,
            Right
        }

        public BinaryTreeNode() { }

        public BinaryTreeNode Parent = null;
        public BinaryTreeNode LeftChild = null;
        public BinaryTreeNode RightChild = null;

        public bool BitValue;
        public int? Key { get; set; }
        public ulong Value { get; set; }

        public void AddChildren(BinaryTreeNode btnLeftNode, BinaryTreeNode btnRightNode)
        {
            AddChild(btnLeftNode, NodeDirection.Left);
            AddChild(btnRightNode, NodeDirection.Right);
        }

        public void AddChild(BinaryTreeNode btn, NodeDirection nd)
        {
            btn.Parent = this;

            if(nd == NodeDirection.Left)
                this.LeftChild = btn;
            else
                this.RightChild = btn;
        }

        public char KeyAsChar
        {
            get
            {
                return Convert.ToChar(this.Key);
            }
        }

        public void SaveToDisk(string path)
        {
            var fi = new FileInfo(path);

            path = path.Replace(fi.Extension, ".hdef");

            Serializer.SaveAsBinaryFile<BinaryTreeNode>(path, this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1test
{
    public class Node
    {
        public int data;
        public Node next;
        public Node previous;
        public Node(int value)
        {
            data = value;
            next = null;
            previous = null;
        }
        public Node()
        {

        }

    }
}

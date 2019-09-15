using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    /// <summary>
    /// Represents a single node.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Represents a link to the next node.
        /// </summary>
        public Node Prox { get; internal set; }
        /// <summary>
        /// Represents the node's content.
        /// </summary>
        public int D { get; set; }

        public Node(int d) => D = d;

    }
    /// <summary>
    /// Represents a single linked list.
    /// </summary>
    public class LinkedList : IEnumerable<Node>
    {
        /// <summary>
        /// Represents the first (head) element.
        /// </summary>
        public Node First { get; private set; }
        /// <summary>
        /// Represents the last element.
        /// </summary>
        public Node Last
        {
            get
            {
                var aux = First;
                for (; aux.Prox != null; aux = aux.Prox) ;
                return aux;
            }
        }
        /// <summary>
        /// Gets total nodes in the list.
        /// </summary>
        public int Count => (from node in this select node).Count();
        public void Push(int d)
        {
            var novo = new Node(d);
            novo.Prox = First;
            First = novo;
        }
        public void Push(Node node)
        {
            node.Prox = First;
            First = node;
        }
        public void Pop()
        {
            if (First != null)
            {
                First = First.Prox;
            }
        }
        public void Pop(int d)
        {
            Node aux = First;
            while (First != null && First.D == d)
            {
                First = First.Prox;
            }

            for (Node ant = aux; aux != null; ant = aux, aux = aux.Prox)
            {
                if (aux.D == d)
                {
                    ant.Prox = aux.Prox;
                }
            }
        }
        public bool Contains(int d)
        {
            foreach (var _ in (this).Where(node => node.D == d))
            {
                return true;
            }
            return false;
        }
        public IEnumerator<Node> GetEnumerator()
        {
            var aux = First;
            while (aux != null)
            {
                yield return aux;
                aux = aux.Prox;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Node this[int i]
        {
            get => this.ElementAt(i);
            private set => this[i] = value;
        }
    }
}

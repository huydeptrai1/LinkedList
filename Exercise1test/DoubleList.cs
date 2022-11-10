using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1test
{
   
        public class DoubleList<t>
        {
            public Node CreateNode(int x)
            {

                Node p = new Node();
                if (p == null)
                {
                    Console.WriteLine("Khong du bo nho ");
                    return null;
                }

                p.data = x;
                p.next = null;
                p.previous = null;
                return p;

            }
            public void InitList(ref List l)
            {
                l.Head = l.Tail = null;
            }
            public bool IsEmptyList(List l)
            {
                if (l.Head == null)

                    return true;
                return false;
            }
            public void Printf(List l)
            {
                Node p = l.Head;
                while (p != null)
                {
                    Console.Write("   " + (p.data));
                    p = p.next;
                }
            }
            public void AddFirst(ref List l, Node p)
            {
                if (IsEmptyList((l)))
                {
                    l.Head = l.Tail = p;
                }
                else
                {
                    p.next = l.Head;
                    l.Head.previous = p;
                    l.Head = p;
                }
            }
            public void AddLast(ref List l, Node p)
            {
                if (IsEmptyList(l))
                {
                    l.Head = l.Tail = p;

                }
                else
                {
                    l.Tail.next = p;
                    p.previous = l.Tail;
                    l.Tail = p;

                }
            }
            public void AddAfter(ref List l, int k, int x)
            {
                if (k < 1 || k > x + 1)
                {
                    Console.Write("Vi tri khong hop le  xin vui long nhap lai "); return;
                }
                Node p = l.Head;
                for (int i = 1; i <= k - 1; i++)
                {
                    p = p.next;
                }
                Node temp = new Node();
                temp.data = x;
                temp.previous = p; ;
                temp.next = p.next;
                p.next.previous = temp;
                p.next = temp;
                return;
            }
            public void RemoveFirst(ref List l)
            {
                if (IsEmptyList(l))
                {
                    Console.WriteLine("Danh sach rong ");

                }
                else
                {
                    Node p = l.Head;
                    if (l.Head == l.Tail)
                    {
                        l.Head = l.Tail = null;

                    }
                    else
                    {
                        l.Head.next.previous = null;
                        l.Head = l.Head.next;
                        l.Head.previous = null;

                    }
                }
            }
            public void RemoveLast(ref List l)
            {
                if (IsEmptyList(l))
                {
                    Console.WriteLine("Danh sach rong ");

                }
                else
                {
                    Node p = l.Tail;
                    if (l.Head == l.Tail)
                    {
                        l.Head = l.Tail = null;

                    }
                    else
                    {
                        l.Tail.previous.next = null;
                        l.Tail = l.Tail.previous;
                        GC.Collect();

                    }
                }
            }
            public Node Seacrchanitem(List l, int x)
            {
                Node p;
                p = l.Head;
                while (p != null)
                {
                    if (p.data == x)
                    {
                        return p;
                    }
                    else
                    {
                        p = p.next;
                    }
                }
                return null;
            }
            public void RemoveAfter(ref List l, Node q)
            {
                if (IsEmptyList(l))
                {
                    Console.Write("Danh sach Rong");
                }
                else
                {
                    for (Node p = l.Head; p != null; p = p.next)
                    {
                        if (p.data == q.data)
                        {
                            Node k = p.next;
                            p.next = k.next;
                            GC.Collect();
                            return;
                        }
                    }

                }
            }
            public List SearchItems(ref List l, int x)
            {
                List l1 = new List();
                InitList(ref l1);
                Node p;
                p = l.Head;
                while (p != null)
                {
                    if (p.data > x)
                        AddLast(ref l1, CreateNode(p.data));
                    p = p.next;
                }
                return l1;
            }
            public void RemoveAll(ref List l)
            {

                for (Node p = l.Head; p != null; p = p.next)
                {
                    p = l.Head;
                    l.Head = p.next;
                    GC.Collect();
                }
            }
            public void MergeList(ref List l, Node p)
            {
                if (IsEmptyList(l))
                {
                    l.Head = l.Tail = null;

                }
                else
                {
                    l.Tail.next = p;
                    p.previous = l.Tail;
                    l.Tail = p;
                }

            }
            public void QuickSort(ref List l)
            {
                List l1 = new List();
                List l2 = new List();
                InitList(ref l1);
                InitList(ref l2);
                Node pi, p;
                if (l.Head == l.Tail)
                {
                    return;
                }
                pi = l.Head;
                p = l.Head.next;
                while (p != null)
                {
                    Node q = p;
                    p = p.next;
                    q.next = null;
                    q.previous = null;
                    if (q.data < pi.data)
                    {
                        AddLast(ref l1, q);
                    }
                    else
                    {
                        AddLast(ref l2, q);
                    }
                }
                QuickSort(ref l1);
                QuickSort(ref l2);
                if (!IsEmptyList(l1))
                {
                    l.Head = l1.Head;
                    l1.Tail.next = pi;
                    pi.previous = l1.Tail;
                }
                else
                {
                    l.Head = pi;
                }
                pi.next = l2.Head;
                if (!IsEmptyList(l2))
                {
                    l2.Head.previous = pi;
                    l.Tail = l2.Tail;
                }

                else
                {
                    l.Tail = pi;
                }
            }
            public void RemoveMid(ref List l, Node q)
            {
                Node p = q.next;
                q.next = p.next;
                if (p == l.Tail)
                {
                    l.Tail = q;
                }
                else
                {
                    p.next.previous = q;
                }
                p.next = null;
                p.previous = null;
            }
            public void SeclectionSort(ref List l)
            {
                List l1 = new List();
                InitList(ref l1);
                Node p, min, temp;

                //Sort loop. Will terminate if there is no node in lst
                do
                {
                    min = l.Head;
                    p = l.Head;
                    //Find the min node
                    while (p != null)
                    {
                        if (min.data > p.data)
                        {
                            min = p;
                        }
                        p = p.next;
                    }
                    //Unlink the min node from lst
                    if (min == l.Head)
                    {
                        RemoveFirst(ref l);        //This Remove functions do not have free()
                    }
                    else
                    {
                        temp = min.previous;
                        RemoveMid(ref l, temp);  //This Remove functions do not have free()
                    }
                    AddLast(ref l1, min); //Add min node into newList

                } while (!IsEmptyList(l));
                l = l1;
            }
        }
    }



using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Xml.Linq;

namespace QuanliSinhVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            LinkList<Node>list= new LinkList<Node>();
            Node q=new Node();
            for(int i=0;i<2;i++)
            {
                q = list.CreateNode();
                list.Insert(q);
            }
            Console.WriteLine("----------------------------------\n Danh sach theo thu tu: ");
            list.Printf();
            Console.WriteLine("--------------------------------\nTim sinh vien theo MSSV 21133: ");
            q= list.SearchAnItem(21133);
            q.data.Xuat();
            Console.WriteLine("--------------------------------\nTim sinh vien co Dtb cao nhat: ");
            Node  t = list.FindMaxDtb();
            list.PrintDtbMax();
            Console.WriteLine("----------------------------------\nTim danh sach sinh vien co Dtb >= 6.0: ");
            list.FinddtblonhonX(6.0);
            Console.WriteLine("-----------------------------\nXoa sinh vien co Dtb >= 6.0: ");
            list.Delete(6.0);
            list.Printf();
            Console.ReadLine();
        }
    }
    public class SinhVien
    {
        public string Name;
        public int Mssv;
        public double dtb;
        public SinhVien()
        {
            this.Name = "Null";
            this.Mssv = 0;
            this.dtb = 0.00;
        }
        public SinhVien(string Name, int Mssv, double dtb)
        {
            this.Name = Name;
            this.Mssv = Mssv;
            this.dtb = dtb;

        }
        public void Nhap()
        {
            Console.Write("Ho va Ten: ");
            this.Name = Console.ReadLine();
            Console.Write("Mssv: ");
            this.Mssv = int.Parse(Console.ReadLine());
            Console.Write("Diem trung binh: ");
            this.dtb = double.Parse(Console.ReadLine());

        }
        public void Xuat()
        {
            Console.WriteLine("Ho va Ten: " + (this.Name));
            Console.WriteLine("Mssv: " + (this.Mssv));
            Console.WriteLine("Diem Trung Binh: " + (this.dtb));
        }
    }
    public class Node
    {
        public SinhVien data = new SinhVien();
        public Node next;
        public Node(SinhVien d)
        {
            data = new SinhVien(d.Name, d.Mssv, d.dtb);
            next = null;
        }
        public Node() { }
    }
    public class LinkList<N>
    {

        public Node Head;
        public Node Tail;
        public Node CreateNode()
        {
            SinhVien a = new SinhVien();
            a.Nhap();
            Node p = new Node(a ) ;
            return p;

        }
        public void InitList()
        {
            this.Head = this.Tail = null;
        }
        public bool IsEmpty()
        {
            if (this.Head == null)
                return true;
            return false;
        }
        public void Printf()
        {
            Node p = this.Head;
            while (p != null)
            {
                p.data.Xuat();
                p = p.next;
            }
        }
        public void AddLast(Node p)
        {
            if (IsEmpty())
            {
                this.Tail = p;
                this.Head = p;
            }
            else
            {
                this.Tail.next = p;
                this.Tail = p;

            }
        }
        public void AddFirst(Node p)
        {

            if (IsEmpty())
            {
                this.Tail = p;
                this.Head = p;
            }
            else
            {
                p.next = this.Head;
                this.Head = p;
            }

        }
        public void AddMid(Node c, Node d)
        {
            d.next = c.next;
            c.next = d;
            if (c.next == this.Tail)
                this.Tail = d;
        }
        public void RemoveFirst()
        {
            Node p = this.Head;
            if (IsEmpty())
            {
                Console.WriteLine("Danh sach rong ");

            }
            else
            {
                if (this.Head == this.Tail)
                    this.Head = this.Tail = null;
                else
                {
                    this.Head = p.next;
                    p = null;
                }
            }
        }
        public void RemoveLast()
        {
            Node p = this.Head;
            Node temp = this.Tail;
            if (IsEmpty())
            {
                Console.WriteLine("Danh sach rong!");
            }
            else
            {
                //if there is only one node
                if (this.Head == this.Tail)
                    this.Head = this.Tail = null;
                //the rest circumstances
                else
                {
                    while (p.next != this.Tail)
                        p = p.next;
                    p.next = null;
                    this.Tail = p;
                }
                temp = null;
            }
        }
        public Node SearchAnItem(int x)
        {
            Node t = new Node();
            for (Node p = this.Head; p != null; p = p.next)
            {
                if (p.data.Mssv == x)
                {
                    t = p;
                    break;
                }
            }
            return t;
        }
        public LinkList<Node> SearchDTB(double x)
        {
            LinkList<Node> t = new LinkList<Node>();
            t.InitList();
            for (Node p = this.Head; p != null; p = p.next)
            {
                if (p.data.dtb >= x)
                {

                    t.AddLast(new Node(p.data));
                }
            }
            return t;
        }
        public void FinddtblonhonX(double x)
        {
            LinkList<Node> newl = new LinkList<Node>();
            newl.InitList();
            newl = this.SearchDTB(x);

            if (newl.IsEmpty())
                Console.WriteLine($"Khong co sinh vien nao co DTB >= {x}!");
            else
                newl.Printf();
        }
        public Node FindMaxDtb()
        {
            Node t = this.Head;

            for (Node p = this.Head; p != null; p = p.next)
            {
                if (t.data.dtb < p.data.dtb)
                    t = p;
            }


            Node Maximum = new Node(t.data);

            return Maximum;
        }
        public void PrintDtbMax()
        {
            Node Maximum = this.FindMaxDtb();

            Maximum.data.Xuat();
        }
        public void Delete(double x)
        {
            Node t = new Node();

            for (Node p = this.Head; p != null; p = p.next)
            {

                if (p == this.Head && p.data.dtb >= x)
                {
                    this.Head = p.next;
                    p = null;
                    p = this.Head;
                }

                else if (p != null && p.data.dtb >= x)
                {
                    if (p == this.Tail)
                        this.Tail = t;
                    else
                        t.next = p.next;
                    p = null;
                    p = t;
                }
                t = p;


            }
        }
        public void Insert(Node q)
        {

            if (this.IsEmpty())
                this.Head = this.Tail = q;

            else
            {

                if (this.Head.data.dtb >= q.data.dtb)
                    this.AddFirst(q);
                else
                {
                    Node p;

                    for (p = this.Head; p.next != null; p = p.next)
                    {

                        if (p.data.dtb <= q.data.dtb && p.next.data.dtb >= q.data.dtb)
                        {
                            q.next = p.next;
                            p.next = q;
                            break;
                        }
                    }

                    if (this.Tail == p)
                    {
                        this.Tail.next = q;
                        this.Tail = q;
                    }
                }
            }

        }
    }
}



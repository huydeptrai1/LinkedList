using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoubleList<Node> list = new DoubleList<Node>();
            List l1 = new List();
            List l2 = new List();
            list.InitList(ref l2);
            list.InitList(ref l1);
            int a;
            while (true)
            {
                Console.WriteLine("\n\n\t\t=============== MENU DANH SACH LIEN KET ================");
                Console.WriteLine("\n\t1 Them node vao dau danh sach:");
                Console.WriteLine("\n\t2 Them node vao cuoi danh sach:");
                Console.WriteLine("\n\t3 Them node p vao sau node q:");
                Console.WriteLine("\n\t4  In Xuôi:");
                Console.WriteLine("\n\t5 Xoa node dau:");
                Console.WriteLine("\n\t6 Xoa node cuoi:");
                Console.WriteLine("\n\t7 Xoa node p sau node q:");
                Console.WriteLine("\n\t8 Tim kiem 1 node:");
                Console.WriteLine("\n\t9 Tim kiem 1 node lon hon x :");
                Console.WriteLine("\n\t10 Gop 2 danh sach:");
                Console.WriteLine("\n\t11 Sap xep theo thuat toan QuickSort :");
                Console.WriteLine("\n\t12 Sap xep theo thuat toan SelectionSort :");
                Console.WriteLine("\n\t13 Xoa toan bo node:");
                Console.WriteLine("\n\t14 In Nguoc");
                Console.WriteLine("\n\t15-------------------Thoat-------------------------");
                Console.WriteLine("\n\n\t\t\t =============== End ==============");
                Console.WriteLine("\nnhap lua chon:");
                a = int.Parse(Console.ReadLine());
                if (a < 0)
                {
                    Console.WriteLine("Lua chon khong hop le xin kiem tra lai");
                }
                else if (a == 1)
                {
                    int x;
                    Console.WriteLine("Nhap gia tri so nguyen:");
                    x = int.Parse(Console.ReadLine());
                    Node p = list.CreateNode(x);
                    list.AddFirst(ref l1, p);
                }
                else if (a == 2)
                {
                    int x;
                    Console.WriteLine("Nhap gia tri so nguyen: ");
                    x = int.Parse(Console.ReadLine());
                    Node p = list.CreateNode(x);
                    list.AddLast(ref l1, p);

                }
                else if (a == 3)
                {
                    int k, x;
                    Console.WriteLine("\nNhap vi tri can chen sau:");
                    k = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nNhap gia tri can chen sau:");
                    x = int.Parse(Console.ReadLine());
                    list.AddAfter(ref l1, k, x);

                }
                else if (a == 4)
                {
                    Console.Write("Danh sach vua Nhap la: ");
                    list.Printf(l1);
                }
                else if (a == 5)
                {
                    list.RemoveFirst(ref l1);

                }
                else if (a == 6)
                {
                    list.RemoveLast(ref l1);
                }
                else if (a == 7)
                {
                    int c;
                    Console.WriteLine("\nNhap gia tri p can xoa sau q:");
                    c = int.Parse(Console.ReadLine());
                    Node p = list.CreateNode(c);
                    list.RemoveAfter(ref l1, p);
                }
                else if (a == 8)
                {
                    int x;
                    Console.WriteLine("\nNhap phan tu can tim:");
                    x = int.Parse(Console.ReadLine());
                    Node p = list.Seacrchanitem(l1, x);
                    if (p == null)
                    {
                        Console.WriteLine("\nKhong tim thay ket qua");
                    }
                    else
                    {
                        Console.WriteLine("\nTim thay ket qua " + (p.data));
                    }

                }
                else if (a == 9)
                {
                    int x;
                    Console.WriteLine("\nNhap phan tu lon hon x can tim:");
                    x = int.Parse(Console.ReadLine());
                    l2 = list.SearchItems(ref l1, x);
                    list.Printf(l2);

                }
                else if (a == 10)
                {
                    int n;
                    Console.WriteLine("\nNhap do dai cua DoubleList");
                    n = int.Parse(Console.ReadLine());
                    for (int i = 1; i <= n; i++)
                    {


                        int y;
                        Console.WriteLine("\nNhap gia tri cua cac node:");
                        y = int.Parse(Console.ReadLine());
                        Node p = list.CreateNode(y);
                        list.MergeList(ref l1, p);


                    }
                    Console.WriteLine("Danh sach da gop la:");
                    list.Printf(l1);

                }
                else if (a == 11)
                {
                    list.QuickSort(ref l1);
                    list.Printf(l1);
                }
                else if (a == 12)
                {
                    list.SeclectionSort(ref l1);
                    list.Printf(l1);
                }
                else if (a == 13)
                {
                    Console.WriteLine("Danh sach khong con phan tu nao ");
                    list.RemoveAll(ref l1);

                }
                else if (a == 14)
                {

                }

            }
            Console.ReadKey();
        }
    }
   
}
 
    
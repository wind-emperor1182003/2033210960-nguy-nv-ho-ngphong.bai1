
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

internal class Phanso
{
    int tuso;
    int mauso;
    float giatrithuc;
    List<Phanso> dsPhanso = new List<Phanso>();
    public Phanso()//pt ko co tham so
    {

        this.tuso=6;
        this.mauso=3;
    }
    public Phanso(int c, int b)//pt co 2 tham so
    {
        this.Tuso = c;
        this.Mauso = b;
    }
    public Phanso(Phanso x)//pt sao chép
    {
        Tuso = x.Tuso;
        Mauso = x.Mauso;
    }

    public int Tuso
    {
        get
        {
            return tuso;
        }
        set
        {
           tuso=value;
        }
    }
    public int Mauso
    {
        get
        {
            return mauso;
        }
        set
        {
           if(value != 0)
                mauso=value;
           else
                mauso=1;
        }
    }
    public float Giatrithuc
    {
        get
        {
            return (float)Tuso / Mauso;
        }
    }
    public void nhapps()
    {
        Console.WriteLine("nhap tu so");
        this.Tuso= int.Parse(Console.ReadLine());
        Console.WriteLine("nhap mau so");
        this.Mauso = int.Parse(Console.ReadLine());
    }
    public void InPhanso()
    {
        //int uc = UCLN(Tuso, Mauso);
        //Tuso = Tuso / uc;
        //Mauso = Mauso / uc;
        Console.Write("Phan so = " + Tuso + "/" + Mauso +"\n");
       
    }
    public int UCLN(int a,int b)
    {
        
        while(b!=0)
        {
            int c = b;
            b = a % b;
            a = c;
        }
        return a;
    }
    public void nhapdsPhanso()
    {
        Console.WriteLine("nhap so phan tu can nhap:");
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            Console.WriteLine("nhap phan so thu " + (i));
            Phanso x = new Phanso();
            x.nhapps();
           
            dsPhanso.Add(x);
           
        }
        dsPhanso.Sort(new SoSanhPhanSo());
       
    }

    public void indsPhanso()
    {
       
        Console.WriteLine("xuat ds phan so:");
        //foreach (Phanso x in dsPhanso)
           
        //    x.InPhanso();
        for(int i = 0; i < dsPhanso.Count; i++)
            {

            dsPhanso[i].InPhanso();
        }
    }
    public void timPhanso()
    {
        int kiemtra = 0;
        Console.WriteLine("nhap tu cua phan so muon tim");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("nhap mau cua phan so muon tim");
        int y = int.Parse(Console.ReadLine());
        foreach (Phanso z in dsPhanso)
            if (x == z.Tuso && y == z.Mauso)
                kiemtra = 1;
      if(kiemtra == 1)
            Console.WriteLine("\nPhân số {0}/{1} có trong danh sách", x, y);
      else
            Console.WriteLine("\nPhân số {0}/{1} ko co trong danh sách", x, y);
    }
    public void timfloatlonhon1()
    {
        int dem = 0;
        int kiemtra = 0;
        foreach (Phanso z in dsPhanso)
            if (z.Giatrithuc > 1)
            {
                kiemtra = 1;
                dem++;
                Console.WriteLine("có {0} phan so co gia tri thuc lon hon 1", dem);
                z.InPhanso();
            }
        if (kiemtra == 0)
            Console.WriteLine("không có phân số nào trên 1");
    }
    public void tim3pslonnhat()
    {
        dsPhanso.Reverse();
        List<Phanso> phansos = dsPhanso.OrderByDescending(p => p.Giatrithuc).ToList();
        Phanso phanSoLonNhat1 = dsPhanso[0];
        Phanso phanSoLonNhat2 = dsPhanso[1];
        Phanso phanSoLonNhat3 = dsPhanso[2];
        phanSoLonNhat1.InPhanso();
        phanSoLonNhat2.InPhanso();
        phanSoLonNhat3.InPhanso();

    }

    class SoSanhPhanSo : IComparer<Phanso>
    {
        public int Compare(Phanso x, Phanso y)
        {
            float giaTriX = (float)x.Tuso / x.Mauso;
            float giaTriY = (float)y.Tuso / y.Mauso;
            return giaTriX.CompareTo(giaTriY);
        }
    }

    public Phanso congps(Phanso ps2)//ko tham so
    {
        Phanso psc = new Phanso();
        psc.tuso = this.tuso * ps2.mauso + ps2.tuso * this.mauso;
        psc.mauso = this.mauso * ps2.mauso;
        return psc;

        //Phanso ph3 = new Phanso();
        //ph3.Tuso = (ph1.Tuso * ph2.Mauso) + (ph2.Tuso * ph1.Mauso);
        //ph3.Mauso = ph1.Mauso * ph2.Mauso;
        //int uc = UCLN(ph3.Tuso, ph3.Mauso);
        //ph3.Tuso = ph3.Tuso / uc;
        //ph3.Mauso = ph3.Mauso / uc;
        //return ph3;
    }
    public Phanso congpsnguyen(Phanso ph1, int a)//ko tham so
    {

        Phanso ph3 = new Phanso();
        ph3.Tuso = ph1.Tuso * 1 + a * ph1.Mauso;
        ph3.Mauso = ph1.Mauso * 1;
        int uc = UCLN(ph3.tuso, ph3.mauso);
        ph3.tuso = ph3.tuso / uc;
        ph3.mauso = ph3.mauso / uc;
        return ph3;
    }
}

internal class Program
{
    static void menu()
    {
        Console.WriteLine("1. Tạo 1 phân số x = {3, 6}, tối giản phân số x");
        Console.WriteLine("2. Tạo phân số a, phân số b, tính phân số tổng t1");
        Console.WriteLine("3. Tạo phân số p, số nguyên x, tính phân số tổng t2");
        Console.WriteLine("4. Danh sách phân số");
    }
    private static void Main(string[] args)
    {
        menu();
        int chon;
        do
        {
            Console.WriteLine("chon chuong trinh ban muon chon:");
            chon=int.Parse(Console.ReadLine());
            switch(chon)
            {
                case 1:
                    {
                        Phanso x = new Phanso(3,6);
                       
                            x.InPhanso();
                        break;
                    }
                    case 2:
                    {

                        Phanso p1 = new Phanso();
                        Phanso p2 = new Phanso();
                        Phanso p3 = new Phanso();
                        
                        p1.InPhanso();
                        break;
                    }
                case 3:
                    {
                        Phanso p1 = new Phanso();
                        Phanso p3 = new Phanso();
                        Console.WriteLine("Nhap phan so 1");
                        p1.nhapps();
                        Console.WriteLine("nhap 1 so nguyen");
                        int a = int.Parse(Console.ReadLine());
                        p3 = p3.congpsnguyen(p1, a);
                        Console.WriteLine("tong 2 phan so la");
                        p3.InPhanso();

                        break;
                    }
                case 4:
                    {
                        Phanso x = new Phanso();
                        x.nhapdsPhanso();
                        x.indsPhanso();
                        x.timPhanso();
                        x.timfloatlonhon1();
                        Console.WriteLine("tim 3 phan so lon nhat");
                        x.tim3pslonnhat();
                        break;
                    }
            }
            Console.WriteLine();
        } while (chon != 0);
    }
}
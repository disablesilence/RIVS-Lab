using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employee
{
    public abstract class BaseEmployee
    {
        protected string name = "";
        protected const int max_post = 10;
        protected string[] post = new string[max_post];
        public int count_post = 0;
        protected int age = 0, workxp = 0; 
    }

    public interface EmpInt
    {
        void GetOlder(int new_age);
        void GetNewPost(string new_post);
        void GetMoreXP();
    }

    public interface AmpInt 
    {
        void GetOlder(int years, bool x);
        void GetMoreXP();
        void GetNewPost(string  new_post);
        
    }
    
    public class Employee:BaseEmployee,EmpInt,AmpInt
    {
        public void GetOlder(int new_age) { age = Convert.ToInt32(new_age); }
        public void GetOlder(int years, bool x) { age = age + Convert.ToInt32(years); }
        
        public void GetNewPost(string new_post)
        {
            int i;
            i = count_post;
            count_post++;
            post[i] = new_post;             
        }
        
        void EmpInt.GetMoreXP() { workxp = workxp + 1; }
        void AmpInt.GetMoreXP() { workxp = workxp + 2; }
        public void XPUp() { ((EmpInt)this).GetMoreXP(); }
        public void XPUp2() { ((AmpInt)this).GetMoreXP(); }
        
        
        public string this[int i]
        {	
            set
            {
                if (i == count_post && i < max_post)
                {
                    post[i] = value; count_post++;
                }
            }
            get
            {
                if (i >= 0 && i < count_post) return (post[i]);
                else return (post[0]);
            }
        }
    public string Name { set; get; }
    public int Age { set; get; }
    public int Workxp { set; get; }
    } 
        
    class Program
    {
        static void Main()
        {
            /*Employee e1 = new Employee();
            e1.Age = 20;
            e1.Name = "Vasiliy";
            e1.Workxp = 1;
            e1[0] = "Сотрудник";
            Console.Write("Имя = {0}, Возраст = {1}, Стаж = {2}, Должност(и) = ", e1.Name, e1.Age, e1.Workxp);
            for (int i = 0; i+1 <= e1.count_post; i++)
            {
                Console.Write(" {0} ", e1[i]);
            }
            Console.Read();*/ //Тестовый фрагмент кода, не удалять

            int i = 1;

            Employee e1 = new Employee();
            Console.WriteLine("Введите имя сотрудника:");
            try { e1.Name = Convert.ToString(Console.ReadLine()); }
            catch (Exception e) { Console.WriteLine("{0}",e); }
            
            Console.WriteLine("Введите возраст сотрудника {0}:", e1.Name);
            try { e1.Age = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception e) { Console.WriteLine("{0}", e); }

            Console.WriteLine("Введите стаж сотрудника {0}:", e1.Name);
            try { e1.Workxp = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception e) { Console.WriteLine("{0}", e); }

            Console.WriteLine("Введите количество должностей сотрудника {0}:",e1.Name);
            try { i = Convert.ToInt32(Console.ReadLine()); }
            catch (Exception e) { Console.WriteLine("{0}", e); }

            for (int n = 1; n <= i; n++)
            {
                Console.WriteLine("Введите должность № {0}", n);
                try { e1[n - 1] = Console.ReadLine(); }
                catch (Exception e) { Console.WriteLine("{0}", e); }
            }
            
            Console.Write("Имя = {0}, Возраст = {1}, Стаж = {2}, Должност(и) = ", e1.Name, e1.Age, e1.Workxp);
            for (i = 0; i + 1 <= e1.count_post; i++)
            {
                Console.Write(" {0} ", e1[i]);
            }
            Console.Read();

            
        }
    }
}


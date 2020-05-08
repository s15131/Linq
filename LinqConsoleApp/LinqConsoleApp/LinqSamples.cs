using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqConsoleApp
{
    public class LinqSamples
    {
        public static IEnumerable<Emp> Emps { get; set; }
        public static IEnumerable<Dept> Depts { get; set; }

        public LinqSamples()
        {
            LoadData();
        }

        public void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            
            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;

            #endregion

        }


        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        public void Przyklad1()
        {
            //var res = new List<Emp>();
            //foreach(var emp in Emps)
            //{
            //    if (emp.Job == "Backend programmer") res.Add(emp);
            //}

            //1. Query syntax (SQL)
            var res = from emp in Emps
                      where emp.Job == "Backend programmer"
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job
                      };

            foreach(var re in res)
            {
                Console.WriteLine(re);
            }

            //2. Lambda and Extension methods
            var res1 = Emps.Where(x => x.Job == "Backend programmer");

            foreach (var re in res1)
            {
                Console.WriteLine(re);
            }
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        public void Przyklad2()
        {
            //2. Query syntax (SQL)
            var res2 = from emp in Emps
                      where emp.Job == "Frontend programmer" && emp.Salary > 1000
                      orderby emp.Ename descending
                      select new
                      {
                          Nazwisko = emp.Ename,
                          Zawod = emp.Job,
                          Pensja =emp.Salary
                      };

            foreach (var re in res2)
            {
                Console.WriteLine(re);
            }


            var res3 = Emps.Where(x => x.Job == "Frontend programmer" && x.Salary>1000).OrderByDescending(x=>x.Ename);

            foreach (var re in res3)
            {
                Console.WriteLine(re);
            }
        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        public void Przyklad3()
        {


            Console.WriteLine((from Emp in Emps select Emp.Salary).Max());
            
   
            Console.WriteLine(Emps.Max(x => x.Salary));
            
      
        }

        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Przyklad4()
        {
            var res4 = from emp in Emps
                       where emp.Salary==(from Emp in Emps select Emp.Salary).Max()
                       select new
                       {
                           Nazwisko = emp.Ename,
                           Zawod = emp.Job,
                           Pensja = emp.Salary
                       };
            foreach (var re in res4)
            {
                Console.WriteLine(re);
            }

            var res5 =Emps.Where(x =>x.Salary == Emps.Max(x => x.Salary));
            
            foreach (var re in res5)
            {
                Console.WriteLine(re);
            }
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public void Przyklad5()
        {
            var res6 = from emp in Emps
                       select new
                       {
                           Nazwisko = emp.Ename,
                           Praca  = emp.Job
                       };
            foreach (var re in res6)
            {
                Console.WriteLine(re);
            }

           
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public void Przyklad6()
        {
            var res7 = from emp in Emps 
                       join dept in Depts
                       on emp.Deptno equals dept.Deptno
                       select new
                       {
                           Nazwisko = emp.Ename,
                           Praca = emp.Job,
                           Departament = dept.Dname
                       };
            foreach (var re in res7)
            {
                Console.WriteLine(re);
            }
        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public void Przyklad7()
        {
            var res8 = from emp in Emps 
                       group emp by emp.Job into nowa
                       select new { 
                           Praca = nowa.Key,
                           LiczbaPracownikow = (Emps.Where(x => x.Job == nowa.Key)).Count() };


            foreach (var re in res8)
            {
                Console.WriteLine(re);
            }

        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public void Przyklad8()
        {
            

            Console.WriteLine((from Emp in Emps where Emp.Job == "Backend programmer" select true).Any());

            Console.WriteLine(Emps.Where(x => x.Job == "Backend programmer").Any());

            
              
            
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Przyklad9()
        {
            Console.WriteLine(Emps.Where(x => x.Job == "Frontend programmer").OrderByDescending(x => x.HireDate).FirstOrDefault());

            Console.WriteLine((from emp in Emps
                              where emp.Job == "Frontend programmer"
                              orderby emp.HireDate descending
                              select new
                              {
                                  Nazwisko = emp.Ename
                              }).FirstOrDefault());

            
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        public void Przyklad10Button_Click()
        {
            var res10 = (Emps.Select(x => (x.Ename, x.Job, x.HireDate)).Union(Emps.Select(y => (Ename: "Brak Wartości", Job: (string)null, HireDate: (DateTime?)null))));
            foreach (var re in res10)
            {
                Console.WriteLine(re);
            }
        }

        //Znajdź pracownika z najwyższą pensją wykorzystując metodę Aggregate()
        public void Przyklad11()
        {
            Console.WriteLine(Emps.Aggregate((a, b) => a.Salary > b.Salary ? a : b));
        }

        //Z pomocą języka LINQ i metody SelectMany wykonaj złączenie
        //typu CROSS JOIN
        public void Przyklad12()
        {
            
            var res12 = Emps.SelectMany(x => Depts.Select(y => new {
                Nazwisko = x.Ename,
                Departament = y.Dname,
            }));

            foreach (var re in res12)
            {
                Console.WriteLine(re);
            }
        }
    }
}

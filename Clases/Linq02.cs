using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RepasoLinq.Clases;

namespace Demo01.Clases
{
    public class Linq02
    {
        List<Student> _student = new List<Student>(){
            new Student(){Id = 1, Name = "Sebas", Age = 19,IDS=2},
            new Student(){Id = 2, Name = "Nico", Age = 18,IDS=1},
            new Student(){Id = 3, Name = "Juan", Age = 19,IDS=3},
            new Student(){Id = 4, Name = "Rigo",Age = 17,IDS=4}
        };
        List<Standard> _standard = new List<Standard>(){
            new Standard(){Id=1,Dinero=32,Signo="Capricornio"},
            new Standard(){Id=2,Dinero=14,Signo="Tauro"},
            new Standard(){Id=3,Dinero=4,Signo="Libra"},
            new Standard(){Id=4,Dinero=41,Signo="Cancer"},
        };


        

        public void PrintData()
        {
            var teenStudents = _student.Where(s => s.Age > 12 && s.Age < 20).ToList<Student>();
            teenStudents.ForEach(tp => Console.WriteLine($"{tp.Name}"));
        }

        public void NameId()
        {
            var expre = from s in _student select new { s.Id, s.Name };

            foreach (var item in expre)
            {
                Console.WriteLine($"Id:{item.Id} \nNombre:{item.Name}");
            }
        }
        public void PrintDatav3(){
            var result_=_student.Where((s,i)=>{
                if(i%2==0){
                    return true;
                }
                return false;
            }).ToList();
            result_.ForEach(re=> Console.WriteLine($"{re.Name}"));
        }
        public void PrintDataV4(){
         var OrderByidascending=(from s in _student
                    orderby s.Id
                    select s).ToList();
         var OrderByidDesending=(from s in _student
            orderby s.Id descending
            select s).ToList();
        var OrderByNameasending=(from s in _student
            orderby s.Name
            select s).ToList();
        var OrderByNameDesending=(from s in _student
            orderby s.Name descending
            select s).ToList();
        var OrderByAgeasending=(from s in _student
            orderby s.Age
            select s).ToList();
        var OrderByAgeDesending=(from s in _student
            orderby s.Age
            select s).ToList();
        Console.WriteLine("How do you prefer order your stundents?");
        Console.WriteLine("1.Id-Asending");
        Console.WriteLine("2.Id-Desending");
        Console.WriteLine("3.Name-Asending");
        Console.WriteLine("4.Name-Desending");
        Console.WriteLine("5.Age-Asending");
        Console.WriteLine("6.Age-Desending");
        string op=Console.ReadLine();
        if(Convert.ToInt16(op)==1)
            OrderByidascending.ForEach(n => Console.WriteLine($"Id:{n.Id}-Name:{n.Name}-Age:{n.Age}"));
        if(Convert.ToInt16(op)==2)
            OrderByidDesending.ForEach(n => Console.WriteLine($"Id:{n.Id}-Name:{n.Name}-Age:{n.Age}"));
        if(Convert.ToInt16(op)==3)    
            OrderByNameasending.ForEach(n => Console.WriteLine($"Id:{n.Id}-Name:{n.Name}-Age:{n.Age}"));
        if(Convert.ToInt16(op)==4)
            OrderByNameDesending.ForEach(n => Console.WriteLine($"Id:{n.Id}-Name:{n.Name}-Age:{n.Age}"));
        if(Convert.ToInt16(op)==5)
            OrderByAgeasending.ForEach(n => Console.WriteLine($"Id:{n.Id}-Name:{n.Name}-Age:{n.Age}"));
        if(Convert.ToInt16(op)==6)
            OrderByAgeDesending.ForEach(n => Console.WriteLine($"Id:{n.Id}-Name:{n.Name}-Age:{n.Age}"));
        

        }
        public void StandardAgruped(){
                var innerJoin= _student.Join(
            _standard,
            student => student.IDS,
            standard => standard.Id,
            (student,standard)=> new
            {
                Name=student.Name,
                standard=standard.Signo
            } 
        ).ToList();
        innerJoin.ForEach(student=> Console.WriteLine($"Name: {student.Name}== Standard:{student.standard}"));
        }

    }
}
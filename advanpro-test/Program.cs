
using System;
using System.Collections;
 
 
namespace PrjObjectPooling
{
   class Program
   {
      static void Main(string[] args)
      {
         Factory fa = new Factory();
         Student myStu = fa.GetStudent();
         myStu.Firstname = "tri";
         Console.WriteLine("First object");
         Student myStu1 = fa.GetStudent();
         myStu1.Firstname = "thanh";
         Console.WriteLine("Second object");
         Student myStu2 = fa.GetStudent();
         myStu2.Firstname = "tran";
         Console.WriteLine("Third object");
         Student student = fa.GetStudent();
         student.Firstname = "student";
         Console.Read();
      }
   }
 
 
   class Factory
   {
      // Maximum objects allowed!
      private static int _PoolMaxSize = 2;
      // My Collection Pool
      private static readonly Queue objPool = new
         Queue(_PoolMaxSize);
      public Student GetStudent()
      {
         Student oStudent;
         // Check from the collection pool. If exists, return
         // object; else, create new
         if (Student.ObjectCounter >= _PoolMaxSize &&
            objPool.Count > 0)
         {
            // Retrieve from pool
            oStudent = RetrieveFromPool();
         }
         else
         {
            oStudent = GetNewStudent();
         }
         return oStudent;
      }
      private Student GetNewStudent()
      {
         // Creates a new Student
         Student oStu = new Student();
         objPool.Enqueue(oStu);
         return oStu;
      }
      protected Student RetrieveFromPool()
      {
         Student oStu;
         // Check if there are any objects in my collection
         if (objPool.Count > 0)
         {
            oStu = (Student) objPool.Dequeue();
            Student.ObjectCounter--;
         }
         else
         {
            // Return a new object
            oStu = new Student();
         }
         return oStu;
      }
   }
   class Student
   {
      public static int ObjectCounter = 0;
      public Student()
      {
         
         ++ObjectCounter;
      }
      private string _Firstname;
      private string _Lastname;
      private int _RollNumber;
      private string _Class;
 
 
      public string Firstname
      {
         get
         {
            return _Firstname;
         }
         set
         {
            _Firstname = value;
         }
      }
 
      public string Lastname
      {
         get
         {
            return _Lastname;
         }
         set
         {
            _Lastname = value;
         }
      }
 
      public string Class
      {
         get
         {
            return _Class;
         }
         set
         {
            _Class = value;
         }
      }
 
      public int RollNumber
      {
         get
         {
            return _RollNumber;
         }
         set
         {
            _RollNumber = value;
         }
      }
   }
}
using System;
using System.Collections.Generic;

namespace ObjectPool
{
    class ObjectPool<T> where T : new()
    {
        private static List<T> _available = new List<T>();
        private List<T> _inUse = new List<T>();
        
        private int counter = 0;
        private int MAXTotalObjects;
        
        private static ObjectPool<T> instance = null;
 
        public static ObjectPool<T> GetInstance()
        {
            if (instance == null)
            {
                instance = new ObjectPool<T>();
            }
            else
            {
                Console.WriteLine("This is singleton!");
            }
            return instance;
        }
 
        public T AcquireReusable()
        {
            if (_available.Count != 0 && _available.Count < 10)
            {
                T item = _available[0];
                _inUse.Add(item);
                _available.RemoveAt(0);
                counter--;
                return item;
            }
            else
            {
                T obj = new T();
                _inUse.Add(obj);
                return obj;
            }
        }
 
        public void ReleaseReusable(T item)
        {
            if (counter <= MAXTotalObjects)
            {
                _available.Add(item);
                counter++;
                _inUse.Remove(item);
            }
            else
            {
                Console.WriteLine("To much object in pool!");
            }
        }
 
        public void SetMaxPoolSize(int settingPoolSize)
        {
            MAXTotalObjects = settingPoolSize;
        }
    }
 
    class PooledObject
    {
        DateTime _createdAt = DateTime.Now;
 
        public DateTime CreatedAt
        {
            get { return _createdAt; }
        }

        public string name;

    }
 
    class Program
    {
        static void Main(string[] args)
        {
            ObjectPool<PooledObject> objPool = ObjectPool<PooledObject>.GetInstance();
            objPool.SetMaxPoolSize(7);
            PooledObject obj = objPool.AcquireReusable();
            Console.WriteLine(obj.name = "tri");
            
            PooledObject obj2 = objPool.AcquireReusable();
            Console.WriteLine(obj2.name = "tran");
            
            PooledObject obj3 = objPool.AcquireReusable();
            Console.WriteLine(obj3.name = "trang");
            
            PooledObject obj5 = objPool.AcquireReusable();
            Console.WriteLine(obj5.name = "trisgfsdfasdf");
            
            PooledObject obj6 = objPool.AcquireReusable();
            Console.WriteLine(obj6.name = "linh");
            
            PooledObject obj7 = objPool.AcquireReusable();
            Console.WriteLine(obj7.name = "ngoc");
            
            PooledObject obj8 = objPool.AcquireReusable();
            Console.WriteLine(obj8.name = "ly");
            
            PooledObject obj4= objPool.AcquireReusable();
            Console.WriteLine(obj4.name = "hong");
            PooledObject obj9= objPool.AcquireReusable();
            Console.WriteLine(obj9.name = "hong2");
            objPool.ReleaseReusable(obj);
            objPool.ReleaseReusable(obj2);
            objPool.ReleaseReusable(obj3);
            objPool.ReleaseReusable(obj4);
            objPool.ReleaseReusable(obj5);
            objPool.ReleaseReusable(obj6);
            objPool.ReleaseReusable(obj7);
            objPool.ReleaseReusable(obj8);
            objPool.ReleaseReusable(obj9);
             obj3 = objPool.AcquireReusable();
             Console.WriteLine(obj == obj3);
            

            Console.WriteLine(obj2 == obj);
            
            
            
            Console.ReadKey();
        }
    }
}
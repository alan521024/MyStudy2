using System;

namespace ParamDemo
{
    class TestClass
    {
        public int Val = 20;
    }

    class Program
    {
        static void MyTest(TestClass f1, int f2)
        {
            f1.Val = f1.Val + 5;
            f2 = f2 + 5;
            Console.WriteLine("Before: f1.Val: {0}, f2: {1}", f1.Val, f2);
        }

        static void Main(string[] args)
        {
            TestClass a1 = new TestClass();
            int a2 = 10;

            MyTest(a1, a2);

            Console.WriteLine("After: f1.Val: {0}, f2: {1}", a1.Val, a2);
            Console.ReadKey();
        }
    }

    class Program2
    {
        static void MyMethod(ref TestClass f1, ref int f2)
        {
            f1.Val = f1.Val + 5;
            f2 = f2 + 5;
            Console.WriteLine("f1.Val: {0}, f2: {1}", f1.Val, f2);
        }

        static void Main(string[] args)
        {
            TestClass a1 = new TestClass();
            int a2 = 10;

            MyMethod(ref a1, ref a2);

            Console.WriteLine("f1.Val: {0}, f2: {1}", a1.Val, a2);

        }
    }

    class Program3
    {
        static void RefAsParameter(TestClass f1)
        {
            f1.Val = 50;
            Console.WriteLine("After member assignment:   {0}", f1.Val);
            f1 = new TestClass();
            Console.WriteLine("After new object creation: {0}", f1.Val);
        }
        static void Main(string[] args)
        {

            TestClass a1 = new TestClass();
            Console.WriteLine("Before method  call:       {0}", a1.Val);
            RefAsParameter(a1);
            Console.WriteLine("After method  call:        {0}", a1.Val);
        }
    }

    class Program4
    {
        static void RefAsParameter(ref TestClass f1)
        {
            f1.Val = 50;
            Console.WriteLine("After member assignment:   {0}", f1.Val);
            f1 = new TestClass();
            Console.WriteLine("After new object creation: {0}", f1.Val);
        }
        static void Main(string[] args)
        {

            TestClass a1 = new TestClass();
            Console.WriteLine("Before method  call:       {0}", a1.Val);
            RefAsParameter(ref a1);
            Console.WriteLine("After method  call:        {0}", a1.Val);
        }
    }
}

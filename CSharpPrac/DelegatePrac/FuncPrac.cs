

using System;

namespace DelegatePrac
{
    public class FuncPrac
    {
        public static void FuncDelegate()
        {
            // Anonymous Method
            Func<int,int,int> sum = delegate(int i, int i1)
                                    {
                                        return i + i1;
                                    };
            Console.WriteLine("Hello Function Delegate!");
            Console.WriteLine(sum(1,3));    
    
    
            // lambda
            Func<int, int, int> func = (x, y) => x + y;
            int res = func(10, 20);
            Console.WriteLine(func(10,10));
            Console.WriteLine(res);
        }
    }
}

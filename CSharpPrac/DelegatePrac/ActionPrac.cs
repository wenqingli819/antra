using System;

namespace DelegatePrac
{
    public class ActionPrac
    {
        public static void ActionDelegate()
        {
            //anonymous method
            Action<int,int,int> Print = delegate(int i, int i1, int i2)
                                            {
                                                Console.WriteLine("Hello Action Delegate!");
                                                Console.WriteLine(i);
                                                Console.WriteLine(i1);
                                                Console.WriteLine(i2);
                                            };
            Print(2,3,4);
            
            //lambda
            Action<int, int, int> Print2 = (a, b, c) =>
            {
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine(c);
            };
            Print2(6,7,8);
        }
    }
}
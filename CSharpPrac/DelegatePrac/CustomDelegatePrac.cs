using System;

namespace DelegatePrac
{
    public class CustomDelegatePrac
    {
        delegate int NumberChanger(int n);
        private static int num = 10;

        public static int AddNum(int p)
        {
            num += p;
            return num;
        }

        public static int MultNum(int q)
        {
            num *= q;
            return num;
        }

        public static int getNum()
        {
            return num;
        }
        
        public static void CustomDelegate()
        {
            NumberChanger nc1 = new NumberChanger(AddNum);
            NumberChanger nc2 = new NumberChanger(MultNum);
        
            Console.WriteLine("Hello Custom Delegate!");
            nc1(25);
            Console.WriteLine("Value of Num: {0}",getNum());
            nc2(5);
            Console.WriteLine("Value of Num: {0}",getNum());
        }
        
    }
   
}
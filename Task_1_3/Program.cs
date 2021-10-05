using System;

namespace Task_1_3
{
    #region InitialDataClass
    class InitialDataClass
    {
        internal static string S;
        internal static int M;
        internal static int c1 = 1;
        internal static int c2 = 0;
        internal static int c3 = 0;
    }
    #endregion
    
    #region GetNumberClass
    class GetNumberClass
    {
        internal static void GetNumber()
        {
            Console.WriteLine("Здравствуйте!");
            Console.WriteLine("Вас приветствует математическая программа.");
            Console.WriteLine("Пожалуйста, введите число.");
            InitialDataClass.S = Console.ReadLine();
            if (InitialDataClass.S == "q")
            {
                return;
            }
        }
    }
    #endregion
    
    #region ParsToIntClass
    class ParsToIntClass
    {
        internal static void ParsToInt()
        {
            InitialDataClass.M = Int32.Parse(InitialDataClass.S);
        }
    }
    #endregion

    #region FactorialCalcClass
    class FactorialCalcClass
    {
        internal static void FactorialCalc()
        {
            for (int i = 1; i <= InitialDataClass.M; i++)
            {
                InitialDataClass.c1 *= i;
            }
        }
    }
    #endregion

    #region SumCalcClass
    class SumCalcClass
    {
        internal static void SumCalc()
        {
            for (int i = 1; i <= InitialDataClass.M; i++)
            {
                InitialDataClass.c2 += i;
            }
        }
    }
    #endregion
    
    #region MaxNumClass
    class MaxNumClass
    {
        internal static void MaxNum()
        {
            for (int i = 1; i <= InitialDataClass.M; i++)
            {
                if (i % 2 == 0)
                {
                    InitialDataClass.c3 = i;
                }
            }
        }
    }
    #endregion
    
    #region ShowResultClass
    class ShowResultClass
    {
        internal static void ShowResult()
        {
            Console.WriteLine($"Факториал равен {InitialDataClass.c1}.");
            Console.WriteLine($"Сумма от 1 до {InitialDataClass.S} равна {InitialDataClass.c2}.");
            Console.WriteLine($"Максимальное четное число меньше {InitialDataClass.S} равно {InitialDataClass.c3}.");
            Console.ReadLine();
        }
    }
    #endregion
    
    class Program
    {
        static void Main(string[] args)
        {
            Task_1_3.GetNumberClass.GetNumber();
            ParsToIntClass.ParsToInt();
            FactorialCalcClass.FactorialCalc();
            SumCalcClass.SumCalc();
            MaxNumClass.MaxNum();
            ShowResultClass.ShowResult();
        }
    }
}

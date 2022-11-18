﻿using System;

namespace dz1
{
  class Program
  {
    static void task1n1()
    {
      // TTo ycJIoBul0 He cka3aHo, KAK BblBoDuTb 4ucJIa,
      // TToeToMy BblBo>l<y TaK
      for (int i = 9; i > 0; i--)
        for (int j = i - 1; j >= 0; j--)
          for (int k = j - 1; k >= 0; k--)
            for (int p = k - 1; p >= 0; p--)
              Console.Write($"{i}{j}{k}{p} ");
      Console.WriteLine();
    }

    static void task1n2()
    {
      int n = 0;
      do n = Convert.ToInt32(Console.ReadLine());
      while (n > 9);

      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < n; j++)
        {
          if (j > i) // esli element vishe diagonali
            Console.Write((n + i - j) + " ");
          else
            Console.Write((n - i + j) + " ");
        }
        Console.WriteLine();
      }
    }

    static void task2n1()
    {
      uint n = Convert.ToUInt32(Console.ReadLine());
      bool flag = false;
      for (int i = 31; i >= 0; i--)
      {
        uint val = ((uint)1 << i) & n;
        if (val != 0)
          flag = true;
        if (flag)
          Console.Write(val >> i);
      }
      Console.WriteLine();
    }


    static void printUintBinary(int num_len, uint number)
    {
      for (int i = num_len; i >= 0; i--)
      {
        uint val = ((uint)1 << i) & number;
        Console.Write(val >> i);
      }
      Console.WriteLine();
    }
    static void task2n2()
    {
      // zadanie 2.2
      uint n = Convert.ToUInt32(Console.ReadLine()),
           m = Convert.ToUInt32(Console.ReadLine());
      int num_len = 0;
      uint answer = n + m;
      if (answer == 0)
      {
        Console.WriteLine("0\n0\n*\n0");
        return;
      }
      // calculate binary length
      for (int i = 31; (num_len == 0) && (i >= 0); i--)
      {
        uint val = ((uint)1 << i) & answer;
        if (val != 0)
          num_len = i;
      }
      Console.WriteLine();

      // print numbers
      printUintBinary(num_len, n);
      printUintBinary(num_len, m);

      // print **..**
      for (int i = 0; i <= num_len; i++)
        Console.Write('*');
      Console.WriteLine();

      // print answer
      printUintBinary(num_len, answer);

      Console.WriteLine();
    }


    static void printlongBinary(long n)
    {
      for (int i = 63; i >= 0; i--)
      {
        if (i % 8 == 7) Console.Write(" ");
        ulong val = (((ulong)1 << i) & (ulong)n);
        Console.Write(val >> i);
      }
      Console.WriteLine();
    }
    static void task2n3()
    {
      // zadanie 2.3         

      const int llll = 0xffff;
      short first = Convert.ToInt16(Console.ReadLine());
      short second = Convert.ToInt16(Console.ReadLine());
      short third = Convert.ToInt16(Console.ReadLine());
      short fourth = Convert.ToInt16(Console.ReadLine());

      long result = (llll & fourth);
      result = result << 16;

      result = result | (llll & third);
      result = result << 16;

      result = result | (llll & second);
      result = result << 16;

      result = result | (llll & first);
      Console.WriteLine(result);
      //printlongBinary(result);
    }

    static void task2n4()
    { // 2.4
      long n = Convert.ToInt64(Console.ReadLine());
      short tmp = (short)n;
      Console.Write(tmp + " ");
      //printlongBinary(n);

      n = n >> 16;
      tmp = (short)n;
      Console.Write(tmp + " ");
      //printlongBinary(n);

      n = n >> 16;
      tmp = (short)n;
      Console.Write(tmp + " ");
     //printlongBinary(n);

      n = n >> 16;
      tmp = (short)n;
      Console.WriteLine(tmp + " ");
      //printlongBinary(n);
    }

    static void task2n5()
    {//2.5
      long n = Convert.ToInt64(Console.ReadLine());
      int m = Convert.ToInt32(Console.ReadLine());
      int k = Convert.ToInt32(Console.ReadLine());

      if (m == k)
      {
        Console.WriteLine(n);
        return;
      }

      const short llll = 0x00ff; // 11111111
      const int byt = 8; // kolichestvo simvolov v byte

      if (m > k)
      {
        int q = k;
        k = m;
        m = q;
      }

      long before = n >> (byt * k);
      before = before << (byt * k);

      byte swap1 = (byte)(n >> (byt * (k - 1)));

      long between = n << (byt * (byt - k + 1));
      between = between >> (byt * (m + byt - k + 1));
      between = between << (byt * (m));

      byte swap2 = (byte)(n >> (byt * (m - 1)));

      long after = n << (byt * (byt - m + 1));
      after = after >> (byt * (byt - m + 1));


      long result = (long)(swap1) << (byt * (m - 1));

      result = result | ((long)(swap2) << (byt * (k - 1)));

      if (k != 8)
        result = result | before;

      if (m != 1)
        result = result | after;

      if (k - m != 1)
        result = result | between;
      //printlongBinary(result);

      Console.WriteLine(result);
    }

    static void task3n1()
    {
      // input n, p
      int n = 0;
      do n = Convert.ToInt32(Console.ReadLine());
      while (n <= 0);
      int p = 0;
      do p = Convert.ToInt32(Console.ReadLine());
      while (p < 1);
      double sum = 0d;

      for (int i = 0; i < n; ++i)
      {
        double tmp = Convert.ToDouble(Console.ReadLine());
        sum += Math.Pow(tmp, p);
      }
      Console.WriteLine(Math.Pow(sum, (double) 1 / p));
    }


    static void swap(ref double a, ref double b)
    {
      double tmp = a;
      a = b;
      b = tmp;
    }
    static void task3n2()
    {
      // input n
      int n = 0;
      do n = Convert.ToInt32(Console.ReadLine());
      while (n <= 0);

      // Не указано, какого типа данных являются элементы массива, беру вещественные
      double[] array = new double[n];

      for (int i = 0; i < n; i++)
      {
        array[i] = Convert.ToDouble(Console.ReadLine());
      }
      
      // input k
      int k = 0;
      do k = Convert.ToInt32(Console.ReadLine());
      while (k <= 0 || k > n);
        
        // сортирока вставками
        for (int i = 1; i < n; ++i)
        {
          for (int j = i; j > 0 && array[j - 1] > array[j]; --j)
          {
            swap(ref array[j - 1], ref array[j]);
          }
        }
        
        /*
        foreach(double value in array) Console.Write(value + " ");
        Console.WriteLine();
        */

        Console.WriteLine(array[k - 1]);
    }

    static void task3n3()
    {
      int n = Convert.ToInt32(Console.ReadLine());

      double[] array = new double[n];
      for (int i = 0; i < n; i++)
      {
        array[i] = Convert.ToDouble(Console.ReadLine());
      }

      // Вычисляем ":" в строке
      string str = Console.ReadLine();
      int pos1 = 0, pos2 = 0;

      for (int i = 0; i < str.Length; i++)
      {
        if (str[i] == ':')
        {
          if (pos1 != 0)
          {
            pos2 = i;
            break;
          }
          else
          {
            pos1 = i;
          }
        }
      }
      
      // Обозначаем чиcла
      int from = Convert.ToInt32(str.Substring(0, pos1)), 
        to = Convert.ToInt32(str.Substring(pos1 + 1, pos2 - pos1 - 1)), 
        step = Convert.ToInt32(str.Substring(pos2 + 1));
      //Console.WriteLine($"{from}:{to}:{step}");
      
      bool step_is_negative = (step < 0);
      if ((step == 0) || (from < 0 || from > to) || (to < 0 || to >= n))
      {
        Console.WriteLine("Incorrect input");
        return;
      }
      else if (step_is_negative)
      {
        from = n - 1 - from;
        to = n - to - 1;
      }
      // Считает размер нового массива. т.к. количество элементов = [конец - начало + 1],
      // вычисляем это с учетом знака
      int new_array_size = ((to - from + (step_is_negative ? -1 : 1)) / step) +
                           (((to % step) == (from % step)) ? 1 : 0); 
      // если остаток от деления первого и последнего элементов совпадают, массив будет на 1 элемент больше
      
      double[] new_array = new double[new_array_size];
      for (int i = from, j = 0; 
           ( (step_is_negative) ? i >= to : i <= to ); 
           i += step, j++)
      {
        new_array[j] = array[i];
        Console.Write(new_array[j] + " ");
      }
      Console.WriteLine();
    }

    static void Main(string[] args)
    {
      task1n1();
      task1n2();
      task2n1();
      task2n2();
      task2n3();
      task2n4();
      task2n5();
      task3n2();
      task3n3();
      

      Console.ReadKey();
    }
  }
}
﻿using System;
using System.Diagnostics;
using JoshuaaM.PrimeSieve;

namespace PrimeSieveExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "PrimeSieve";
            Stopwatch sw = new Stopwatch();
            int countOfPrimesToSearchForMax = int.MaxValue;

            
            Console.WriteLine("Searching for primes below: {0}", countOfPrimesToSearchForMax);
            Console.WriteLine("Starting to search for primes without multithreading");
            sw.Start();
            int[] primes = PrimeSieve.GeneratePrimesToMax(countOfPrimesToSearchForMax, false);
            sw.Stop();
            Console.WriteLine("Completed without multithreading");
            Console.WriteLine("Time: {0}", sw.Elapsed);
            Console.WriteLine("Primes found: {0}", primes.Length);

            sw.Reset();
            

            Console.WriteLine("Starting to search for primes with multithreading");
            sw.Start();
            primes = PrimeSieve.GeneratePrimesToMax(countOfPrimesToSearchForMax, true);
            sw.Stop();
            Console.WriteLine("Completed with multithreading");
            Console.WriteLine("Time: {0}", sw.Elapsed);
            Console.WriteLine("Primes found: {0}", primes.Length);

            PrimeSieve.SavePrimesToCompressedFile(primes, "primes.zipdat");
            //primes = PrimeSieve.LoadPrimesFromCompressedFile("primes.zipdat");

            Console.ReadLine();
        }
    }
}

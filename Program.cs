using System;
using System.Diagnostics.Contracts;

namespace FirstCut
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 3, 2, 1 };

            var index = FirstCutContract(a, b);
            Console.WriteLine("Index: " + index + "\nValue: " + a[index]);
            Console.ReadLine();
        }

        private static int FirstCutContract(int[] a, int[] b)
        {
            // Contract requires a to be larger than 0
            Contract.Requires(a.Length > 0);
            // Contract requires b to be the same length as a, thus not 0
            Contract.Requires(a.Length == b.Length);
            // Contract requires an element to exists with the same value at the same index in both arrays
            Contract.Requires(Contract.Exists(0, b.Length, j => b[j] == a[j]));

            // Contract ensures that for both arrays, the elements at the same index are both integers
            Contract.Ensures(Contract.Exists(0, b.Length, j => b[Contract.Result<int>()] == a[Contract.Result<int>()]));
            // Contract ensures that for all indexes up until the first cut, none of them are the same value
            Contract.Ensures(Contract.ForAll(0, Contract.Result<int>(), j => b[j] != a[j]));

            int i = 0;
            // While we haven't exhausted a and the value at i in both arrays aren't equal
            while (i < a.Length - 1 && a[i] != b[i])
            {
                i++;
            }

            return i;
        }
    }
}

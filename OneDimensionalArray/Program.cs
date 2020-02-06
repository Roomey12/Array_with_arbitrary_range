using System;
using System.Collections;

namespace OneDimensionalArray
{
    public class OneDimArray<T> : IEnumerable
    {
        int indexStart { get; set; }
        int indexEnd { get; set; }
        private int indexMain = 0;
        private T[] arr;

        public OneDimArray(int indS, int indE)
        {
            if(indE <= indS)
            {
                throw new SizeException("Array's size must be > 0");
            }
            else
            {
                indexStart = indS;
                indexEnd = indE;
                arr = new T[indE - indS];
            }
        }
        public T this[int index]
        {
            get
            {
                if (index < this.indexEnd && index >= this.indexStart)
                {
                    return arr[index - indexStart];
                }
                else
                {
                   throw new IndexException($"Index: {indexMain + indexStart} is out of range.");
                }
            }
            set
            {
                if (index < this.indexEnd && index >= this.indexStart)
                {
                    arr[index - indexStart] = value;
                }
                else
                {
                    throw new IndexException($"Index: {indexMain + indexStart} is out of range.");
                }
                indexMain++;
            }
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new SizeException("Array is null");
            if (array.Length - arrayIndex < Count())
                throw new IndexException("Elements of the original array will not fit in this array.");
            for(int i = 0; i < array.Length - arrayIndex; i++)
            {
                array[i + arrayIndex] = this[i + indexStart];
            }
        }
        public void Print()
        {
            int i = indexStart;
            Console.WriteLine();
            foreach (var e in this.arr)
            {
                if (e != null)
                {
                    Console.WriteLine($"Index: {i++}; Element: {e}");
                }
            }
            Console.WriteLine();
        }
        public int Count() { return indexMain; }
        public int Length() { return arr.Length; }
        public void Clear() { Array.Clear(arr, 0, arr.Length); indexMain = 0; }
        public IEnumerator GetEnumerator()
        {
            return arr.GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******** STRING ARRAY ********\n");
            var arrayString = new OneDimArray<string>(-15, -10);
            arrayString[-15] = "-15";
            arrayString[-14] = "-14";
            arrayString[-13] = "-13";
            arrayString[-12] = "-12";
            arrayString[-11] = "-11";

            foreach(var e in arrayString)
            {
                Console.WriteLine(e);
            }

            string[] arr = new string[6];
            arrayString.CopyTo(arr, 1);
            int i = 0;
            foreach(var e in arr)
            {
                Console.WriteLine($"arr[{i++}]: {e}");
            }

            //Console.WriteLine($"-12-th element: {arrayString[-12]}");
            //Console.WriteLine($"\nLength: {arrayString.Length()};  Number of Elements: {arrayString.Count()}");
            //arrayString.Print();
            //arrayString.Clear();
            //arrayString[-15] = "-150";
            //arrayString[-14] = "-140";
            //arrayString[-13] = "-130";

            //Console.WriteLine($"-13-th element: {arrayString[-13]}");

            //Console.WriteLine($"\nLength: {arrayString.Length()};  Number of Elements: {arrayString.Count()}");
            //arrayString.Print();

            //Console.WriteLine("\n******** INT ARRAY ********\n");
            //var arrayInt = new OneDimArray<int>(11, 13);
            //arrayInt[11] = 6;
            //arrayInt[12] = 3;

            //Console.WriteLine($"Length: {arrayInt.Length()};  Number of Elements: {arrayInt.Count()}");
            //arrayInt.Print();
            //Console.WriteLine($"11-th element: {arrayInt[11]}");
            //Console.ReadLine();
        }
    }
}

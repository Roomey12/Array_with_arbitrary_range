using System;
using Xunit;
using OneDimensionalArray;

namespace OneDimensionalArray.Tests
{
    public class OneDimensionalArrayTest
    {
        [Fact]
        public void GetWithIndexer_AppealArrMinus1_10Return()
        {
            // arrange
            int expected = 10;
            OneDimArray<int> arrInt = new OneDimArray<int>(-2, 2);
            arrInt[-2] = 1;
            arrInt[-1] = 10;
            arrInt[0] = 3;

            // act
            int actual = arrInt[-1];

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CopyTo_OneDimArrayTypeStringToStringArrayAndCompareElements()
        {
            //arrange
            string expected = "-8";
            OneDimArray<string> arrayString = new OneDimArray<string>(-10, 5);
            arrayString[-10] = "-10";
            arrayString[-9] = "-9";
            arrayString[-8] = "-8";
            arrayString[-7] = "-7";
            arrayString[-6] = "-6";

            //act
            string[] arr = new string[5];
            arrayString.CopyTo(arr, 0);
            string actual = arr[2];

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Count_ArrayWith5SizeAnd4ElementsGiven_4Return()
        {
            //arrange
            int expected = 4;
            OneDimArray<string> arrayString = new OneDimArray<string>(-10, -5);
            arrayString[-10] = "-10";
            arrayString[-9] = "-9";
            arrayString[-8] = "-8";
            arrayString[-7] = "-7";

            //act
            int actual = arrayString.Count();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Length_ArrayWith5SizeAnd4ElementsGiven_5Return()
        {
            //arrange
            int expected = 5;
            OneDimArray<string> arrayString = new OneDimArray<string>(-10, -5);
            arrayString[-10] = "-10";
            arrayString[-9] = "-9";
            arrayString[-8] = "-8";
            arrayString[-7] = "-7";

            //act
            int actual = arrayString.Length();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Clear_ArrayWith5SizeAnd4ElementsGiven_555Return()
        {
            //arrange
            string expected = "555";
            OneDimArray<string> arrayString = new OneDimArray<string>(-10, -5);
            arrayString[-10] = "-10";
            arrayString[-9] = "-9";
            arrayString[-8] = "-8";
            arrayString[-7] = "-7";
            arrayString.Clear();
            arrayString[-10] = "400";
            arrayString[-9] = "555";

            //act
            string actual = arrayString[-9];

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SizeException_ArrayWithNegativeSizeGiven_SizeExceptionReturn()
        {
            try
            {
                OneDimArray<string> arrayString = new OneDimArray<string>(5, -5);
            }
            catch(SizeException exception)
            {
                Assert.Equal("Array's size must be > 0", exception.Message);
            }
        }

        [Fact]
        public void IndexException_ArrayWithSize5TryToSetGiven_IndexExceptionReturn()
        {
            OneDimArray<string> arrayString = new OneDimArray<string>(-10, -5);
            Assert.Throws<IndexException>(() => { arrayString[-100] = "-10"; });
        }

        [Fact]
        public void IndexException_ArrayWithSize5TryToGetGiven_IndexExceptionReturn()
        {
            OneDimArray<string> arrayString = new OneDimArray<string>(-10, -5);
            arrayString[-10] = "-10";
            string actual;
            Assert.Throws<IndexException>(() => { actual = arrayString[500]; });
        }
    }
}

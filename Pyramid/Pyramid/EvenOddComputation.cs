namespace Pyramid
{
    static class EvenOddComputation
    {
        public static void EvenComputation(int rowVal, int value1, int value2, int i, int j, ref int[,] tri)
        {
            if (rowVal % 2 == 0)
                tri[i, j] = value1 + value2;
        }

        public static void OddComputation(int rowVal, int value1, int value2, int i, int j, ref int[,] tri)
        {
            if (rowVal % 2 != 0)
                tri[i, j] = value1 + value2;
        }
    }
}

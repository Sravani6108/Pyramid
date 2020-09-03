using System;


namespace Pyramid
{
    public class TraingleTraversal
    {
        public void MaximumEvenOddSum(int[,] tri,
                      int n)
        {

            int[,] triSum = new int[15,15];
            // Adding the element of row 1  
            // to both the elements of row 2  
            // to reduce a step from the loop 

            if (tri[0, 0] % 2 == 0)
            {
                EvenOddComputation.OddComputation(tri[1, 1], tri[1, 1], tri[0, 0], 1, 1, ref triSum);
                EvenOddComputation.OddComputation(tri[1, 0], tri[1, 0], tri[0, 0], 1, 0, ref triSum);
            }
            else
            {
                EvenOddComputation.EvenComputation(tri[1, 1], tri[1, 1], tri[0, 0], 1, 1, ref triSum);
                EvenOddComputation.EvenComputation(tri[1, 0], tri[1, 0], tri[0, 0], 1, 0, ref triSum);
            }


            // Traverse remaining rows 
            for (int i = 2; i < n; i++)
            {
                if (tri[i - 1, 0] % 2 == 0)
                    EvenOddComputation.OddComputation(tri[i, 0], tri[i, 0], triSum[i - 1, 0], i, 0, ref triSum);
                if (tri[i - 1, i - 1] % 2 == 0)
                    EvenOddComputation.OddComputation(tri[i, i], tri[i, i], triSum[i - 1, i - 1], i, i, ref triSum);
                if (tri[i - 1, 0] % 2 != 0)
                    EvenOddComputation.EvenComputation(tri[i, 0], tri[i, 0], triSum[i - 1, 0], i, 0, ref triSum);
                if (tri[i - 1, i - 1] % 2 != 0)
                    EvenOddComputation.EvenComputation(tri[i, i], tri[i, i], triSum[i - 1, i - 1], i, i, ref triSum);

                //Loop to traverse columns 
                for (int j = 1; j < i; j++)
                {

                    // Checking the two conditions,  
                    // directly below and below right. 
                    // Considering the greater one 

                    // tri[i] would store the possible  
                    // combinations of sum of the paths 
                    if (tri[i, j] % 2 == 0)
                    {
                        if ((tri[i - 1, j - 1] % 2 != 0) && (tri[i - 1, j] % 2 != 0))
                        {
                            if (tri[i, j] + triSum[i - 1, j - 1] >=
                                         tri[i, j] + triSum[i - 1, j])

                                triSum[i, j] = tri[i, j] +
                                            triSum[i - 1, j - 1];

                            else
                                triSum[i, j] = tri[i, j] +
                                            triSum[i - 1, j];
                        }

                        else
                        {
                            EvenOddComputation.OddComputation(tri[i - 1, j - 1], tri[i, j], triSum[i - 1, j - 1], i, j, ref triSum);
                            EvenOddComputation.OddComputation(tri[i - 1, j], tri[i, j], triSum[i - 1, j], i, j, ref triSum);
                        }
                    }

                    else
                    {

                        if ((tri[i - 1, j - 1] % 2 == 0) && (tri[i - 1, j] % 2 == 0))
                        {
                            if (tri[i, j] + triSum[i - 1, j - 1] >=
                                         tri[i, j] + triSum[i - 1, j])

                                triSum[i, j] = tri[i, j] +
                                            triSum[i - 1, j - 1];

                            else
                                triSum[i, j] = tri[i, j] +
                                            triSum[i - 1, j];
                        }

                        else
                        {
                            EvenOddComputation.EvenComputation(tri[i - 1, j - 1], tri[i, j], triSum[i - 1, j - 1], i, j, ref triSum);
                            EvenOddComputation.EvenComputation(tri[i - 1, j], tri[i, j], triSum[i - 1, j], i, j, ref triSum);
                        }

                    }
                }
            }

            // array at n-1 index (tri[i])  
            // stores all possible adding  
            // combination, finding the  
            // maximum one out of them 

            Console.WriteLine(MaxComputation(triSum, 15));
            Console.Read();
        }

        private int MaxComputation(int[,] tri, int n)
        {
            int max = tri[n - 1, 0];

            for (int i = 1; i < n; i++)
            {
                if (max < tri[n - 1, i])
                    max = tri[n - 1, i];
            }

            return max;
        }
    }
}

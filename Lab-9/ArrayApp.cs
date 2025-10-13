using System;

public class ArrayManipulator
{
    // Method to perform bubble sort on an array
    public void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j+1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Method to perform matrix multiplication
    public int[,] MultiplyMatrices(int[,] A, int[,] B)
    {
        int rA = A.GetLength(0);
        int cA = A.GetLength(1);
        int rB = B.GetLength(0);
        int cB = B.GetLength(1);

        if (cA != rB)
        {
            Console.WriteLine("Matrices cannot be multiplied!");
            return null;
        }

        int[,] C = new int[rA, cB];
        for (int i = 0; i < rA; i++)
        {
            for (int j = 0; j < cB; j++)
            {
                C[i, j] = 0;
                for (int k = 0; k < cA; k++)
                {
                    C[i, j] += A[i, k] * B[k, j];
                }
            }
        }
        return C;
    }
}

public class ArrayApp
{
    // Helper function to print a 1D array
    public static void PrintArray(int[] arr, string title)
    {
        Console.WriteLine(title);
        Console.WriteLine(string.Join(", ", arr));
        Console.WriteLine();
    }

    // Helper function to print a 2D array (matrix)
    public static void PrintMatrix(int[,] matrix, string title)
    {
        Console.WriteLine(title);
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
    public static void Main(string[] args)
    {
        ArrayManipulator manipulator = new ArrayManipulator();

        // --- 1. Bubble Sort ---
        int[] arrayToSort = { 64, 34, 25, 12, 22, 11, 90 };
        PrintArray(arrayToSort, "Original Array for Bubble Sort:");
        manipulator.BubbleSort(arrayToSort);
        PrintArray(arrayToSort, "Sorted Array:");

        // --- 2. 2D to 1D Array Conversion ---
        int[,] twoDArray = { { 1, 2, 3 }, { 4, 5, 6 } };
        int rows = twoDArray.GetLength(0);
        int cols = twoDArray.GetLength(1);
        int[] rowMajor = new int[rows * cols];
        int[] colMajor = new int[rows * cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                rowMajor[i * cols + j] = twoDArray[i, j]; 
                colMajor[j * rows + i] = twoDArray[i, j]; 
            }
        }
        PrintMatrix(twoDArray, "Original 2D Array:");
        PrintArray(rowMajor, "1D Array (Row-Major Order):");
        PrintArray(colMajor, "1D Array (Column-Major Order):");

        // --- 3. Matrix Multiplication ---
        int[,] matrixA = { { 1, 2, 3 }, { 4, 5, 6 } };
        int[,] matrixB = { { 7, 8 }, { 9, 10 }, { 11, 12 } };
        
        PrintMatrix(matrixA, "Matrix A:");
        PrintMatrix(matrixB, "Matrix B:");
        
        int[,] resultMatrix = manipulator.MultiplyMatrices(matrixA, matrixB);
        if (resultMatrix != null)
        {
            PrintMatrix(resultMatrix, "Resultant Matrix C (A * B):");
        }
    }
}
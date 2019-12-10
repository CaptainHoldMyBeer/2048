using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2048
{
	public static class MatrixOperations
	{
		public static void SwipeRight(Matrix matrix)
		{
			for (int i = 0; i < matrix.Size; i++)
			{
				SwipeRightArray(matrix[i]);
			}
		}
		public static void SwipeLeft(Matrix matrix)
		{
			for (int i = 0; i < matrix.Size; i++)
			{
				Array.Reverse(matrix[i]);
				SwipeRightArray(matrix[i]);
				Array.Reverse(matrix[i]);
			}
		}

		public static void SwipeDown(Matrix matrix)
		{
			Transpose(matrix);
			SwipeRight(matrix);
			Transpose(matrix);
		}

		public static void SwipeUp(Matrix matrix)
		{
			Transpose(matrix);
			SwipeLeft(matrix);
			Transpose(matrix);
		}


		private static void ShiftRightArray(int[] array)
		{
			if (array.All(x => x != 0))
			{

			}
			else
			{
				for (int i = 0; i < array.Length; i++)
				{
					for (int j = 2; j >= 0; j--)
					{
						if (array[j + 1] == 0)
						{
							array[j + 1] = array[j];
							array[j] = 0;
						}
					}
				}
			}
		}

		private static void SwipeRightArray(int[] array)
		{
			if (array.All(x => x != 0))
			{
				for (int k = 0; k < 2; k++)
				{
					for (int i = 3; i > 0; i--)
					{
						if (array[i] == array[i - 1])
						{
							array[i] += array[i - 1];
							array[i - 1] = 0;
						}

						if (array[i] != array[i - 1] && array[i] == 0)
						{
							array[i] = array[i - 1];
							array[i - 1] = 0;
						}
					}
				}
			}

			else
			{
				ShiftRightArray(array);
				for (int i = 3; i > 0; i--)
				{
					if (array[i] == array[i - 1])
					{
						array[i] += array[i - 1];
						array[i - 1] = 0;
					}

					if (array[i] != array[i - 1] && array[i] == 0)
					{
						array[i] = array[i - 1];
						array[i - 1] = 0;
					}
				}
			}
		}

		private static void Transpose(Matrix matrix)
		{
			int tmp = 0;
			for (int i = 0; i < matrix.Size; i++)
			{
				for (int j = 0; j < i; j++)
				{
					tmp = matrix[i, j];
					matrix[i, j] = matrix[j, i];
					matrix[j, i] = tmp;
				}
			}
		}

	}
}

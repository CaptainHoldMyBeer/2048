using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary2048
{
	public class Game
	{
		private static Random _randomizer = new Random();
		
		public static void Start()
		{
			var matrixToPlay = new Matrix(4);
			PasteOnEmptySpace(matrixToPlay);
			Console.Write(matrixToPlay.ToString());
			while (true || GameIsOver(matrixToPlay))
			{
				var key = Console.ReadKey(true);
				if (key.Key == ConsoleKey.RightArrow)
				{
					MatrixOperations.SwipeRight(matrixToPlay);
				}
				if (key.Key == ConsoleKey.LeftArrow)
				{
					MatrixOperations.SwipeLeft(matrixToPlay);
				}
				if (key.Key == ConsoleKey.UpArrow)
				{
					MatrixOperations.SwipeUp(matrixToPlay);
				}
				if (key.Key == ConsoleKey.DownArrow)
				{
					MatrixOperations.SwipeDown(matrixToPlay);
				}
				Console.Clear();
				PasteOnEmptySpace(matrixToPlay);
				Console.Write(matrixToPlay.ToString());
			}
		}

		private static (int, int)[] GetEmptyIndexes(Matrix matrix)
		{
			var listOfNulles = new List<(int,int)>();

			for (int i = 0; i < matrix.Size; i++)
			{
				for (int j = 0; j < matrix.Size; j++)
				{
					if(matrix[i,j]==0)
						listOfNulles.Add((i,j));
				}
			}

			return listOfNulles.ToArray();
		}

		private static (int, int) GetIndexToInput(Matrix matrix)
		{
			return GetEmptyIndexes(matrix)[_randomizer.Next(GetEmptyIndexes(matrix).Length)];
		}

		private static void PasteOnEmptySpace(Matrix matrix)
		{
			var indexes = GetIndexToInput(matrix);

			if (_randomizer.NextDouble() <= 0.9)
			{
				matrix[indexes.Item1, indexes.Item2] = 2;
			}
			else
			{
				matrix[indexes.Item1, indexes.Item2] = 4;
			}
		}

		private static bool GameIsOver(Matrix matrix)
		{
			if (GetEmptyIndexes(matrix).Length == 0)
			{
				return true;
			}

			return false;
		}
	}
}

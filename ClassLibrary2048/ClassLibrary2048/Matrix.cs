
namespace ClassLibrary2048
{
	public class Matrix
	{
		private int[][] _matrix;

		public int Size => _matrix[0].Length;

		public Matrix()
		{

		}
		public Matrix(int size)
		{
			_matrix = new int[size][];
			_matrix[0] = new int[size];
			_matrix[1] = new int[size];
			_matrix[2] = new int[size];
			_matrix[3] = new int[size];
		}

		public int this[int i, int j]
		{
			get { return _matrix[i][j]; }
			set { _matrix[i][j] = value; }
		}
		public int[] this[int i]
		{
			get { return _matrix[i]; }
			set { _matrix[i] = value; }
		}

		public override string ToString()
		{
			string MatrixView = "";
			for (int i = 0; i < this.Size; i++)
			{
				for (int j = 0; j < this.Size; j++)
				{
					MatrixView += this[i][j] + "   ";
				}

				MatrixView += "\n";
			}

			return MatrixView;
		}
	}
}

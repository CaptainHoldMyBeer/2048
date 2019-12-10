using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2048;


namespace _2048GameV1
{
	class Program
	{
		static void Main(string[] args)
		{
			Game obj = new Game();

			Game.Start();

			Console.ReadKey();
		}
	}
}

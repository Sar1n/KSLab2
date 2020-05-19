using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	class Program
	{
		static uint multiplicand = 11;
		static uint multiplier = 5;
		static uint regl;
		static uint regr;
		static uint product;
		static uint popupbit;
		static void Main(string[] args)
		{
			regl = 0;
			regr = multiplier;
			SetProduct();
			Console.WriteLine(multiplicand.ToString() + " * " + multiplier.ToString() + " =");
			Console.WriteLine(Convert.ToString(multiplicand, 2) + " * " + Convert.ToString(multiplier, 2) + " =" + "\n");
			Console.WriteLine(ProductString() + "	Initial Product");
			Console.WriteLine();
			for (int i = 0; i < 4; i++)
			{
				Console.WriteLine("---------------------------" + "Iteration " + (i + 1).ToString());
				popupbit = product % 2;
				product = product >> 1;
				Console.WriteLine(ProductString() + "	Right shift, " + popupbit.ToString() + " shifted");
				if (popupbit == 1)
				{
					Console.WriteLine(" " + Convert.ToString(multiplicand, 2) + "		Adding multiplicator");
					product += multiplicand << 3;
				}
				Console.WriteLine(ProductString() + "	Product");
			}
			Console.WriteLine("\n" + ProductString() + "	Result");
			Console.WriteLine(product.ToString() + "	Result");
			Console.ReadKey();
		}
		static string ProductString()
		{
			int l = Convert.ToString(product, 2).Length;
			string res = "";
			for (int i = 0; i < 8 - l; i++)
			{
				res += "0";
			}
			res += Convert.ToString(product, 2);
			return res;
		}
		static void SetProduct()
		{
			product = regl << 4;
			product += regr;
		}
	}
}

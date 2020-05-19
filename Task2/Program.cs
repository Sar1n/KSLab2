using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
	class Program
	{
		static int devidend = 7;
		static int divisor = 2;
		static int quotient = 0;
		static int reminder;
		static void Main(string[] args)
		{
			Console.WriteLine(devidend.ToString() + " / " + divisor.ToString() + " =");
			Console.WriteLine(Convert.ToString(devidend, 2) + " / " + Convert.ToString(divisor, 2) + " =");
			reminder = devidend;
			divisor <<= 4;
			Console.WriteLine("Initial values");
			Console.WriteLine("Quotient	Divisor		Remainder");
			Console.WriteLine(Zero(quotient, 4) + "		" + Zero(divisor, 8) + "	" + Zero(reminder, 8));
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("-------------------------------------------------" + "Iteration " + (i + 1).ToString());
				reminder -= divisor;
				if (reminder < 0)
				{
					Console.WriteLine(ToAdditionalCode(reminder) + "	Reminder = Reminder – Divider (Reminder < 0)");
					reminder += divisor;
					quotient <<= 1;
					Console.WriteLine(Zero(quotient, 4) + "		Quotient");
				}
				else
				{
					Console.WriteLine(Zero(reminder, 8) + "	Reminder = Reminder – Divider (Reminder >= 0)");
					if (quotient < 15)
					{
						quotient <<= 1;
						quotient += 1;
					}
					Console.WriteLine(Zero(quotient, 4) + "		Quotient");
				}
				divisor >>= 1;
				Console.WriteLine(Zero(divisor, 8) + "	Divisor");
			}
			Console.WriteLine("\n" + "Result: Quotient=" +  Zero(quotient, 4) + " Reminder=" + Zero(reminder, 8));
			Console.WriteLine("Result: Quotient=" + quotient.ToString() + " Reminder=" + reminder.ToString());
			Console.ReadKey();
		}
		static string Zero(int a, int c)
		{
			int l = Convert.ToString(a, 2).Length;
			string res = "";
			for (int i = 0; i < c - l; i++)
			{
				res += "0";
			}
			res += Convert.ToString(a, 2);
			return res;
		}
		static string ToAdditionalCode(int a)
		{
			a *= -1;
			string res = Zero(a, 8);
			string res2 = "";
			for (int i = 0; i < res.Length; i++)
			{
				if (res[i] == '0')
					res2 += '1';
				else
					res2 += '0';
			}
			a = Convert.ToInt32(res2, 2);
			a += 1;
			return Convert.ToString(a, 2);
		}
	}
}

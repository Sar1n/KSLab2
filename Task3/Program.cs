using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
	class Program
	{
		static float multiplicand = 125.125F;
		static float multiplier = 12.0625F;
		static void Main(string[] args)
		{
			StringBuilder builder = new StringBuilder();
			Byte[] multiplicandBytes = BitConverter.GetBytes(multiplicand);
			foreach (byte b in multiplicandBytes)
				for (int i = 0; i < 8; i++)
				{
					builder.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
				}
			string s = builder.ToString();
			string S1 = s.Substring(0, 1);
			string E1 = s.Substring(1, 8);
			string M1 = s.Substring(9);
			Console.WriteLine("S1=" + S1 + " E1=" + E1 + " M1=" + M1);

			builder.Clear();

			Byte[] multiplierBytes = BitConverter.GetBytes(multiplier);
			foreach (byte b in multiplierBytes)
				for (int i = 0; i < 8; i++)
				{
					builder.Insert(0, ((b >> i) & 1) == 1 ? "1" : "0");
				}
			string ss = builder.ToString();
			string S2 = ss.Substring(0, 1);
			string E2 = ss.Substring(1, 8);
			string M2 = ss.Substring(9);
			Console.WriteLine("S2=" + S2 + " E2=" + E2 + " M2=" + M2);
			
			Console.WriteLine("\n" + "Calculating Sign");
			bool sign1 = false, sign2 = false; 
			if (S1 == "0")
				sign1 = false;
			else
				sign1 = true;
			if (S2 == "0")
				sign2 = false;
			else
				sign2 = true;
			bool S3 = sign1 ^ sign2;
			if (S3)
				Console.WriteLine("S3 = 1");
			else
				Console.WriteLine("S3 = 0");

			Console.WriteLine("\n" + "Calculating Mantiss");
			M1 = "1" + M1;
			M2 = "1" + M2;
			long M1l = Convert.ToInt64(M1, 2);
			long M2l = Convert.ToInt64(M2, 2);
			var M3 = M1l * M2l;
			Console.WriteLine($"M3= M1*M2 = {Convert.ToString(M3, 2)}");
			short addtoe = 0;
			string M3s;
			if (Convert.ToString(M3, 2).Length == 48)
			{
				M3s = Convert.ToString(M3, 2).Substring(1, 23);
				addtoe = 1;
				Console.WriteLine($"M3(48) = 1, adding 1 to the exponent");
				Console.WriteLine($"M3 = {M3s}");
			}
			else
			{
				M3s = Convert.ToString(M3, 2).Substring(1, 23);
				Console.WriteLine($"M3(48) = 0, adding 0 to the exponent");
				Console.WriteLine($"M3 - {M3s}");
			}

			Console.WriteLine("\n" + "Calculating Exponent");
			long E3 = Convert.ToInt64(E1, 2) + Convert.ToInt64(E2, 2) - 127 + addtoe;
			string E3s = FillZero(Convert.ToString(E3, 2), 8);
			Console.WriteLine($"E3 = {E3s}");

			string sres;
			if (S3)
				sres = "1";
			else
				sres = "0";
			sres += E3s;
			sres += M3s;
			Console.WriteLine("\n" + $"Result = {sres}");

			Console.WriteLine("S3=" + sres[0] + " E3=" + E3s + " M3=" + M3s);

			Console.ReadKey();
		}
		static string FillZero(string s, int b)
		{
			int l = s.Length;
			string res = s;
			for (int i = 0; i < b - l; i++)
			{
				res += "0";
			}
			return res;
		}
	}
}

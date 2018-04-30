using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SqrtTable
{
	class Program
	{
		static string makPathe(string name)
		{
			string ret;
			string ret2;
			ret = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop));

			ret2 = Path.Combine(ret, name);
			return ret2;
		}

		static void Write(string thing, FileStream handle = null)
		{
			if (handle != null)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(thing);

				handle.Write(bytes, 0, bytes.Length);
			}
			else
			{
				Console.Write(thing);
			}
		}

		static void Output(string output, int desired_length, string term,FileStream handle=null)
		{
			Write(output, handle);
			if (output.Length < desired_length)
			{
				for (int count = 1; count <= (desired_length - output.Length); count++)
					Write(" ", handle);
			}
			Write(term, handle);
		}
		static void Main(string[] args)
		{
			FileStream handle;
			int cap;
			if (args.Length >= 1)
			{
				if (args[0] == "/?")
				{
					Console.WriteLine("SqrtTable.exe [Name of file to place on logged in user's desktop.txt] /C [CAP]");
					return;
				}
				else
				{
					handle = new FileStream(makPathe(args[0]), System.IO.FileMode.Create);

					for (int step = 2; step < args.Length; step++)
					{
						if ((step == 2) && (args[step] == "/C"))
						{
							if (step + 1 < args.Length)
							{
								bool ok = false;
								try
								{
									cap = int.Parse(args[step + 1]);
									ok = true;
								}
								finally
								{
									if (ok != true)
									{
										cap = 1000;
									}
								}
							}
						}
					}
				}
			}
			else
			{
				handle = null; // oututs to cnosole.
			}
			string p1, p2, p3;
			for (int step =1; step <= 1000;step++)
			{
				p1 = string.Format("N={0}", step);
				p2 = string.Format("N^2={0}", step * step);
				p3 = string.Format("sqrt(N)={0:0.000}", Math.Round(Math.Sqrt(step), 3));

				Output(p1, 5, ", ", handle);
				Output(p2, 6, ", ", handle);
				Output(p3, 8, ", ", handle);
				

				if (step % 3 == 0)
				{
					Write("\r\n", handle);;
				}
				else
				{
					Write("-- ", handle);
				}

			}
			return;
		}
	}
}

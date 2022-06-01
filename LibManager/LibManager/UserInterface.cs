using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace LibManager
{
	//Testing Git
    public class UserInterface
    {
		public static int GetOption(string title, params object[] options)
		{
			if (options.Length == 0)
			{
				return -1;
			}

			int digitsNeeded = (int)(1 + Math.Floor(Math.Log10(options.Length)));

			Console.WriteLine(title);

			for (int i = 0; i < options.Length; i++)
			{
				Console.WriteLine($"{(i + 1).ToString().PadLeft(digitsNeeded) + "."} {options[i]}");
			}

			int option = GetInt($"Please enter a choice between 1 and {options.Length}", 1, options.Length);

			return option - 1;
		}

		public static int GetInt(string prompt, int min, int max)
		{
			if (min > max)
			{
				int t = min;
				min = max;
				max = t;
			}

			while (true)
			{
				int result = GetInt(prompt);

				if (min <= result && result <= max)
				{
					return result;
				}
				else
				{
					Error("Supplied value is out of range");
				}
			}
		}

		public static int GetInt(string prompt)
		{
			while (true)
			{
				string response = GetInput(prompt);

				int result;

				if (int.TryParse(response, out result))
				{
					return result;
				}
				else
				{
					Error("Supplied value is not an integer");
				}
			}
		}

		public static string GetInput(string prompt)
		{
			Console.WriteLine("{0}:", prompt);
			return Console.ReadLine();
		}

		public static string GetPassword(string prompt)
		{
			Console.Write("{0}: ", prompt);
			StringBuilder password = new System.Text.StringBuilder();

			while (true)
			{
				var keyInfo = Console.ReadKey(intercept: true);
				var key = keyInfo.Key;

				if (key == ConsoleKey.Enter)
					break;
				else if (key == ConsoleKey.Backspace)
				{
					if (password.Length > 0)
					{
						Console.Write("\b \b");
						password.Remove(password.Length - 1, 1);
					}
				}
				else
				{
					Console.Write("*");
					password.Append(keyInfo.KeyChar);
				}
			}

			Console.WriteLine();
			return password.ToString();
		}

		public static void Error(string msg)
		{
			Console.WriteLine($"{msg}, please try again");
			Console.WriteLine();
		}

		public static void Message(object msg)
		{
			Console.WriteLine(msg);
			Console.WriteLine();
		}
	}
}

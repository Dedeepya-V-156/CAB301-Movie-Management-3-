using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
namespace LibManager
{
    public class UserInterface
    {

		/// Displays a menu, with the options numbered from 1 to options.Length,
		/// the gets a validated integer in the range 1..options.Length. 
		/// Subtracts 1, then returns the result. If the supplied list of options 
		/// is empty, returns an error value (-1).
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

		/// Gets a validated integer between the designated lower and upper bounds.
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

		/// Gets a validated integer.
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

		/// Gets a single line of text from user.
		public static string GetInput(string prompt)
		{
			Console.WriteLine("{0}:", prompt);
			return Console.ReadLine();
		}

		/// Gets a password from user. The text is processed one
		/// character at a time, and the input is concealed.
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

		/// Displays an error message and asks user to try again.
		public static void Error(string msg)
		{
			Console.WriteLine($"{msg}, please try again");
			Console.WriteLine();
		}
		/// Displays the content of an arbitrary object.
		public static void Message(object msg)
		{
			Console.WriteLine(msg);
			Console.WriteLine();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotApplication
{
	interface IChip
	{
		object chipFunction(int[] input);
	}

	class ChipOfSum : IChip
	{
		public object chipFunction(int[] input)
		{
			int sum = input.ToList().Sum();
			return sum;
		}
	}

	class ChipOfSorts : IChip
	{
		public object chipFunction(int[] input)
		{

			bool check = false;
			char choice;

			do
			{
				Console.WriteLine("\nEnter valid input from below options:");
				Console.WriteLine("\n\tEnter 1 for sorting in ascending order ");
				Console.WriteLine("\n\tEnter 2 for sorting in desecending order");
				choice = Convert.ToChar(Console.ReadLine());
				if ((choice == '1') || (choice == '2'))
				{
					check = true;
				}

			}
			while (!check);


			if (choice == '1')
			{
				Array.Sort(input);
			}
			else if (choice == '2')
			{
				Array.Sort(input);
				Array.Reverse(input);
			}

			return input;
		}
	}
}

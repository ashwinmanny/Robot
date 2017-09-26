using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApplication
{
	class UnitTestProvider
	{
		public static bool TestMethodForChipOfSum()
		{
			bool result = false;
			IChip chip = new ChipOfSorts();

			object validSumResult = 32;

			chip = new ChipOfSum();

			try
			{
				if ((int)validSumResult == (int)chip.chipFunction(new int[] { 10, 8, 9, 5 }))
				{
					result = true;
				}
			}
			catch (Exception e)
			{
				result = false;
			}
			return result;

		}


		public static void RunTestCases()
		{
			if (!(TestMethodForChipOfSum()))
			{
				Console.WriteLine("\nUnit test case for chip of sum failed");
			}
			else
			{
				Console.WriteLine("\nAll unit test cases passed");
			}
		}
	}
}

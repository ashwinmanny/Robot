using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApplication
{
	class Program
	{
		/// <summary>
		/// I am using a client service design of dependency injection (method injection)
		/// Robot is my client and IChip interface is my service
		/// This way the robot does not need to know what's the logic behind a chip and it will accept and execute any chip
		/// I am using interface for Chip so that I can utilizate runtime polymorphism for swapping chips at runtime
		/// Created a seperate class for unit test so that I can add as many static test methods in it as I need
		/// </summary>

		static void Main(string[] args)
		{
			// Service interface
			IChip inputChip;

			// Run test cases
			UnitTestProvider.RunTestCases();

			// hardcoded numerical array input to demo functionalities
			//int[] input = new int[] { 4, 67, 2, 34, 5 };

			int[] input = null;

			// Client class type
			Robot robot = new Robot();

			/****************** Demo Case 1****************************/
			// Running robot's chip execution menthod without installing a chip
			object resultWithoutChip = robot.executeChipLogic(input);

			Type x0 = resultWithoutChip.GetType();

			DisplayResults(resultWithoutChip, x0);

			/****************** Demo Case 2****************************/
			// selecting and installing chip of sorting. 
			inputChip = new ChipOfSorts();
			robot.installChip(inputChip);

			// Result object returned after chip logic execution. Robot does not know what was the logic behind the chip.
			object resultforChipOfSorts = robot.executeChipLogic(input);
 
			Type x1 = resultforChipOfSorts.GetType();

			DisplayResults(resultforChipOfSorts, x1);

			/****************** Demo Case 3****************************/
			// selecting and installing chip of sum
			// Swapping the chip using runtime polymorphism as different Chip can be passed that implement same IChip interface
			inputChip = new ChipOfSum();
			robot.installChip(inputChip);

			object resultforChipOfSum = robot.executeChipLogic(input);

			Type x2 = resultforChipOfSum.GetType();

			DisplayResults(resultforChipOfSum, x2);

			Console.ReadKey();

		}

		public static void DisplayResults(object result, Type type)
		{
			if ((type.BaseType.FullName == "System.Array"))
			{
				Console.WriteLine(String.Format("\nResult for Sorting chip:", result));

				int[] outputArray = (Int32[])result;

				foreach (int item in outputArray)
				{
					Console.Write(item+" ");
				}

				Console.WriteLine();
			}

			if ((type.BaseType.FullName == "System.ValueType"))
			{
				Console.WriteLine(String.Format("\nResult for Total Sum chip: {0}", (int)result));
			}

			if ((type.BaseType.FullName == "System.SystemException"))
			{
				if (type.FullName == "System.NullReferenceException")
				{
					Console.WriteLine(String.Format("\nException: No chip installed"));
				}
				else
				{
					Console.WriteLine(String.Format("\nException: {0}", result.ToString()));
				}
			} 

			if ((type.BaseType.FullName == "System.ArgumentException"))
			{
				Console.WriteLine(String.Format("\nInput array was null"));
			    Console.WriteLine(String.Format("\nException: {0}", result.ToString()));
			} 

		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApplication
{
	class Robot
	{
		// Using dependency injection
		// Think of the Robot as a client which is using Chips as services. IChip interface will be my service here

		private IChip chip;

		private ISet<Type> InstalledChips = new HashSet<Type>();

		// Property will store unique type of chips installed till now
		public int TotalUniqueChipsIntalled { get; set; }

		public Robot()
		{
			Console.WriteLine("\nRobot is ready. Installing the function chips");
		}

		public object executeChipLogic(int[] input)
		{
			object result = null;

			try
			{
				result = chip.chipFunction(input);
			}
			catch (Exception e)
			{
				result = e;
			}

			return result;
		}

		// Injecting the dependency into a single method, for use by that method.
		// Could have injected the dependency in constructor itself which is more common, but the requirement mentions a chip installation method
		public void installChip(IChip pluggedChip)
		{
			this.chip = pluggedChip;

			Console.WriteLine("\nInstalling Chip: " + pluggedChip.GetType().Name);

			InstalledChips.Add(pluggedChip.GetType());

			TotalUniqueChipsIntalled = InstalledChips.Count;
		}

	}
}

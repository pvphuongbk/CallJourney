using CallJourney.Test;
using Xunit;

namespace CallJourney.UnitTest
{
	public class TotalCostUnitTest
	{
		[Fact]
		public void MethodUnitTest_TotalCost_Case1()
		{
			var input = "atv, atv, atv, vga";
			var result = Program.TotalCost(input);

			// Assert
			Assert.Equal(249.00, result);
		}

		[Fact]
		public void MethodUnitTest_TotalCost_Case2()
		{
			var input = "atv, ipd, ipd, atv, ipd, ipd, ipd";
			var result = Program.TotalCost(input);

			// Assert
			Assert.Equal(2718.95, result);
		}

		[Fact]
		public void MethodUnitTest_TotalCost_Case3()
		{
			var input = "mbp, vga, ipd";
			var result = Program.TotalCost(input);

			// Assert
			Assert.Equal(1949.98, result);
		}
	}
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cartesian.Test
{
	[TestClass]
	public class MainTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void NullDimensions()
		{
			IEnumerable<int[]> dimensions = null;
			foreach (var item in dimensions.Cartesian<int, int[]>())
				Console.WriteLine("test");
		}

		[TestMethod]
		public void EmptyDimension()
		{
			var dimensions = new[] { Array.Empty<int>() };
			foreach (var item in dimensions.Cartesian<int, int[]>())
				Assert.Fail();
		}

		[TestMethod]
		public void Scenario()
		{
			var dimensions = new[] { new[] { 0, 1 }, new[] { 3, 4 } };
			var result = new List<IReadOnlyList<int>>();
			foreach (var item in dimensions.Cartesian<int, int[]>())
				result.Add(item);

			Assert.AreEqual(4, result.Count);
			Assert.IsTrue(result[0].SequenceEqual(new[] { 0, 3 }));
			Assert.IsTrue(result[1].SequenceEqual(new[] { 1, 3 }));
			Assert.IsTrue(result[2].SequenceEqual(new[] { 0, 4 }));
			Assert.IsTrue(result[3].SequenceEqual(new[] { 1, 4 }));
		}
	}
}

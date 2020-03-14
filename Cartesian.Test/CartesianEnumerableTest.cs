using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Cartesian.Test
{
	[TestClass]
	public class CartesianEnumerableTest
	{
		[TestMethod]
		public void EnumerateExplicitType()
		{
			var result = new List<IReadOnlyList<int>>();
			var dimensions = new[]
			{
				new[] { 0, 1 },
				new[] { 2, 3 }
			};
			foreach (var item in CartesianEnumerable.Enumerate<int, int[]>(dimensions))
				result.Add(item);

			Assert.AreEqual(4, result.Count);
			Assert.IsTrue(result[0].SequenceEqual(new[] { 0, 2 }));
			Assert.IsTrue(result[1].SequenceEqual(new[] { 1, 2 }));
			Assert.IsTrue(result[2].SequenceEqual(new[] { 0, 3 }));
			Assert.IsTrue(result[3].SequenceEqual(new[] { 1, 3 }));
		}

		[TestMethod]
		public void EnumerateImplicitType()
		{
			var result = new List<IReadOnlyList<int>>();
			var dimensions = new[]
			{
				new[] { 0, 1 },
				new[] { 2, 3 }
			};
			foreach (var item in CartesianEnumerable.Enumerate(dimensions))
				result.Add(item);

			Assert.AreEqual(4, result.Count);
			Assert.IsTrue(result[0].SequenceEqual(new[] { 0, 2 }));
			Assert.IsTrue(result[1].SequenceEqual(new[] { 1, 2 }));
			Assert.IsTrue(result[2].SequenceEqual(new[] { 0, 3 }));
			Assert.IsTrue(result[3].SequenceEqual(new[] { 1, 3 }));
		}


		[TestMethod]
		public void Enumerate2Type()
		{
			var result = new List<Tuple<int, string>>();
			foreach (var item in CartesianEnumerable.Enumerate(new[] { 0, 1 }, new[] { "a", "b" }))
				result.Add(item);

			Assert.AreEqual(4, result.Count);
			Assert.AreEqual(0, result[0].Item1);
			Assert.AreEqual("a", result[0].Item2);
			Assert.AreEqual(1, result[1].Item1);
			Assert.AreEqual("a", result[1].Item2);
			Assert.AreEqual(0, result[2].Item1);
			Assert.AreEqual("b", result[2].Item2);
			Assert.AreEqual(1, result[3].Item1);
			Assert.AreEqual("b", result[3].Item2);
		}
	}
}

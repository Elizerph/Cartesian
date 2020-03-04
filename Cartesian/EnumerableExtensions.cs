using System;
using System.Collections.Generic;
using System.Linq;

namespace Cartesian
{
	public static class EnumerableExtensions
	{
		public static T2[] ToArray<T1, T2>(this IEnumerable<T1> enumerableIntf, Func<T1, T2> selector)
		{
			return enumerableIntf.Select(selector).ToArray();
		}

		public static void ForEach<T>(this IReadOnlyCollection<T> collection, Action<T> action)
		{
			foreach (var item in collection)
				action(item);
		}

		public static IEnumerable<IReadOnlyList<TElement>> Cartesian<TElement, TDimension>(this IEnumerable<TDimension> dimensions) where TDimension : IEnumerable<TElement>
		{
			return new CartesianCollection<TElement, TDimension>(dimensions);
		}
	}
}

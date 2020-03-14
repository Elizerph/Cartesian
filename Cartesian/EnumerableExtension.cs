using System;
using System.Collections.Generic;
using System.Linq;

namespace Cartesian
{
	public static class EnumerableExtension
	{
		internal static T2[] ToArray<T1, T2>(this IEnumerable<T1> enumerableIntf, Func<T1, T2> selector)
		{
			return enumerableIntf.Select(selector).ToArray();
		}

		internal static void ForEach<T>(this IReadOnlyCollection<T> collection, Action<T> action)
		{
			foreach (var item in collection)
				action(item);
		}

		public static IEnumerable<IReadOnlyList<TElement>> Cartesian<TElement, TDimension>(this IEnumerable<TDimension> dimensions) where TDimension : IEnumerable<TElement>
		{
			return CartesianEnumerable.Enumerate<TElement, TDimension>(dimensions.ToArray());
		}

		public static IEnumerable<IReadOnlyList<T>> Cartesian<T>(this IEnumerable<IEnumerable<T>> dimensions)
		{
			return CartesianEnumerable.Enumerate<T, IEnumerable<T>>(dimensions.ToArray());
		}
	}
}

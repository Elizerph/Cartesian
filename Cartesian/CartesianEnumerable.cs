using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cartesian
{
	internal class CartesianEnumerable<TElement, TDimension> : IEnumerable<IReadOnlyList<TElement>> where TDimension : IEnumerable<TElement>
	{
		private readonly IEnumerable<TDimension> _dimensions;

		public CartesianEnumerable(IEnumerable<TDimension> dimensions)
		{
			_dimensions = dimensions;
		}

		public IEnumerator<IReadOnlyList<TElement>> GetEnumerator()
		{
			var enumerators = _dimensions.Select(d => d.GetEnumerator()).ToArray();

			foreach (var enumerator in enumerators.Skip(1))
				if (!enumerator.MoveNext())
					return new EmptyEnumerator<IReadOnlyList<TElement>>();

			return new CartesianEnumerator<TElement>(enumerators);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	public static class CartesianEnumerable
	{
		public static IEnumerable<IReadOnlyList<TElement>> Enumerate<TElement, TDimension>(params TDimension[] dimensions) where TDimension : IEnumerable<TElement>
		{
			return new CartesianEnumerable<TElement, TDimension>(dimensions);
		}

		public static IEnumerable<IReadOnlyList<T>> Enumerate<T>(IEnumerable<IEnumerable<T>> dimensions)
		{
			return new CartesianEnumerable<T, IEnumerable<T>>(dimensions);
		}

		public static IEnumerable<Tuple<T1, T2>> Enumerate<T1, T2>(IEnumerable<T1> dimension1, IEnumerable<T2> dimension2)
		{
			var dimensions = new[]
			{
				dimension1.Cast<object>().ToArray(),
				dimension2.Cast<object>().ToArray()
			};
			return new CartesianEnumerable<object, IEnumerable<object>>(dimensions).Select(e => Tuple.Create((T1)e[0], (T2)e[1]));
		}

		public static IEnumerable<Tuple<T1, T2, T3>> Enumerate<T1, T2, T3>(IEnumerable<T1> dimension1, IEnumerable<T2> dimension2, IEnumerable<T3> dimension3)
		{
			var dimensions = new[]
			{
				dimension1.Cast<object>().ToArray(),
				dimension2.Cast<object>().ToArray(),
				dimension3.Cast<object>().ToArray()
			};
			return new CartesianEnumerable<object, IEnumerable<object>>(dimensions).Select(e => Tuple.Create((T1)e[0], (T2)e[1], (T3)e[2]));
		}

		public static IEnumerable<Tuple<T1, T2, T3, T4>> Enumerate<T1, T2, T3, T4>(IEnumerable<T1> dimension1, IEnumerable<T2> dimension2, IEnumerable<T3> dimension3, IEnumerable<T4> dimension4)
		{
			var dimensions = new[]
			{
				dimension1.Cast<object>().ToArray(),
				dimension2.Cast<object>().ToArray(),
				dimension3.Cast<object>().ToArray(),
				dimension4.Cast<object>().ToArray()
			};
			return new CartesianEnumerable<object, IEnumerable<object>>(dimensions).Select(e => Tuple.Create((T1)e[0], (T2)e[1], (T3)e[2], (T4)e[3]));
		}

		public static IEnumerable<Tuple<T1, T2, T3, T4, T5>> Enumerate<T1, T2, T3, T4, T5>(IEnumerable<T1> dimension1, IEnumerable<T2> dimension2, IEnumerable<T3> dimension3, IEnumerable<T4> dimension4, IEnumerable<T5> dimension5)
		{
			var dimensions = new[]
			{
				dimension1.Cast<object>().ToArray(),
				dimension2.Cast<object>().ToArray(),
				dimension3.Cast<object>().ToArray(),
				dimension4.Cast<object>().ToArray(),
				dimension5.Cast<object>().ToArray()
			};
			return new CartesianEnumerable<object, IEnumerable<object>>(dimensions).Select(e => Tuple.Create((T1)e[0], (T2)e[1], (T3)e[2], (T4)e[3], (T5)e[4]));
		}
	}
}

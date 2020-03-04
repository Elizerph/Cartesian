using System.Collections;
using System.Collections.Generic;

namespace Cartesian
{
	class CartesianCollection<TElement, TDimension> : IEnumerable<IReadOnlyList<TElement>> where TDimension : IEnumerable<TElement>
	{
		private readonly IEnumerable<TDimension> _dimensions;

		public CartesianCollection(IEnumerable<TDimension> dimesnions)
		{
			_dimensions = dimesnions;
		}

		public IEnumerator<IReadOnlyList<TElement>> GetEnumerator()
		{
			return new CartesianEnumerator<TElement, TDimension>(_dimensions);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

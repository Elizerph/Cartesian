using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cartesian
{
	sealed class CartesianEnumerator<TElement, TDimension> : IEnumerator<IReadOnlyList<TElement>>
		where TDimension : IEnumerable<TElement>
	{
		private readonly IReadOnlyList<IEnumerator<TElement>> _enumerators;
		private bool _firstElementReached;

		public CartesianEnumerator(IEnumerable<TDimension> dimensions)
		{
			if (dimensions == null)
				throw new ArgumentNullException(nameof(dimensions));

			_enumerators = dimensions.ToArray(e => e.GetEnumerator());
		}

		public IReadOnlyList<TElement> Current
		{
			get
			{
				return _enumerators.ToArray(e => e.Current);
			}
		}

		object IEnumerator.Current => Current;

		public void Dispose()
		{
			_enumerators.ForEach(e => e.Dispose());
		}

		public bool MoveNext()
		{
			if (!_firstElementReached)
			{
				_firstElementReached = _enumerators.Any() && _enumerators.All(e => e.MoveNext());
				return _firstElementReached;
			}
			else
			{
				foreach (var enumerator in _enumerators)
				{
					if (enumerator.MoveNext())
						return true;
					else
					{
						enumerator.Reset();
						enumerator.MoveNext();
					}
				}
			}
			return false;
		}

		public void Reset()
		{
			_enumerators.ForEach(e => e.Reset());
		}
	}
}

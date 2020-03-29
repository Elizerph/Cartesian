using System;
using System.Collections;
using System.Collections.Generic;

namespace Cartesian
{
	internal sealed class CartesianEnumerator<T> : IEnumerator<IReadOnlyList<T>>
	{
		private readonly IReadOnlyCollection<IEnumerator<T>> _enumerators;

		public CartesianEnumerator(IReadOnlyCollection<IEnumerator<T>> enumerators)
		{
			if (enumerators == null)
				throw new ArgumentNullException(nameof(enumerators));

			_enumerators = enumerators;
		}

		public IReadOnlyList<T> Current
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
			return false;
		}

		public void Reset()
		{
			_enumerators.ForEach(e => e.Reset());
		}
	}
}

using System.Collections;
using System.Collections.Generic;

namespace Cartesian
{
	internal class EmptyEnumerator<T> : IEnumerator<T>
	{
		public T Current => default;

		object IEnumerator.Current => default;

		public void Dispose()
		{

		}

		public bool MoveNext()
		{
			return false;
		}

		public void Reset()
		{
		}
	}
}

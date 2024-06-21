using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregatorBackend.Models.Helpers
{
	public class StaticArray<T>
	{
		public StaticArray() { }

		public StaticArray(ulong newSize)
		{
			_size = newSize;
			_array = new T[newSize];
			Length = (int)_size;
			LongLength = (long)_size;
		}

		public StaticArray(T[] array)
		{
			_array = array;
			_size = (ulong)array.LongLength;
			Length = (int)_size;
			LongLength = (long)_size;
		}

		public StaticArray(StaticArray<T> other)
		{
			_size = other.Size();

			_array = new T[_size];

			Length = (int)_size;
			LongLength = (long)_size;

			for (ulong i = 0; i < _size; i++)
				_array[i] = other[i];
		}

		~StaticArray()
		{
			this.Deallocate();
		}

		public ulong Size()
		{
			return _size;
		}

		public T this[ulong index]
		{
			set
			{
				if (_array == null)
					throw new Exception($"StaticArray<{typeof(T).Name}> core array is null!");

				if (index >= _size)
					throw new IndexOutOfRangeException();

				_array[index] = value;
			}

			get
			{
				if (_array == null)
					throw new Exception($"StaticArray<{typeof(T).Name}> core array is null!");

				if (index >= _size)
					throw new IndexOutOfRangeException();

				return _array[index];
			}
		}

		public T[] ToArray()
		{
			if (_array == null)
				throw new Exception($"StaticArray<{typeof(T).Name}> core array is null!");

			return _array;
		}

		public override string? ToString()
		{
			if (_array == null)
				throw new Exception($"StaticArray<{typeof(T).Name}> core array is null!");

			string? result = null;

			foreach (T item in _array)
			{
				if (item == null)
					throw new NullReferenceException();

				result += item.ToString();
			}

			return result;
		}

		public List<T> ToList()
		{
			if (_array == null)
				throw new Exception($"StaticArray<{typeof(T).Name}> core array is null!");

			return new List<T>(_array);
		}

		public new Type GetType()
		{
			return typeof(StaticArray<T>);
		}

		public bool Empty()
		{
			if (_array == null)
				return true;

			return false;
		}

		public void Allocate(ulong size)
		{
			if ((_array != null) && (_size != 0))
				throw new Exception("Static array is not empty!");

			_size = size;
			_array = new T[_size];
		}

		public void Deallocate()
		{
			_array = null;
			GC.Collect();
			_size = 0;
		}

		public int Length { get; }
		public long LongLength { get; }

		private T[]? _array = null;
		private ulong _size = 0;
	}

	public static class StaticArray
	{
		public static bool Equivalent<T>(StaticArray<T> left, StaticArray<T> right)
		{
			if (left.Size() != right.Size()) return false;

			for (ulong i = 0; i < right.Size(); i++)
			{
				/* https://stackoverflow.com/questions/488250/c-sharp-compare-two-generic-values */
				if (!EqualityComparer<T>.Default.Equals(left[i], right[i]))
					return false;
			}

			return true;
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregatorBackend.Models.Helpers
{
	public sealed class FileTerminal
	{
		public FileTerminal() { }

		public FileTerminal(StaticArray<byte> byte_array)
		{
			_byte_array = byte_array;
		}

		public FileTerminal(char[] char_array)
		{
			_byte_array = new StaticArray<byte>((ulong)char_array.LongLength);

			for (ulong i = 0; i < _byte_array.Size(); i++)
			{
				_byte_array[i] = (byte)char_array[i];
			}
		}

		public FileTerminal(byte[] byteArray)
		{
			;

			_byte_array = new StaticArray<byte>((ulong)byteArray.LongLength);

			for (ulong i = 0; i < _byte_array.Size(); i++)
			{
				_byte_array[i] = byteArray[i];
			}
		}

		public FileTerminal(string filePath)
		{
			FileStream stream_reader = new FileStream(filePath, FileMode.Open);

			_byte_array = new StaticArray<byte>((ulong)stream_reader.Length);

			for (ulong i = 0; i < _byte_array.Size(); i++)
			{
				_byte_array[i] = (byte)stream_reader.ReadByte();
			}


			stream_reader.Dispose();
		}

		public FileTerminal(FileTerminal other)
		{
			_byte_array = other.ImageAsStaticByteArray();
		}

		public void SaveFile(string filePath)
		{
			if (_byte_array == null)
				throw new Exception("Internal byte array is null!");

			FileStream stream_writer = new FileStream(filePath, FileMode.Create);

			for (ulong i = 0; i < _byte_array.Size(); i++)
			{
				stream_writer.WriteByte(_byte_array[i]);
			}

			stream_writer.Dispose();
		}

		public void LoadFile(string filePath)
		{
			FileStream stream_reader = new FileStream(filePath, FileMode.Open);

			_byte_array = new StaticArray<byte>((ulong)stream_reader.Length);

			for (ulong i = 0; i < _byte_array.Size(); i++)
			{
				_byte_array[i] = (byte)stream_reader.ReadByte();
			}

			stream_reader.Dispose();
		}

		public StaticArray<byte> ImageAsStaticByteArray()
		{
			if (_byte_array == null)
				throw new Exception("Internal byte array is null!");

			return _byte_array;
		}

		public char[] FileAsCharArray()
		{
			if (_byte_array == null)
				throw new Exception("Internal byte array is null!");

			char[] image_as_char_array = new char[_byte_array.Size()];

			for (ulong i = 0; i < _byte_array.Size(); i++)
			{
				image_as_char_array[i] = (char)_byte_array[i];
			}

			return image_as_char_array;
		}

		public string? FileAsString()
		{
			if (_byte_array == null)
				throw new Exception("Internal byte array is null!");

			return _byte_array.ToString();
		}

		public byte[] FileAsByteArray()
		{
			if (_byte_array == null)
				throw new Exception("Internal byte array is null!");

			return _byte_array.ToArray();
		}

		public ulong FileSizeBytes()
		{
			if (_byte_array == null)
				throw new Exception("Internal byte array is null!");

			return _byte_array.Size();
		}

		/* Image represented as an array of characters */
		private StaticArray<byte>? _byte_array = null;
	}
}
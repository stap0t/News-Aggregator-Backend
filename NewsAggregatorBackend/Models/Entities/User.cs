using NewsAggregatorBackend.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregatorBackend.Models.Entities
{
	[Serializable]
	public sealed class User
	{
		public User()
		{
			Id = Guid.Empty;
			Name = string.Empty;
			Surname = string.Empty;
			Username = string.Empty;
			Password = string.Empty;
			BirthDate = DateTime.Now;
			ProfileCreationDate = DateTime.Now;
		}

		public User(Guid id, string name, List<string>? middleNames, string surname, string username, string password, DateTime birthDate, List<string>? links, DateTime profileCreationDate)
		{
			Id = id;
			Name = name;
			MiddleNames = middleNames;
			Surname = surname;
			Username = username;
			Password = password;
			BirthDate = birthDate;
			Links = links;
			ProfileCreationDate = profileCreationDate;

			byte[] byte_array = new byte[Password.Length];

			for (int i = 0; i < byte_array.Length; i++)
				byte_array[i] = (byte)Password[i];

			SHA512 hasher = SHA512.Create();

			byte[] output_hash = hasher.ComputeHash(byte_array);

			StaticArray<char> password_hash = new StaticArray<char>((ulong)output_hash.Length);

			for (ulong i = 0; i < (ulong)output_hash.Length; i++)
				password_hash[i] = (char)output_hash[i];

			_password_hash = password_hash.ToString();

			Password = null;
		}

		public User(User other)
		{
			Id = other.Id;
			Name = other.Name;
			MiddleNames = (other.MiddleNames != null) ? other.MiddleNames : null;
			Surname = other.Surname;
			Username = other.Username;
			BirthDate = other.BirthDate;
			Links = (other.Links != null) ? other.Links : null;
			ProfileCreationDate = other.ProfileCreationDate;
			_password_hash = other.PasswordHash();
		}

		public string? PasswordHash()
		{
			if ((_password_hash == null) && (Password != null))
			{
				byte[] byte_array = new byte[Password.Length];

				for (int i = 0; i < byte_array.Length; i++)
					byte_array[i] = (byte)Password[i];

				SHA512 hasher = SHA512.Create();

				byte[] output_hash = hasher.ComputeHash(byte_array);

				StaticArray<char> password_hash = new StaticArray<char>((ulong)output_hash.Length);

				for (ulong i = 0; i < (ulong)output_hash.Length; i++)
					password_hash[i] = (char)output_hash[i];

				_password_hash = password_hash.ToString();

				Password = null;

				return _password_hash;
			}

			else if ((_password_hash != null) && (Password == null)) return _password_hash;

			else throw new Exception("Password hash unavailable!");
		}

		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<string>? MiddleNames { get; set; }
		public string Surname { get; set; }
		public string Username { get; set; }
		public string? Password { get; set; }
		public DateTime BirthDate { get; set; }
		public List<string>? Links { get; set; }
		public DateTime ProfileCreationDate { get; set; }

		private string? _password_hash = null;
	}
}
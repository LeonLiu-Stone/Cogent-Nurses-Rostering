using System;
namespace Nurses.Rostering.Models
{
	/// <summary>
	/// the basic class of all custom exceptions
	/// </summary>
	public class CustomException : Exception
	{
		public CustomException() { }

		public CustomException(string message) : base(message) { }

		public CustomException(string message, Exception innerException) : base(message, innerException) { }
	}

	/// <summary>
	/// a logical jumping exception
	/// </summary>
	public class SafeException : CustomException
	{
		public SafeException() { }

		public SafeException(string message) : base(message) { }

		public SafeException(string message, Exception innerException) : base(message, innerException) { }
	}
}

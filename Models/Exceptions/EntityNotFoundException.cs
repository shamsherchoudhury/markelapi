using System;

namespace Models.Exceptions
{
	[Serializable]
	public class EntityNotFoundException : Exception
	{
		public EntityNotFoundException(string message) : base(message)
		{
		}
    }
}


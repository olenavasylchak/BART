using System;

namespace BART.Exceptions;

public class NotFoundException : Exception
{
	public NotFoundException(string message) : base(message)
	{
		
	}
}


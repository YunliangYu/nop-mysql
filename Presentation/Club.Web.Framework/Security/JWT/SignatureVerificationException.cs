using System;

namespace Club.Web.Framework.Security.JWT
{
	public class SignatureVerificationException : Exception
	{
		public SignatureVerificationException(string message)
			: base(message)
		{
		}
	}
}
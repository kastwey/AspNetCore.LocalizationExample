using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.LocalizationExample.Exceptions
{

	[Serializable]
	public class OzuMiArmaException : LazyException
	{
		public OzuMiArmaException() { }
		public OzuMiArmaException(string message) : base(message) { }
		public OzuMiArmaException(string message, Exception inner) : base(message, inner) { }
		protected OzuMiArmaException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}

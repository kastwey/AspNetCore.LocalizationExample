using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.LocalizationExample.Exceptions
{


	[Serializable]
	public class LazyException : Exception
	{
		public LazyException() { }
		public LazyException(string message) : base(message) { }
		public LazyException(string message, Exception inner) : base(message, inner) { }
		protected LazyException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}

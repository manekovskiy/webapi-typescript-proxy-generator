using System;
using System.Collections.Generic;

namespace WebApiProxyGenerator
{
	internal enum DtoTypeKind
	{
		Interface,
		Enum,
		Class
	}

	internal class DtoType
	{
		public string Name { get; set; }
		public DtoTypeKind Kind { get; set; }
		public IEnumerable<DtoMember> Members { get; set; }
	}

	internal class DtoMember
	{
		public string Name { get; set; }
		public Type Type { get; set; }
	}
}
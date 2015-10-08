using System.Collections.Generic;
using System.Linq;

namespace WebApiProxyGenerator.Templates
{
	internal partial class TypesGenerator
	{
		public DtoType[] DtoTypes { get; set; }

		private IEnumerable<DtoType> Interfaces { get { return DtoTypes.Where(t => t.Kind == DtoTypeKind.Class || t.Kind == DtoTypeKind.Interface); } }
		private IEnumerable<DtoType> Enums { get { return DtoTypes.Where(t => t.Kind == DtoTypeKind.Enum); } }
	}
}
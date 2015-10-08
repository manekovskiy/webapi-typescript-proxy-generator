using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace WebApiProxyGenerator
{
	internal static class MetadataHelper
	{
		public static DtoType[] GetDtoTypesMetadata(IEnumerable<Type> types)
		{
			return types
				.Where(t => !t.IsAbstract) // We are not interested in abstract classes
				.Where(t => t.GetCustomAttribute<DataContractAttribute>() != null)
				.Select(t => new DtoType
				{
					Name = t.Name,
					// struct => interface
					// class => class
					// enum => enum. Must check for enum first because it is a ValueType and we want to avoid enums to be generaed as interfaces
					Kind = t.IsEnum
							? DtoTypeKind.Enum
							: t.IsValueType
								? DtoTypeKind.Interface
								: DtoTypeKind.Class,
					Members = t.IsEnum // For enum types we should get its values except the "value__" field
						? t.GetFields()
							.Where(f => f.GetCustomAttribute<DataMemberAttribute>() != null && f.Name != "value__")
							.Select(f => new DtoMember
							{
								Name = f.Name,
								Type = f.FieldType
							})
						: t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
							.Where(p => p.GetCustomAttribute<DataMemberAttribute>() != null)
							.Select(p => new DtoMember
							{
								Name = p.Name,
								Type = p.PropertyType
							})
				})
				.ToArray();
		}
	}
}

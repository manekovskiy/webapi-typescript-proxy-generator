using System;
using System.IO;
using WebApiProxyGenerator.Templates;
using WebApiService;

namespace WebApiProxyGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0 || args[0].IndexOfAny(Path.GetInvalidPathChars()) >= 0)
			{
				throw new ArgumentException("Invalid argument. First argument should be a valid file path.");
            }

			var fileName = args[0];
			var typesMetadata = MetadataHelper.GetDtoTypesMetadata(typeof(Todo).Assembly.ExportedTypes);
			var typesGenerator = new TypesGenerator { DtoTypes = typesMetadata };
			File.WriteAllText(fileName, typesGenerator.TransformText().Trim());
		}
	}
}

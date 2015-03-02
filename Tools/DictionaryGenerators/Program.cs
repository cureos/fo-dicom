namespace DictionaryGenerators
{
	using System.IO;
	using System.Text;

	using Dicom;
	using Dicom.Generators.DocBookParser;

	class Program
	{
		static void Main(string[] args)
		{
			var dd = Part6Parser.ParseDataDictionaries("part06.xml", "part07.xml");
			var uids = Part6Parser.ParseUIDTables("part06.xml", "part16.xml");

			var dicomDict = new DicomDictionary();
			foreach (var ddentry in dd)
			{
				dicomDict.Add(ddentry);
			}

			var a = Dicom.Generators.DicomDictionaryGenerator.Generate("Dicom", "DicomDictionary", "InstallDefaultDictionaryElements_", dicomDict);
			var b = Dicom.Generators.DicomTagGenerator.Generate("Dicom", "DicomTag", dicomDict);
			var c = Dicom.Generators.DicomUIDGenerator.Emit(uids);

			File.WriteAllText("DicomDictionaryGenerated.cs", a, Encoding.UTF8);
			File.WriteAllText("DicomTagGenerated.cs", b, Encoding.UTF8);
			File.WriteAllText("DicomUIDGenerated.cs", c, Encoding.UTF8);
		}
	}
}

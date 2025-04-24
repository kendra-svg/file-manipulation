public class Reader
{
	public void ReadLinesFromFileAndPrint()
	{
		string path = "C:\\Users\\Kendra\\Desktop\\foldertoread\\file1.txt";

		var readFile = File.ReadLines(path);

		foreach (var file in readFile)
		{
			Console.WriteLine(file);
		}
	}
}
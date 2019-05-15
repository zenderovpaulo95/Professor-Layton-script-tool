using System;

namespace LaytonScriptTool
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			if (args.Length == 2 && args [0] == "export") {
				string InputFile = args [1];
				string OutputFile = WorkFiles.ReplaceFileName (args [1], ".txt");

				if (OutputFile != null) {
					int result = WorkFiles.ExportFile (InputFile, OutputFile);

					switch (result) {
					case -2:
						Console.WriteLine ("File doesn't exists.");
						break;

					case -1:
						Console.WriteLine ("Unknown error. Please send me a file.");
						break;

					default:
						Console.WriteLine ("File extracted successfully.");
						break;
					}
				} else
					Console.WriteLine ("Error for make export file name.");
			} else if ((args.Length == 3 || args.Length == 4) && (args [0] == "import"))
			{
				string InputFile = args[1];
				string InputTxtFile = args[2];
				string OutputFile = args[1];
				if(args.Length == 4) OutputFile = args[3];

				if (OutputFile != null) {
					int result = WorkFiles.ImportFile(InputFile, InputTxtFile, OutputFile);

					switch (result) {
					case -2:
						Console.WriteLine ("File doesn't exists.");
						break;

					case -1:
						Console.WriteLine ("Unknown error. Please send me a file.");
						break;

					case 0:
						Console.WriteLine ("Couldn't make import file. Check strings in original and translation.");
						break;

					default:
						Console.WriteLine ("File imported successfully.");
						break;
					}
				} else
					Console.WriteLine ("Error for make import file name.");
			} else if ((args.Length == 4) && (args [0] == "replace") && (System.IO.Directory.Exists (args [1]) && System.IO.Directory.Exists (args [2]))
			        && System.IO.File.Exists (args [3]))
			{
				string DirectoryOriginal = args[1];
				string DirectoryTranslate = args[2];
				string FullFile = args[3];

				int result = WorkFiles.replace(DirectoryOriginal, DirectoryTranslate, FullFile);

				switch (result)
				{
				case -2:
					Console.WriteLine("Check correctly paths.");
					break;
				case -1:
					Console.WriteLine("Something wrong. Please send me file");
						break;

				case 0:
					Console.WriteLine("File is not modified!");
						break;

				case 1:
					Console.WriteLine("File successfully modified.");
						break;
				}
			}
			else 
			{
				Console.WriteLine ("How to use:");
				Console.WriteLine ("{0} export <script_file_name> - for export", AppDomain.CurrentDomain.FriendlyName);
				Console.WriteLine ("{0} import <script_file_name> <txt_file_name> - for import", AppDomain.CurrentDomain.FriendlyName);
				Console.WriteLine ("{0} replace <original_path> <translated_path> <needed_file.txt> - for replace strings", AppDomain.CurrentDomain.FriendlyName);
			}
		}
	}
}

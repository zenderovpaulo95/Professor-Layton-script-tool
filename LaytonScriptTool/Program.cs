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
					int result = WorkFiles.ExportFile (InputFile, OutputFile, false, false);

					switch (result) {
					case -2:
						Console.WriteLine ("File doesn't exist.");
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
			} else if (args.Length == 3 && args [0] == "export" && (args [2] == "ascii" || args [2] == "ASCII")) {
				string InputFile = args [1];
				string OutputFile = WorkFiles.ReplaceFileName (args [1], ".txt");

				if (OutputFile != null) {
					int result = WorkFiles.ExportFile (InputFile, OutputFile, true, false);

					switch (result) {
					case -2:
						Console.WriteLine ("File doesn't exist.");
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
			} else if ((args.Length == 3 && args [0] == "export" && args [1] == "datfile")
				|| (args.Length == 4 && args[0] == "export" && args[1] == "datfile" && args[2] == "NDS")) {
				bool isNDS = args.Length == 4 && args [2] == "NDS" ? true : false;

				string path = isNDS ? args [3] : args [2];

				int result = WorkFiles.ExportDatFile (path, isNDS);

				switch (result) {
				case -2:
					Console.WriteLine ("File doesn't exist.");
					break;

				case -1:
					Console.WriteLine ("Unknown error. Please send me a file.");
					break;

				case 0:
					Console.WriteLine ("Couldn't make import file. Check strings in original and translation.");
					break;
				}

			} else if((args.Length == 3 && args[0] == "import" && args[1] == "datfile") ||
				(args.Length == 4 && args[0] == "import" && args[1] == "datfile" && args[2] == "NDS"))
            {
				bool isNDS = args.Length == 4 && args [2] == "NDS";
				string InputFile = isNDS ? args[3] : args[2]; //Dat file
                string[] strings = new string[7];

                string FileName = InputFile.Remove(InputFile.Length - 4, 4);

                if (System.IO.File.Exists(FileName + "_title.txt") && System.IO.File.Exists(FileName + "_question.txt"))
                {
                    string[] tmp_strs = System.IO.File.ReadAllLines(FileName + "_title.txt");
                    strings[0] = WorkFiles.MassiveToString(tmp_strs);
                    tmp_strs = System.IO.File.ReadAllLines(FileName + "_question.txt");
                    strings[1] = WorkFiles.MassiveToString(tmp_strs);
                    strings[1] = strings[1].Replace("\r\n", "\n");
                    strings[2] = "";
                    strings[3] = "";
                    strings[4] = "";
                    strings[5] = "";
                    strings[6] = "";

                    if (System.IO.File.Exists(FileName + "_correct.txt"))
                    {
                        tmp_strs = System.IO.File.ReadAllLines(FileName + "_correct.txt");
                        strings[2] = WorkFiles.MassiveToString(tmp_strs);
                    }
                    if (System.IO.File.Exists(FileName + "_wrong.txt"))
                    {
                        tmp_strs = System.IO.File.ReadAllLines(FileName + "_wrong.txt");
                        strings[3] = WorkFiles.MassiveToString(tmp_strs);
                    }
                    if (System.IO.File.Exists(FileName + "_solution1.txt"))
                    {
                        tmp_strs = System.IO.File.ReadAllLines(FileName + "_solution1.txt");
                        strings[4] = WorkFiles.MassiveToString(tmp_strs);
                    }
                    if (System.IO.File.Exists(FileName + "_solution2.txt"))
                    {
                        tmp_strs = System.IO.File.ReadAllLines(FileName + "_solution2.txt");
                        strings[5] = WorkFiles.MassiveToString(tmp_strs);
                    }
                    if (System.IO.File.Exists(FileName + "_solution3.txt"))
                    {
                        tmp_strs = System.IO.File.ReadAllLines(FileName + "_solution3.txt");
                        strings[6] = WorkFiles.MassiveToString(tmp_strs);
                    }

                    int result = WorkFiles.ImportDatFile(InputFile, strings, isNDS);

                    switch(result)
                    {
                        case -2:
                            Console.WriteLine("File doesn't exists.");
                            break;

                        case -1:
                            Console.WriteLine("Unknown error. Please send me a file.");
                            break;

                        case 2:
                            Console.WriteLine("Too long title name.");
                            break;

                        case 3:
                            Console.WriteLine("Too long question.");
                            break;

                        case 4:
                            Console.WriteLine("Too long correct answer.");
                            break;

                        case 5:
                            Console.WriteLine("Too long wrong answer.");
                            break;

                        case 6:
                            Console.WriteLine("Too long solution 1.");
                            break;

                        case 7:
                            Console.WriteLine("Too long solution 2.");
                            break;

                        case 8:
                            Console.WriteLine("Too long solution 3.");
                            break;

                        case 9:
                            Console.WriteLine("Somehow in total file too long. Please make less some strings.");
                            break;

                        default:
                            Console.WriteLine("File successfully modified!");
                            break;
                    }
                }
                else Console.WriteLine("You need have {0}_title.txt and {0}_question.txt file", FileName);

            } else if ((args.Length == 3 || args.Length == 4) && (args [0] == "import")) {
				string InputFile = args [1];
				string InputTxtFile = args [2];
				string OutputFile = args [1];
				if (args.Length == 4)
					OutputFile = args [3];

				if (OutputFile != null) {
					int result = WorkFiles.ImportFile (InputFile, InputTxtFile, OutputFile);

					switch (result) {
					case -2:
						Console.WriteLine ("File doesn't exist.");
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
			           && System.IO.File.Exists (args [3])) {
				string DirectoryOriginal = args [1];
				string DirectoryTranslate = args [2];
				string FullFile = args [3];

				int result = WorkFiles.replace (DirectoryOriginal, DirectoryTranslate, FullFile);

				switch (result) {
				case -2:
					Console.WriteLine ("Check correctly paths.");
					break;
				case -1:
					Console.WriteLine ("Something wrong. Please send me file.");
					break;

				case 0:
					Console.WriteLine ("File is not modified!");
					break;

				case 1:
					Console.WriteLine ("File successfully modified.");
					break;
				}
			} else if (args.Length == 2 && args [0] == "debug") {
				string InputFile = args [1];
				string OutputFile = WorkFiles.ReplaceFileName (args[1], ".txt");

				if (OutputFile != null) {
					int result = WorkFiles.ExportFile (InputFile, OutputFile, false, true);

					switch (result) {
					case -2:
						Console.WriteLine ("File doesn't exist.");
						break;

					case -1:
						Console.WriteLine ("Unknown error. Please send me a file.");
						break;

					default:
						Console.WriteLine ("File extracted successfully.");
						break;
					}
				} else
					Console.WriteLine ("Error make export file name.");
			}
			else 
			{
				Console.WriteLine ("How to use:");
				Console.WriteLine ("{0} export <script_file_name> - for export", AppDomain.CurrentDomain.FriendlyName);
				Console.WriteLine ("{0} export datfile <script_file_name> - for export dat files", AppDomain.CurrentDomain.FriendlyName);
				Console.WriteLine ("{0} import <script_file_name> <txt_file_name> - for import", AppDomain.CurrentDomain.FriendlyName);
				Console.WriteLine("{0} import datfile <script_file_name> - for import dat files (WARNING! Text files must be near with dat-file)", AppDomain.CurrentDomain.FriendlyName);
				Console.WriteLine ("{0} replace <original_path> <translated_path> <needed_file.txt> - for replace strings", AppDomain.CurrentDomain.FriendlyName);
			}
		}
	}
}

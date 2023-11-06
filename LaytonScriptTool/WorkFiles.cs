﻿using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace LaytonScriptTool
{
	public class WorkFiles
	{
        public static string MassiveToString(string[] strs)
        {
            string tmp = "";

            for(int i = 0; i < strs.Length; i++)
            {
                tmp += strs[i];
                if (i + 1 < strs.Length) tmp += "\r\n";
            }

            return tmp;
        }
        private static int pad(int size)
        {
            while (size % 2 != 0) size++;

            return size;
        }
		public static string ReplaceFileName(string FileName, string extension)
		{
			string tmp = FileName;
			int c = FileName.Length - 1;

			while (c != 0) 
			{
				if (c <= 0) 
				{
					tmp = null;
					break;
				}
				if (tmp[c] == '.') 
				{
					tmp = tmp.Remove(c, FileName.Length - c);
					tmp += extension;
					break;
				}

				c--;
			}
				
			return tmp;
		}

		public static int ImportFile(string InFileName, string InTxtFileName, string OutFileName)
		{
			try
			{
				if(!File.Exists(InFileName) || !File.Exists(InTxtFileName)) return -2;

				List<ClassesAndStructs.QuestTitle> Data = new List<ClassesAndStructs.QuestTitle>();

				Data = GetData(InFileName, false);
				if(Data != null)
				{

				string[] new_strs = File.ReadAllLines(InTxtFileName, Encoding.UTF8);

					int size;
					byte[] tmp;

				if(new_strs.Length == Data.Count)
				{
					MemoryStream ms = new MemoryStream();

					size = 0;
					tmp = new byte[4];
					ms.Write(tmp, 0, tmp.Length);

						int i = 0;

					while(i < new_strs.Length)
					{
						Data[i].Str = new_strs[i] + "\0";
							if(Data[i].Str.Contains("\\n")) Data[i].Str = Data[i].Str.Replace("\\n", "\n");
							else if(Data[i].Str.Contains("/n")) Data[i].Str = Data[i].Str.Replace("/n", "\n");
						tmp = Encoding.UTF8.GetBytes(Data[i].Str);
						Data[i].Str_size = (short)tmp.Length;

						size += 4 + Data[i].Str_size;

						tmp = BitConverter.GetBytes(Data[i].Unknown1);
						ms.Write(tmp, 0, tmp.Length);
						tmp = BitConverter.GetBytes(Data[i].Unknown2);
						ms.Write(tmp, 0, tmp.Length);

							if(Data[i].Unknown2 != 0xCA && Data[i].Unknown2 != 0xCB)
							{
								tmp = BitConverter.GetBytes(Data[i].Unknown3);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown4);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown5);
								ms.Write(tmp, 0, tmp.Length);
								size += 6;

								if(Data[i].Unknown2 == 0xBC || Data[i].Unknown2 == 0xBD)
								{
									tmp = BitConverter.GetBytes(Data[i].Unknown6);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown7);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown8);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown9);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown10);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown11);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown12);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown13);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown14);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown15);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown16);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown17);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown18);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown19);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown20);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown21);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown22);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown23);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown24);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown25);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown26);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown27);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown28);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown29);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown30);
									ms.Write(tmp, 0, tmp.Length);
									tmp = BitConverter.GetBytes(Data[i].Unknown31);
									ms.Write(tmp, 0, tmp.Length);
									size += (26 * 2);
								}
							}
						
							tmp = BitConverter.GetBytes(Data[i].Unknown32);
							ms.Write(tmp, 0, tmp.Length);
							tmp = BitConverter.GetBytes(Data[i].Str_size);
							ms.Write(tmp, 0, tmp.Length);
							tmp = Encoding.UTF8.GetBytes(Data[i].Str);
							ms.Write(tmp, 0, tmp.Length);

							size += 4;

							if(Data[i].Unknown2 == 0xCA || Data[i].Unknown2 == 0xCB)
							{
								tmp = BitConverter.GetBytes(Data[i].Unknown33);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown34);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown35);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown36);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown37);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown38);
								ms.Write(tmp, 0, tmp.Length);

								size += 12;
							}

							//Console.WriteLine("{0:X}\t{1}", (i + 1), qt[i].Str);
							//check_sz += 8 + qt[i].Str_size;
							//if(Data[i].Unknown2 != 0xCA && Data[i].Unknown2 != 0xCB) check_sz += 6;

							i++;

							if(Data[i - 1].Unknown2 == 0xDC)
							{
								tmp = BitConverter.GetBytes(Data[i].Unknown32);
								ms.Write(tmp, 0, tmp.Length);
								Data[i].Str = new_strs[i] + "\0";
								if(Data[i].Str.Contains("\\n")) Data[i].Str = Data[i].Str.Replace("\\n", "\n");
								else if(Data[i].Str.Contains("/n")) Data[i].Str = Data[i].Str.Replace("/n", "\n");
								tmp = Encoding.UTF8.GetBytes(Data[i].Str);
								Data[i].Str_size = (short)tmp.Length;
								tmp = BitConverter.GetBytes(Data[i].Str_size);
								ms.Write(tmp, 0, tmp.Length);
								tmp = Encoding.UTF8.GetBytes(Data[i].Str);
								ms.Write(tmp, 0, tmp.Length);

								Console.WriteLine((i) + ". " + Data[i - 1].Unknown2 + " " + Data[i - 1].Unknown32 + " " + Data[i - 1].Str_size + " " + Data[i - 1].Str);
								Console.WriteLine((i + 1) + ". " + Data[i].Unknown2 + " " + Data[i].Unknown32 + " " + Data[i].Str_size + " " + Data[i].Str);

								size += 4 + Data[i].Str_size;
								i++;
							}
							else if(Data[i - 1].Unknown2 == 0xBC || Data[i - 1].Unknown2 == 0xBD)
							{
								tmp = BitConverter.GetBytes(Data[i].Unknown32);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown33);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown34);
								ms.Write(tmp, 0, tmp.Length);
								Data[i].Str = new_strs[i] + "\0";
								if(Data[i].Str.Contains("\\n")) Data[i].Str = Data[i].Str.Replace("\\n", "\n");
								else if(Data[i].Str.Contains("/n")) Data[i].Str = Data[i].Str.Replace("/n", "\n");
								tmp = Encoding.UTF8.GetBytes(Data[i].Str);
								Data[i].Str_size = (short)tmp.Length;
								tmp = BitConverter.GetBytes(Data[i].Str_size);
								ms.Write(tmp, 0, tmp.Length);
								tmp = Encoding.UTF8.GetBytes(Data[i].Str);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown35);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown36);
								ms.Write(tmp, 0, tmp.Length);
								tmp = BitConverter.GetBytes(Data[i].Unknown37);
								ms.Write(tmp, 0, tmp.Length);

								size += 8 + 6 + Data[i].Str_size;
								i++;
							}
						}
					//}

					FileStream fs = new FileStream(InFileName, FileMode.Open);
					byte[] get_last_chunk = new byte[2];
					fs.Seek(-2, SeekOrigin.End);
					fs.Read(get_last_chunk, 0, get_last_chunk.Length);
					fs.Close();

					ms.Write(get_last_chunk, 0, get_last_chunk.Length);
					size += 2;

					tmp = ms.ToArray();
					ms.Close();

					byte[] tmp_sz = BitConverter.GetBytes(size);
					Array.Copy(tmp_sz, 0, tmp, 0, tmp_sz.Length);
					tmp_sz = null;
					get_last_chunk = null;

					File.WriteAllBytes(OutFileName, tmp);
					tmp = null;
					Data.Clear();
					new_strs = null;

					return 1;
				}

				return 0;
				}
				else return -1;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Data + " " + ex.Message);
				return -1;
			}
		}

		public static List<ClassesAndStructs.QuestTitle> GetData(string InFileName, bool ascii)
		{
			FileStream fs = new FileStream(InFileName, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			try
			{
				int size; // Get a size file
				size = br.ReadInt32();

				List<ClassesAndStructs.QuestTitle> qt = new List<ClassesAndStructs.QuestTitle>();

				int check_sz = 0;

				byte[] tmp;

				int i = 0;

				while (check_sz + 2 != size) 
				{
					if(check_sz + 2 >= size) break;
					qt.Add(new ClassesAndStructs.QuestTitle(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, ""));
					qt[i].Unknown1 = br.ReadInt16();
					qt[i].Unknown2 = br.ReadInt16();
					if(qt[i].Unknown2 != 0xCA && qt[i].Unknown2 != 0xCB)
					{
						qt[i].Unknown3 = br.ReadInt16();
						qt[i].Unknown4 = br.ReadInt16();
						qt[i].Unknown5 = br.ReadInt16();

						if(qt[i].Unknown2 == 0xBC || qt[i].Unknown2 == 0xBD)
						{
							qt[i].Unknown6 = br.ReadInt16();
							qt[i].Unknown7 = br.ReadInt16();
							qt[i].Unknown8 = br.ReadInt16();
							qt[i].Unknown9 = br.ReadInt16();
							qt[i].Unknown10 = br.ReadInt16();
							qt[i].Unknown11 = br.ReadInt16();
							qt[i].Unknown12 = br.ReadInt16();
							qt[i].Unknown13 = br.ReadInt16();
							qt[i].Unknown14 = br.ReadInt16();
							qt[i].Unknown15 = br.ReadInt16();
							qt[i].Unknown16 = br.ReadInt16();
							qt[i].Unknown17 = br.ReadInt16();
							qt[i].Unknown18 = br.ReadInt16();
							qt[i].Unknown19 = br.ReadInt16();
							qt[i].Unknown20 = br.ReadInt16();
							qt[i].Unknown21 = br.ReadInt16();
							qt[i].Unknown22 = br.ReadInt16();
							qt[i].Unknown23 = br.ReadInt16();
							qt[i].Unknown24 = br.ReadInt16();
							qt[i].Unknown25 = br.ReadInt16();
							qt[i].Unknown26 = br.ReadInt16();
							qt[i].Unknown27 = br.ReadInt16();
							qt[i].Unknown28 = br.ReadInt16();
							qt[i].Unknown29 = br.ReadInt16();
							qt[i].Unknown30 = br.ReadInt16();
							qt[i].Unknown31 = br.ReadInt16();
							check_sz += (2 * 26);
						}
					}
					qt[i].Unknown32 = br.ReadInt16();
					qt[i].Str_size = br.ReadInt16();
					tmp = br.ReadBytes(qt[i].Str_size);
					qt[i].Str = Encoding.UTF8.GetString(tmp);
					if(ascii) qt[i].Str = Encoding.ASCII.GetString(tmp);
					qt[i].Str = qt[i].Str.Remove(qt[i].Str.Length - 1, 1);
					if(qt[i].Str.Contains("\n")) qt[i].Str = qt[i].Str.Replace("\n", "\\n");
					if(qt[i].Unknown2 == 0xCA || qt[i].Unknown2 == 0xCB)
					{
						qt[i].Unknown33 = br.ReadInt16();
						qt[i].Unknown34 = br.ReadInt16();
						qt[i].Unknown35 = br.ReadInt16();
						qt[i].Unknown36 = br.ReadInt16();
						qt[i].Unknown37 = br.ReadInt16();
						qt[i].Unknown38 = br.ReadInt16();
						check_sz += 12;
					}

					//Console.WriteLine("{0:X}\t{1}", (i + 1), qt[i].Str);
					check_sz += 8 + qt[i].Str_size;
					if(qt[i].Unknown2 != 0xCA && qt[i].Unknown2 != 0xCB) check_sz += 6;

					i++;

					if(qt[i - 1].Unknown2 == 0xDC)
					{
						qt.Add(new ClassesAndStructs.QuestTitle(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, ""));
						qt[i].Unknown32 = br.ReadInt16();
						qt[i].Str_size = br.ReadInt16();
						tmp = br.ReadBytes(qt[i].Str_size);
						qt[i].Str = Encoding.UTF8.GetString(tmp);
						qt[i].Str = qt[i].Str.Remove(qt[i].Str.Length - 1, 1);
						//Console.WriteLine((i) + ". " + qt[i - 1].Unknown2 + " " + qt[i - 1].Unknown32 + " " + qt[i - 1].Str_size + " " + qt[i - 1].Str);
						//Console.WriteLine((i + 1) + ". " + qt[i].Unknown2 + " " + qt[i].Unknown32 + " " + qt[i].Str_size + " " + qt[i].Str);
						check_sz += qt[i].Str_size + 4;
						i++;
					}
					else if(qt[i - 1].Unknown2 == 0xBC || qt[i - 1].Unknown2 == 0xBD)
					{
						qt.Add(new ClassesAndStructs.QuestTitle(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, ""));
						qt[i].Unknown32 = br.ReadInt16();
						qt[i].Unknown33 = br.ReadInt16();
						qt[i].Unknown34 = br.ReadInt16();
						qt[i].Str_size = br.ReadInt16();
						tmp = br.ReadBytes(qt[i].Str_size);
						qt[i].Str = Encoding.UTF8.GetString(tmp);
						qt[i].Str = qt[i].Str.Remove(qt[i].Str.Length - 1, 1);
						if(qt[i].Str.Contains("\n")) qt[i].Str = qt[i].Str.Replace("\n", "\\n");
						qt[i].Unknown35 = br.ReadInt16();
						qt[i].Unknown36 = br.ReadInt16();
						qt[i].Unknown37 = br.ReadInt16();
						check_sz += qt[i].Str_size + 8 + 6;
						i++;
					}
				}

				br.Close();
				fs.Close();

				return qt;
			}
			catch
			{
				br.Close();
				fs.Close();

				return null;
			}
		}

		public static ClassesAndStructs.dat_struct ReadFile(string InFileName, bool isNDS)
		{
			FileStream fs = new FileStream(InFileName, FileMode.Open);
			BinaryReader br = new BinaryReader(fs);
			ClassesAndStructs.dat_struct dat = new ClassesAndStructs.dat_struct();

			int file_size = (int)fs.Length;

			if(!isNDS)
			{
				dat.index         = br.ReadInt32();
				dat.indexNDS = -1;
				dat.offsetNDS = -1;
			}
			else
			{
				dat.index = -1;
				dat.indexNDS = br.ReadInt16();
				dat.offsetNDS = br.ReadInt16();
			}

			int title_size = isNDS ? 48 : 72;

			dat.bin_title     = br.ReadBytes(title_size);
			dat.title         = isNDS ? Encoding.GetEncoding(1251).GetString(dat.bin_title).Replace("\0", string.Empty) : Encoding.UTF8.GetString(dat.bin_title).Replace("\0", string.Empty);
			dat.unknown1      = br.ReadInt16();
			dat.unknown2      = br.ReadInt16();
			dat.unknown3      = br.ReadInt16();
			dat.unknown4      = br.ReadInt16();
			dat.unknown5      = br.ReadInt16();
			dat.unknown6      = br.ReadInt16();
			dat.q_offset      = br.ReadInt32();
			dat.c_offset      = br.ReadInt32();
			dat.w_offset      = br.ReadInt32();
			dat.s1_offset     = br.ReadInt32();
			dat.s2_offset     = br.ReadInt32();
			dat.s3_offset     = br.ReadInt32();
			if (isNDS) br.BaseStream.Seek(dat.offsetNDS, SeekOrigin.Begin);
			dat.bin_question  = br.ReadBytes(dat.c_offset - dat.q_offset);
			dat.bin_correct   = br.ReadBytes(dat.w_offset - dat.c_offset);
			dat.bin_wrong     = br.ReadBytes(dat.s1_offset - dat.w_offset);
			dat.bin_solution1 = br.ReadBytes(dat.s2_offset - dat.s1_offset);
			dat.bin_solution2 = br.ReadBytes(dat.s3_offset - dat.s2_offset);
			dat.bin_solution3 = br.ReadBytes(file_size - dat.s3_offset);
			dat.question      = isNDS ? Encoding.GetEncoding(1251).GetString(dat.bin_question).Replace("\0", string.Empty) : Encoding.UTF8.GetString(dat.bin_question).Replace("\0", string.Empty);
			dat.correct       = isNDS ? Encoding.GetEncoding(1251).GetString(dat.bin_correct).Replace("\0", string.Empty) : Encoding.UTF8.GetString(dat.bin_correct).Replace("\0", string.Empty);
			dat.wrong         = isNDS ? Encoding.GetEncoding(1251).GetString(dat.bin_wrong).Replace("\0", string.Empty) : Encoding.UTF8.GetString(dat.bin_wrong).Replace("\0", string.Empty);
			dat.solution1     = isNDS ? Encoding.GetEncoding(1251).GetString(dat.bin_solution1).Replace("\0", string.Empty) : Encoding.UTF8.GetString(dat.bin_solution1).Replace("\0", string.Empty);
			dat.solution2     = isNDS ? Encoding.GetEncoding(1251).GetString(dat.bin_solution2).Replace("\0", string.Empty) : Encoding.UTF8.GetString(dat.bin_solution2).Replace("\0", string.Empty);
			dat.solution3     = isNDS ? Encoding.GetEncoding(1251).GetString(dat.bin_solution3).Replace("\0", string.Empty) : Encoding.UTF8.GetString(dat.bin_solution3).Replace("\0", string.Empty);

			br.Close();
			fs.Close();

			return dat;
		}

        //Пересылаем dat файл и список доступных текстовых файлов. Если какого-то текстового файла нет, значит, будет считаться пустая строка.
		public static int ImportDatFile(string InFileName, string[] TxtStrings, bool isNDS)
        {
            if (!File.Exists(InFileName)) return -2;

            try
            {
				ClassesAndStructs.dat_struct dat = ReadFile(InFileName, isNDS);

				FileInfo fi = new FileInfo(InFileName);
				int file_size = (int)fi.Length;

                byte[] tmp; //Временная переменная для записей
				tmp = isNDS ? Encoding.GetEncoding(1251).GetBytes(TxtStrings[0] + "\0") : Encoding.UTF8.GetBytes(TxtStrings[0] + "\0");
                if (!isNDS && tmp.Length >= 72) return 2; //Show error about to long title name length
				else if (isNDS && tmp.Length >= 48) return 2; //This message for Nintendo DS version
                dat.title = TxtStrings[0] + "\0";
                dat.bin_title = new byte[72];
				if (isNDS) dat.bin_title = new byte[48];
                Array.Copy(tmp, 0, dat.bin_title, 0, tmp.Length);
                int offset = dat.q_offset;

				tmp = isNDS ? Encoding.GetEncoding(1251).GetBytes(TxtStrings[1] + "\0") : Encoding.UTF8.GetBytes(TxtStrings[1] + "\0");
                if (offset + tmp.Length >= file_size) return 3;
                dat.question = TxtStrings[1] + "\0";
                dat.bin_question = new byte[pad(tmp.Length)];
                Array.Copy(tmp, 0, dat.bin_question, 0, tmp.Length);
                offset += dat.bin_question.Length;
                dat.c_offset = offset;

				tmp = isNDS ? Encoding.GetEncoding(1251).GetBytes(TxtStrings[2] + "\0") : Encoding.UTF8.GetBytes(TxtStrings[2] + "\0");
                if (offset + tmp.Length >= file_size) return 4;
                dat.correct = TxtStrings[2] + "\0";
                dat.bin_correct = new byte[pad(tmp.Length)];
                Array.Copy(tmp, 0, dat.bin_correct, 0, tmp.Length);
                offset += dat.bin_correct.Length;
                dat.w_offset = offset;

				tmp = isNDS ? Encoding.GetEncoding(1251).GetBytes(TxtStrings[3] + "\0") : Encoding.UTF8.GetBytes(TxtStrings[3] + "\0");
                if (offset + tmp.Length >= file_size) return 5;
                dat.wrong = TxtStrings[3] + "\0";
                dat.bin_wrong = new byte[pad(tmp.Length)];
                Array.Copy(tmp, 0, dat.bin_wrong, 0, tmp.Length);
                offset += dat.bin_wrong.Length;
                dat.s1_offset = offset;

				tmp = isNDS ? Encoding.GetEncoding(1251).GetBytes(TxtStrings[4] + "\0") : Encoding.UTF8.GetBytes(TxtStrings[4] + "\0");
                if (offset + tmp.Length >= file_size) return 6;
                dat.solution1 = TxtStrings[4] + "\0";
                dat.bin_solution1 = new byte[pad(tmp.Length)];
                Array.Copy(tmp, 0, dat.bin_solution1, 0, tmp.Length);
                offset += dat.bin_solution1.Length;
                dat.s2_offset = offset;

				tmp = isNDS ? Encoding.GetEncoding(1251).GetBytes(TxtStrings[5] + "\0") : Encoding.UTF8.GetBytes(TxtStrings[5] + "\0");
                if (offset + tmp.Length >= file_size) return 7;
                dat.solution2 = TxtStrings[5] + "\0";
                dat.bin_solution2 = new byte[pad(tmp.Length)];
                Array.Copy(tmp, 0, dat.bin_solution2, 0, tmp.Length);
                offset += dat.bin_solution2.Length;
                dat.s3_offset = offset;

				tmp = isNDS ? Encoding.GetEncoding(1251).GetBytes(TxtStrings[6] + "\0") : Encoding.UTF8.GetBytes(TxtStrings[6] + "\0");
                if (offset + tmp.Length >= file_size) return 8;
                dat.solution3 = TxtStrings[6] + "\0";
                dat.bin_solution3 = new byte[pad(tmp.Length)];
                Array.Copy(tmp, 0, dat.bin_solution3, 0, tmp.Length);
                offset += dat.bin_solution3.Length;

                if (offset >= file_size) return 9; //Вернёт с сообщение о слишком длинном блоке с задачами.

                if (File.Exists(InFileName)) File.Delete(InFileName);

                FileStream fs = new FileStream(InFileName, FileMode.CreateNew);
                BinaryWriter bw = new BinaryWriter(fs);
				if(!isNDS) bw.Write(dat.index);
				else
				{
					bw.Write(dat.indexNDS);
					bw.Write(dat.offsetNDS);
				}
                bw.Write(dat.bin_title);
                bw.Write(dat.unknown1);
                bw.Write(dat.unknown2);
                bw.Write(dat.unknown3);
                bw.Write(dat.unknown4);
                bw.Write(dat.unknown5);
                bw.Write(dat.unknown6);
                bw.Write(dat.q_offset);
                bw.Write(dat.c_offset);
                bw.Write(dat.w_offset);
                bw.Write(dat.s1_offset);
                bw.Write(dat.s2_offset);
                bw.Write(dat.s3_offset);
				if (isNDS)
				{
					int tmpOff = (int)bw.BaseStream.Position;
					tmp = new byte[dat.offsetNDS - tmpOff];
					bw.Write(tmp);
				}
                bw.Write(dat.bin_question);
                bw.Write(dat.bin_correct);
                bw.Write(dat.bin_wrong);
                bw.Write(dat.bin_solution1);
                bw.Write(dat.bin_solution2);
                bw.Write(dat.bin_solution3);
                tmp = new byte[file_size - offset];
                bw.Write(tmp);
                bw.Close();
                fs.Close();

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }

        }

		public static int ExportDatFile(string InFileName, bool isNDS)
		{
			if (!File.Exists (InFileName)) return -2;

			try
			{
				ClassesAndStructs.dat_struct dat = ReadFile(InFileName, isNDS);
				FileInfo fi = new FileInfo(InFileName);

				File.WriteAllText(fi.FullName.Remove(fi.FullName.Length - 4, 4) + "_title.txt", dat.title);
				File.WriteAllText(fi.FullName.Remove(fi.FullName.Length - 4, 4) + "_question.txt", dat.question);
				File.WriteAllText(fi.FullName.Remove(fi.FullName.Length - 4, 4) + "_correct.txt", dat.correct);
				File.WriteAllText(fi.FullName.Remove(fi.FullName.Length - 4, 4) + "_wrong.txt", dat.wrong);
				File.WriteAllText(fi.FullName.Remove(fi.FullName.Length - 4, 4) + "_solution1.txt", dat.solution1);
				File.WriteAllText(fi.FullName.Remove(fi.FullName.Length - 4, 4) + "_solution2.txt", dat.solution2);
				File.WriteAllText(fi.FullName.Remove(fi.FullName.Length - 4, 4) + "_solution3.txt", dat.solution3);

				return 1;
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
				return -1;
			}
		}

		public static int ExportFile(string InFileName, string OutFileName, bool ascii, bool Debug)
		{
			if(!File.Exists(InFileName)) return -2;

			try
			{
				List<ClassesAndStructs.QuestTitle> Data = new List<ClassesAndStructs.QuestTitle>();

				Data = GetData(InFileName, ascii);
				if(Data != null)
				{
				string result = "";

				for(int i = 0; i < Data.Count; i++)
				{
					result += Data[i].Str;
						if(Debug) { 
							result += "\t" + Data[i].Str_size + " " + Data[i].Unknown1 + " " + Data[i].Unknown2 + " " + Data[i].Unknown3;
							result +=  " " + Data[i].Unknown4 + " " + Data[i].Unknown5 + " " + Data[i].Unknown6;
							result +=  " " + Data[i].Unknown7 + " " + Data[i].Unknown8 + " " + Data[i].Unknown9;
							result +=  " " + Data[i].Unknown10 + " " + Data[i].Unknown11 + " " + Data[i].Unknown12;
							result +=  " " + Data[i].Unknown13 + " " + Data[i].Unknown14 + " " + Data[i].Unknown15;
							result +=  " " + Data[i].Unknown16 + " " + Data[i].Unknown17 + " " + Data[i].Unknown18;
							result +=  " " + Data[i].Unknown19 + " " + Data[i].Unknown20 + " " + Data[i].Unknown21;
							result +=  " " + Data[i].Unknown22 + " " + Data[i].Unknown23 + " " + Data[i].Unknown24;
							result +=  " " + Data[i].Unknown25 + " " + Data[i].Unknown26 + " " + Data[i].Unknown27;
							result +=  " " + Data[i].Unknown28 + " " + Data[i].Unknown29 + " " + Data[i].Unknown30;
							result +=  " " + Data[i].Unknown31 + " " + Data[i].Unknown32 + " " + Data[i].Unknown33;
							result +=  " " + Data[i].Unknown34 + " " + Data[i].Unknown35 + " " + Data[i].Unknown36;
							result +=  " " + Data[i].Unknown37 + " " + Data[i].Unknown38 + " " + Data[i].Unknown39;
							result +=  " " + Data[i].Unknown40;
						}
					if(i + 1 < Data.Count) result += "\r\n";
				}

				File.WriteAllText(OutFileName, result, Encoding.UTF8);
				result = "";
				Data.Clear();

				return 1;
				}
				else return -1;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Data + " " + ex.Message);
				return -1;
			}
		}

		public static int replace(string OrigDir, string TranslateDir, string FileName)
		{
			DirectoryInfo orDI = new DirectoryInfo(OrigDir);
			DirectoryInfo translateDI = new DirectoryInfo(TranslateDir);
			FileInfo[] orFI = orDI.GetFiles("*.txt", SearchOption.AllDirectories);
			FileInfo[] translateFI = translateDI.GetFiles("*.txt", SearchOption.AllDirectories);

			string[] FullText = File.ReadAllLines(FileName);

			bool mod = false;

			if ((FullText.Length > 0) && (orFI.Length > 0) && (translateFI.Length > 0))
			{
				try
				{
				string[] ortexts, translatetexts;

				List<string> txts = new List<string>();
				string tmp_str = "";

				for (int i = 0; i < orFI.Length; i++) 
				{
					FileStream fs = new FileStream(orFI[i].FullName, FileMode.Open);
					StreamReader sr = new StreamReader(fs);
					tmp_str = sr.ReadToEnd();
					sr.Close();
					fs.Close();

					txts.Add(tmp_str);
					tmp_str = "";
				}

				ortexts = txts.ToArray();
				txts.Clear();

				for (int i = 0; i < translateFI.Length; i++) 
				{
					FileStream fs = new FileStream(translateFI[i].FullName, FileMode.Open);
					StreamReader sr = new StreamReader(fs);
					tmp_str = sr.ReadToEnd();
					sr.Close();
					fs.Close();

					txts.Add(tmp_str);
					tmp_str = "";
				}

				translatetexts = txts.ToArray();
				txts.Clear();

				if(ortexts.Length == translatetexts.Length)
				{
					mod = false;
					for (int i = 0; i < FullText.Length; i++)
					{
						for (int j = 0; j < ortexts.Length; j++)
						{
							if (FullText[i] == ortexts[j])
							{
								tmp_str = FullText[i];
								FullText[i] = translatetexts[j];

									if((tmp_str[tmp_str.Length - 1] != FullText[i][FullText[i].Length - 1])
										&& FullText[i][FullText[i].Length - 1] == '\n') FullText[i] = FullText[i].Remove(FullText[i].Length - 1, 1);

									if (!mod) mod = true;
								break;
							}
						}
					}
				}

				if (mod)
				{
						tmp_str = "";

						for(int k = 0; k < FullText.Length; k++)
						{
							tmp_str += FullText[k];
							if(k + 1 < FullText.Length) tmp_str += "\r\n";
						}

						File.WriteAllText(FileName, tmp_str, Encoding.UTF8);

					FullText = null;
					ortexts = null;
					translatetexts = null;
					tmp_str = null;

					return 1;
				}

				FullText = null;
				ortexts = null;
				translatetexts = null;
				tmp_str = null;

				return 0;
				}
				catch
				{
					return -1;
				}
			}

			return -2;
		}
	}
}


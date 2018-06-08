using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Text;

namespace SandboxCLI.Help{
	public static class Helper{
		FileStream stream;
		public StringBuilder builder = new StringBuilder();
		public static string GetFileInfo(string filename){
			using(stream = new FileStream(filename, FileMode.Open)){
				byte[] buffer = new byte[];
				UTF8Encoding temp = new UTF8Encoding(true);
				while(stream.Read(buffer, 0, buffer.Length)){
					builder.Append(buffer.GetString());
				}
			}
		}
	}
}
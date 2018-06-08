using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SandboxedCLI.FileHandler{
	public static class FileHandler{
		byte[] buffer = new byte[4096];
		FileStream stream;
		BufferStream bufferstream;
		
		public static string ReadFile(string filename){
			using(stream = new FileStream(filename, FileMode.Open))
			using(bufferstream = new BufferStream(stream))
				while((bufferstream.Read(buffer, 0, buffer.Length)) > 0){
					
				}
		}
	}
}
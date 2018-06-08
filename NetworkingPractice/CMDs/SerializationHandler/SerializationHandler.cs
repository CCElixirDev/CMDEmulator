using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SandboxedCLI.Serialization {
	public static class SerializationHandler{
		static FileStream fs;
		public static void Serialize<T>(string filename, T objectToSerialize){
			fs = new FileStream(filename, FileMode.Create);
			
			BinaryFormatter formatter = new BinaryFormatter();
			try
			{
				formatter.Serialize(fs, objectToSerialize);
			}
			catch(SerializationException e)
			{
				throw;
			}
			catch
			{
				fs.Close();
			}
		}
		
		public static T Deserialize<T>(string fileName) where T : new(){
            fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
			T retObj = new T();
			try
			{
				retObj = (T)formatter.Deserialize(fs);
			}
			catch(SerializationException ex)
			{
				throw;
			}
			finally
			{
				fs.Close();
			}
			return retObj;
		}
	}
}
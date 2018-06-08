using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Net;
using SandboxedCLI.Serialization;

namespace SandboxedCLI.Settings {
	
	public class Settings{
		private bool ipRegistered = true;
		private DateTime ipLeaseEnd;
		private TimeSpan leaseTiming = new TimeSpan(182, 0, 0, 0);
		private bool connectedToDHCPServer = true;
		private IPAddress ipAddress;
		private string _MACAddress;
		private StringBuilder builder;
		
		public Setings(){
			byte[] buffer = new byte[4096];
			using(var fs = new FileStream(@"\data\config", FileMode.Open)){
				var utf8enc = new UTF8Encoding();
				while(fs.Read(buffer, 0, buffer.Length) > 0){
					builder.Append(utf8enc.GetString(buffer));
				}
			}
			var values = ParseSettings(builder.ToString());
			this.ipAddress = values.ipAddress;
			this.ipLeaseEnd = values.ipLeaseEnd;
			this._MACAddress = values._MACAddress;
		}
		
		private Settings ParseSettings(string configSettings){
			var tokens = configSettings.Split();
			Settings tempSettings;
			foreach(var token in tokens){
				var directtoken = token.Split(':');
				switch(directtoken[0]){
					case "LocalIP":
						tempSettings.ipAddress = directtoken[1];
					case "LeaseEndDate":
						tempSettings.ipLeaseEnd = DateTime.TryParse(directtoken[1]);
					case "MACAddress":
						tempSettings._MACAddress = directtoken[1];
				}
				
			}
			return tempSettings;
		}
		
		private Settings SerializeSettings(){
			SerializationHandler.Serialize("");
		}
		
		public Settings(DateTime ipLeaseEnd, bool connectedToDHCPServer, IPAddress currentIp, string mac){
			this.ipLeaseEnd = ipLeaseEnd;
			this.connectedToDHCPServer = connectedToDHCPServer;
			ipAddress = currentIp;
			_MACAddress = mac;
		}
		
		public void ReleaseIP(){
			ipRegistered = false;
			ipLeaseEnd = DateTime.Now.Add(leaseTiming);
		}
		
		public void UpdateConfiguration(string configurationFile){
			
		}
		
		public void ResetConfigToDefault(){
			
		}
	}
}
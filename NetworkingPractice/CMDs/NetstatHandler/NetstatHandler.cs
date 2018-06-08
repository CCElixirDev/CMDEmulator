using System;
using System.Collections;
using System.Regex;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using SandboxedCLI.Help;

public namespace SandboxedCLI{
public class NetstatHandler{
		Helper help = new Helper();
		
		public enum netstatArgument{
			None,
			ActiveConnections,
			Executables,
			ProtocolType,
			Ethernet,
			FQDN,
			Numerical,
			PCID,
			Routing,
			Statistics,
			Offload,
			Interval
		}
		
		private netstatArgument curentType;
		
		public void NetParseArguments(string[] arguments){
			var tokens = arguments.Split();
			switch(tokens[0]){
				case "help":
					Console.WriteLine(help.GetFileInfo("netstat.txt"));
					break;
				case "-a":
					curentType = netstatArgument.ActiveConnections;
					break;
				case "-b":
					currentType = netstatArgument.Executables;
					break;
				case "-e":
					currentType = netstatArgument.Ethernet;
					break;
				case "-f":
					currentType = netstatArgument.FQDN;
					break;
				case "-n":
					currentType = netstatArgument.Numerical;
					break;
				case "-o":
					currentType = netstatArgument.PCID;
					break;
				case "-p":
					currentType = netstatArgument.ProtocolType;
					break;
				case "-r":
					currentType = netstatArgument.Routing;
					break;
				case "-s":
					currentType = netstatArgument.Statistics;
					break;
				case "-t":
					currentType = netstatArgument.Offload;
					break;
				case "interval":
					currentType = netstatArgument.Interval;
					break;
			}
			
			ExecuteNetstatCmd((currentType != netstatArgument.None));
		}
		
		public void ExecuteNetstatCmd(bool argument){
			var props = IPGlobalProperties.GetIPGlobalProperties();
			var endPoints = props.GetActiveTcpListeners();
			if(!argument){
			foreach(endPoints in props){
				Console.WriteLine(String.Format("{0}{1}{2}\n", endPoints.Address, endPoints.Ports, endPoints.AddressFamily));
			}
			}
			else(){
				
			}
		}
	}
}

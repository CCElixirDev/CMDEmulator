using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Sysetm.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace SandboxedCLI.Command{
	public enum CurrentState {
		None,
		Executing,
		Paused,
		Leaving
	}
	public Settings settings;
	public CurrentState currentState;
	public class CommandExecuter{
		currentState = currentState.None;
	}
	
	public void BeginPing(int amount, int packetSize){
		var pinger = new Ping();
	}
	public void BeginIpConfig(bool all = false){
		var info = GetCurrentInfo();
	}
	public string GetCurrentInfo(){
		settings = new Settings();
	}
	public void BeginTraceRoute(){
		
	}
	public void BeginPathPing(){
		
	}
	public void BeginNslookup(){
		
	}
	public void BeginFTP(){
		
	}
	public void BeginTelnet(){
		
	}
	public void BeginArp(){
		
	}
	public void BeginNbtstat(){
		
	}
	public void BeginNetsh(){
		
	}
	public void GetMac(){
		
	}
}
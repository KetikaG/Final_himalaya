﻿import System;
import System.IO;

private var fileFolder : String = "C:/Users/ketik/Desktop/";
private var fileName: String = "test_record_fixed_x.txt";
private var saveString : String;
//private var 
//anything to mark the end of recording---energy bar over 
var paused : boolean = false; 

static function SaveTextFile ( fileName : String, fileContent : String ) {
   var sw : StreamWriter = new StreamWriter ( fileName );
   sw.Write ( fileContent );
   sw.Close ();
   print ( "Saved " + fileName );
}


function FixedUpdate() 
{
	
	
		// var cam = GameObject.Find("MainCamera").GetComponent(Transform);

		//add time since program start and position and rotation of the recorded object to the string
		var objPos = Time.time + "," + transform.localRotation.eulerAngles;
			
		//keep adding a new line with information for each save
		
		

		saveString = saveString + "\n" + "+" + objPos;
			
	 if(Input.GetKeyDown("p"))
	{
		 paused = !paused ;
			//Time.timeScale = paused ? 0 : 1 ;

			SaveTextFile(fileFolder+fileName, saveString);
	}
}
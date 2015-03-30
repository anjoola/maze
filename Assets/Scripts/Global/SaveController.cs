using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveController {
	private static string SAVEFILE = "/save.gd";

	// Saves the current game.
	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + SAVEFILE);
		bf.Serialize(file, MainUIController.CurrentGame);
		file.Close(); 
	}
	// Loads an existing game or creates a new file if one doesn't exist.
	public static void Load() {
		MainUIController.CurrentGame = new Game();
		return;
		// TODO remove above
		try {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + SAVEFILE, FileMode.Open);
			MainUIController.CurrentGame = (Game)bf.Deserialize(file);
			file.Close();
		} catch (System.SystemException) {
			// Otherwise, create a new game save.
			MainUIController.CurrentGame = new Game();
		}
	}
}

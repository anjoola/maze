using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveController {
	static string SAVE_FILE = "/savefile.gd";
	
	/**
	 * Saves the current game.
	 */
	public static void SaveGame() {
		return;
		// TODO
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + SAVE_FILE);
		bf.Serialize(file, MainController.CurrentGame);
		file.Close(); 
	}

	/**
	 * Loads an existing game or creates a new file if one doesn't exist.
	 */
	public static void LoadGame() {
		// TODO remove
		MainController.CurrentGame = new Game();
		return;
		//

		// Try to load existing game.
		try {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + SAVE_FILE, FileMode.Open);
			MainController.CurrentGame = (Game) bf.Deserialize(file);
			file.Close();
		}
		// Otherwise, create a new game save.
		catch (System.SystemException) {
			MainController.CurrentGame = new Game();
		}
	}
}

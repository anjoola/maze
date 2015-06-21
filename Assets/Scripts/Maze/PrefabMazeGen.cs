using System;
using UnityEngine;

/**
 * Generates a maze using Prefabs. Need to add all the potential maze blocks to the MazeBlocks list and set the Size.
 * The MazeBlocks list size must be Size x Size.
 */
public class PrefabMazeGen : MonoBehaviour {
	PrefabMazeGenerator Gen;

	// Size of one side of the maze. (e.g. an 11 x 11 maze would have Size = 11).
	public int Size;
	public GameObject[] MazeBlocks;

	public class PrefabMazeGenerator : MazeGenerator {
		public GameObject[] MazeBlocks;

		public PrefabMazeGenerator(GameObject[] blocks, int size) : base(size) {
			MazeBlocks = blocks;
		}

		override public void CellTypeChangedCallback(int row, int col, bool toWall) {
			if (!toWall && this.MazeBlocks[row * this.Size + col] != null) {
				this.MazeBlocks[row * this.Size + col].SetActive(false);
			}
		}
	}

	void Start() {
		Gen = new PrefabMazeGenerator(MazeBlocks, Size);
		Gen.GenerateMaze();
	}
}

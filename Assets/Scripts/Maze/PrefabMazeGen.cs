using System;
using UnityEngine;

public class PrefabMazeGen : MonoBehaviour {
	PrefabMazeGenerator Gen;
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
		Gen = new PrefabMazeGenerator(MazeBlocks, 11);
		Gen.GenerateMaze();
	}
}

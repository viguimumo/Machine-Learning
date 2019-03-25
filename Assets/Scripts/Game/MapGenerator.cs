using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public GameObject tile;
	public int x, z;

	private GameObject[,] visualMap;
	private int[,] tileMap;

	void Awake(){
		buildTileMap ();
		buildVisualMap ();
	}

	public int[,] TileMap () { return tileMap; }
	public GameObject[,] VisualMap () { return visualMap; }

	private void buildTileMap(){
		tileMap = new int[x, z];

		for (int i = 0; i < x; i++) {
			for (int j = 0; j < z; j++) {
				tileMap [i, j] = 1;
			}
		}
	}

	private void buildVisualMap(){
		visualMap = new GameObject[x, z];

		for (int i = 0; i < x; i++) {
			for (int j = 0; j < z; j++) {

				GameObject newTile = Instantiate (tile);
				newTile.transform.SetParent (gameObject.transform);
				visualMap [i, j] = newTile;

				newTile.transform.position = new Vector3 (
					i*newTile.transform.localScale.x, 
					0f, 
					j*newTile.transform.localScale.z
				);
			}
		} 
		Destroy (tile);
	}
}

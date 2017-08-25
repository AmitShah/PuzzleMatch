using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	Board board;
	// Use this for initialization
	void Start () {
		board = new Board ();
//		for (int i = 0; i < Board.BOARD_WIDTH; i++) {
//			for (int j = 0; j < 6; j++) {
//				Board.Tile tile = board._tiles [i,j];
//
//				var cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
//				cube.transform.position = new Vector3 (i, j, 2);
//				cube.GetComponent<Renderer> ().material.color = Color.grey;
//				if(tile.b != null)
//					cube.GetComponent<Renderer> ().material.color = convertColor(tile.b._color);
//				
//			}
//		}
	}

//	Color convertColor(Block.BlockColor c){
//		switch (c) {
//			case Block.BlockColor.RED:
//				return Color.red;
//			case Block.BlockColor.BLUE:
//				return Color.blue;
//			case Block.BlockColor.GREEN:
//				return Color.green;
//			case Block.BlockColor.ORANGE:
//				return Color.magenta;
//			case Block.BlockColor.YELLOW:
//				return Color.yellow;
//			default:
//				return Color.grey;
//		}
//	}
	// Update is called once per frame
	void Update () {
		
	}
}

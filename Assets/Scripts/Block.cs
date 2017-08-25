using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block {

	public enum BlockColor{
		RED,ORANGE,YELLOW,BLUE,GREEN,COUNT
	}

	public enum BlockState {
		NORMAL, FLOATING, MATCHED, EXPLODING, SWAPPING_LEFT, SWAPPING_RIGHT
	};

	public BlockState _state;
	public BlockColor _color;
	GameObject go;

	public Block(){
		//TODO make this whatever effing gem style you want, lets get the core mechanics done
		go = GameObject.CreatePrimitive (PrimitiveType.Cube);

	}


	public void setColor(BlockColor color){
		_color = color;
		go.GetComponent<Renderer> ().material.color = convertColor(_color);
	}

	public void setState(BlockState state){
		_state = state;
	}

	public void setPosition(Vector3 pos){
		go.transform.position = pos;
	}

	public static BlockColor getRandomColor(List<int> color){

		var rand = Random.Range (0, color.Count);
		return (BlockColor)color [rand];
	}


	static Color convertColor(Block.BlockColor c){
		switch (c) {
		case Block.BlockColor.RED:
			return Color.red;
		case Block.BlockColor.BLUE:
			return Color.blue;
		case Block.BlockColor.GREEN:
			return Color.green;
		case Block.BlockColor.ORANGE:
			return Color.magenta;
		case Block.BlockColor.YELLOW:
			return Color.yellow;
		default:
			return Color.grey;
		}
	}
}

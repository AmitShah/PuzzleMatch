using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board  {

	public enum TileType{
		AIR,BLOCK,GARBAGE,COUNT
	}



	public enum BoardState {
		RUNNING, COUNTDOWN, WON, GAME_OVER
	};

	public struct Tile{
		public TileType type;
		public Block b;
		//we dont have  a garabge block concept at the moment
	}

	public const float Z_INDEX = 2f;
	public const int BASE_EXPLOSION_TICKS = 61;
	public const int ADD_EXPL_TICKS = 9; //the total explosion time for a combo is 61 + 9 * n, where n is the  number of blocks
	public const int SWAP_DELAY = 3;
	public const int BOARD_HEIGHT = 24;
	public const int TOP_ROW = 11;
	public const int BOARD_WIDTH = 6;
	public const int PANIC_HEIGHT = 9;
	public const int WARN_HEIGHT = 10;
	public const int FLOAT_TICKS = 12;
	public const int STACK_RAISE_STEPS = 32;
	public const int COUNTDOWN_MS = 3000;

	public Tile[,] _tiles = new Tile[BOARD_WIDTH,BOARD_HEIGHT];
	public Tile[] _bufferRow = new Tile[BOARD_WIDTH];
	public BoardBitState[] colorState;

	public Board(){
		fillRandom();
		fillBufferRow();
		colorState = new BoardBitState[(int)Block.BlockColor.COUNT]; 
		for (int s = 0; s < (int)Block.BlockColor.COUNT+1; s++) {
			colorState [s] = new BoardBitState (BOARD_HEIGHT, BOARD_WIDTH);
		}

	}


	public void SetTri(Block.BlockColor color, int row, int column,int rotation){
		colorState [(int)color].setBit (true, row, column); 
	}
	public void Compress(){
		
	}

	private void findHoles(){
		int[] moveColumn = new int[BOARD_WIDTH];
		var blockState = colorState [colorState.Length - 1];
		for (int i = 0; i < BOARD_HEIGHT; i++) {
			
		}

	}

	private LinkedList<int> currentSolutions = new LinkedList<int>();
	private void findRectangles(){
		for (int c = 0; c < (int)Block.BlockColor.COUNT; c++) {
			BoardBitState b = colorState [(int)c];
			int[] result = new int[BOARD_WIDTH];
			var currentRow = b.getRow (0);
			for (int i = 0; i < BOARD_HEIGHT; i++) {
				currentRow.And(b.getRow (i));
			} 
		}
	}

	public void fillRandom(){
		
		for(int i = 0 ; i <BOARD_WIDTH; i++){
			for (int j = 0; j < BOARD_HEIGHT; j++) {
				_tiles [i,j] = new Tile () {
					type = TileType.BLOCK,
					b = new Block()
				};
				//reinit color array
				List<int> colors = new List<int>();
				for (int k = 0; k < (int)Block.BlockColor.COUNT; k++) {
					colors.Add(k);
				}
				if (j-1 >=0){// && _tiles[i,j - 2].b._color == _tiles[i,j - 1].b._color) {
					colors.Remove((int)_tiles[i,j - 1].b._color);
				}
				if (i - 1 >= 0){// && _tiles[i - 2,j].b._color == _tiles[i - 1,j].b._color) {
					colors.Remove((int)_tiles[i - 1,j].b._color);
				}

				_tiles [i, j].b.setColor(Block.getRandomColor (colors));
				_tiles [i, j].b.setPosition (new Vector3(i, j, Z_INDEX));
				
			}
		}
	}

	public void fillBufferRow() {
		for (int i = 0; i < BOARD_WIDTH; i++) {
			_bufferRow[i].type = TileType.BLOCK;
			_bufferRow [i].b = new Block ();
			List<int> colors = new List<int>();
			for (int k = 0; k < (int)Block.BlockColor.COUNT; k++) {
				colors.Add(k);
			}
			colors.Remove((int)_tiles[0,i].b._color);
			if (i - 1 > 0) {
				colors.Remove ((int)_bufferRow [i - 1].b._color);
			}

			_bufferRow[i].b._color = Block.getRandomColor(colors);
		}
	}



	public bool isSwappable(int row,int col){

		return false;
	}


	public void generateBoard(){
	
	}

	public bool swap(int row, int col){
		return false;
	}

	public void matchBlocks(){
	
	}

	public void handleMatchBlocks(){
		
	}


	void checkRectangles(){


	}

	void createRectangle(){
		
	}

	//lets try wario style and randomly generate color patterns in a uniform distrubtion
	int[] _randomColorQueue = new int[128];



	void GeneratePieces(){
		int size = _randomColorQueue.Length;
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < 3; j++) {
				var block = new Block ();
				block.setColor(
					(Block.BlockColor)Random.Range (0, 4));
				
			}	
		}
	}

	public void UpdateBoardState(){
		
	}


//	void initTick();
//	void fillRandom();
//	void fillBufferRow();
//	bool activeBlocks();
//	void matchBlocks();
//	void handleGarbageQueue();
//	void handleMatchedBlocks();
//	void handleTriggeredBlocks();
//	void handleBlockTimers();
//	void swapBlocks(int, int);
//	void clearTile(Tile&);
//	void setChainAbove(int, int);
//	void handleFalling();
//	void handleGarbageFalling();
//	void triggerNeighbors(int, int);
//	void triggerGarbageNeighbors(GarbageBlock&, Tile&);
//	void triggerTile(int, int, Tile&);
//	void raiseStack();
//	bool matchTiles(int, int, int, int);
//	bool blockCanFall(int, int);
//	bool blockOnRow(int);
//	bool garbageBlockCanFall(GarbageBlock&);
//	bool swappable(int, int);
//	bool spawnGarbage(int, int, int, int, GarbageBlockType);
//	void sendEvents();
//	void chainScoring();
//	void comboScoring();




	public void CompressBoard(){
		//1.find holes
		//2. tell all cubes to move in column


	}



	public class BoardBitState{
		BitArray[] _state;
		System.UInt64[] _colorStates;
		int height;
		int width;
		public BoardBitState(int rows,int columns){
			height = rows;
			width = columns;
			_state = new BitArray[height];
			for(int i = 0; i < height; i++){
				_state[i] = new BitArray(width);
				_state[i].SetAll(false);
			}

		}

		//returns a bitarray for the column state
		public BitArray getColumn (int columnIndex){
			BitArray resultColumn = new BitArray (height);
			for (int j = 0; j < height; j++) {
				resultColumn.Set(j,_state [j].Get (columnIndex));
			}
			return resultColumn;
		}

		//returns a bitarray for the column state
		public BitArray getRow (int rowIndex){
			BitArray r = (BitArray)_state [rowIndex].Clone ();
			return r;
		}

		public void setBit(bool value, int row, int column){
			_state [row].Set (column, value);
		}

		public void setRow(bool value, int rowIndex){
			_state [rowIndex].SetAll (value);
		}

		public void setColumn(bool value, int columnIndex){
			for (int i = 0; i < height; i++) {
				_state [i].Set (columnIndex, value);
			}
		}

		public void getBit(int row, int column){
			_state [row].Get (column);
		}






		public void GenerateColumnMask(){
			int columns = 6;
			int rows = 10;
			ulong[] result = new ulong[columns];
			for(int c =0; c < columns; c++){
				for(int i=0; i < 10; i ++){
					var col = (63 - c) -i*6;
					result[c]+=(ulong)Mathf.Pow(2,col); 
				}
			}
			for(int c =0; c < columns; c++){
				//Console.WriteLine(result[c]);
			}
		}


	}

}

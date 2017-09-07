using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class RectangleSystem : MonoBehaviour
{

	List<Rect> rectangles;
	List<Rect> buffer;
	private const bool USE_RANGE = false;
	Dictionary<Block.BlockColor,int[][]> state = new Dictionary<Block.BlockColor, int[][]>();


	int[][] A = new int[R][];

	public void Start(){
		
		for (var i = 0; i < (int)Block.BlockColor.COUNT; i++) {
			state [(Block.BlockColor)i] = new int[R][];
		}

		A = new int[R] [];
		//		A [0] = new int[]{ 0, 0, 0, 1, 1, 1 };//,
		//		A [1] =  new int[]{ 0, 0, 0, 1, 1, 0 };//,
		//		A [2] =  new int[]{ 0, 0, 0, 1, 0, 0 };//,
		//		A [3] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		//		A [4] = new int[]   {0, 1,1, 1,1,0 };//,
		//		A [5] = new int[]	{0, 1,1, 1,1,0};
		//		A [6] = new int[]	{0, 1,1, 1,0,0};
		//		A [7] = new int[]	{0, 1,1, 0,1,1};
		//		A [8] = new int[]	{0, 1,1, 0,1,1};


		A = new int[R] [];
		//		A [0] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
		//		A [1] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		//		A [2] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		//		A [3] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		//		A [4] = new int[]   {1, 1,0, 0,1,1 };//,
		//		A [5] = new int[]	{1, 1,0, 0,1,1};
		//		A [6] = new int[]	{1, 1,1, 1,1,1};
		//		A [7] = new int[]	{1, 1,1, 1,1,1};
		//		A [8] = new int[]	{0, 0,0, 0,0,0};

		//		A [0] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
		//		A [1] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		//		A [2] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		//		A [3] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		//		A [4] = new int[]   {0, 0,0, 0,0,0 };//,
		//		A [5] = new int[]{ 0, 0, 0, 0, 0, 0 };
		//		A [6] = new int[]{ 0, 0, 0, 0, 0, 0 };
		//		A [7] = new int[]{ 0, 0, 0, 0, 0, 0 };
		//		A [8] = new int[]	{0, 0,0, 0,0,0};

		rectangles = new List<Rect>();

		buffer = new List<Rect> ();


//		A [0] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
//		A [1] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
//		A [2] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
//		A [3] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
//		A [4] = new int[]   {0, 0,0, 0,0,0 };//,
//		A [5] = new int[]   { 0, 0, 0, 0, 1, 1 };
//		A [6] = new int[]   { 0, 0, 0, 0, 1, 1 };
//		A [7] = new int[]   { 1, 1, 0, 0, 1, 1 };
//		A [8] = new int[]	{ 1, 1, 0, 0, 1, 1 };
//		maxRectangle (A);
//		_GrowRectangles ();
//		rectangles = buffer;

		buffer = new List<Rect>();

		A [0] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
		A [1] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		A [2] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		A [3] =  new int[]  { 0, 0, 0, 0, 0, 0 };//,
		A [4] = new int[]   { 0, 0, 0, 0, 0, 0 };//,
		A [5] = new int[]   { 0, 0, 0, 0, 0, 0 };
		A [6] = new int[]   { 0, 0, 0, 0, 0, 0 };
		A [7] = new int[]   { 0, 0, 1, 1, 1, 0 };
		A [8] = new int[]	{ 0, 0, 1, 1, 1, 0 };
		maxRectangle (A);
		foreach (Rect b in buffer) {
			foreach (Rect r in rectangles) {
				b.Enclose (r);
			}
		}
		rectangles = buffer;

		rectangles.RemoveAt (0);
		buffer = new List<Rect> ();
		A [0] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
		A [1] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		A [2] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		A [3] =  new int[]  { 0, 0, 0, 0, 0, 0 };//,
		A [4] = new int[]   { 0, 0, 0, 0, 0, 0 };//,
		A [5] = new int[]   { 0, 0, 0, 1, 1, 0 };
		A [6] = new int[]   { 0, 0, 1, 1, 1, 0 };
		A [7] = new int[]   { 0, 0, 1, 1, 1, 1 };
		A [8] = new int[]	{ 0, 0, 1, 1, 1, 1 };
		maxRectangle (A);
		foreach (Rect b in buffer) {
			foreach (Rect r in rectangles) {
				b.Enclose (r);
			}
		}
		buffer = new List<Rect>();

//		for (int i = 0; i < 10; i++) {
//			buffer.Clear ();
//			temp.Start ();
//			maxRectangle (A);
//			temp.Stop ();
//			Debug.Log (string.Format ("TICKS {0}, MS: {1}", temp.ElapsedTicks, temp.ElapsedMilliseconds));
//		}
		//_GrowRectangles ();

//		A [0] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
//		A [1] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
//		A [2] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
//		A [3] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
//		A [4] = new int[]   {0, 0,0, 0,0,0 };//,
//		A [5] = new int[]   { 0, 1, 1, 0, 1, 1 };
//		A [6] = new int[]   { 0, 1, 1, 0, 1, 1 };
//		A [7] = new int[]   { 1, 1, 1, 1, 1, 1 };
//		A [8] = new int[]	{ 1, 1, 1, 1, 1, 1 };
//		rectangles = new List<Rect>();
//		buffer = new List<Rect> ();

	}

	public int swap = 0;
	public void Update(){
		if(Input.GetKeyDown(KeyCode.U)){
			swap++;
			if (swap % 2 == 0) {
				A [0] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
				A [1] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
				A [2] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
				A [3] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
				A [4] = new int[]   { 0, 0, 0, 0, 0, 0 };//,
				A [5] = new int[]   { 0, 0, 0, 0, 1, 1 };
				A [6] = new int[]   { 0, 0, 0, 0, 1, 1 };
				A [7] = new int[]   { 1, 1, 0, 0, 1, 1 };
				A [8] = new int[]	{ 1, 1, 0, 0, 1, 1 };
			} else {

				A [0] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
				A [1] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
				A [2] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
				A [3] =  new int[]  { 0, 0, 0, 0, 1, 0 };//,
				A [4] = new int[]   { 0, 0, 0, 0, 1, 1 };//,
				A [5] = new int[]   { 0, 0, 0, 0, 1, 1 };
				A [6] = new int[]   { 0, 0, 0, 0, 1, 1 };
				A [7] = new int[]   { 0, 1, 1, 1, 1, 1 };
				A [8] = new int[]	{ 0, 1, 1, 1, 1, 1 };
			}
			var temp = System.Diagnostics.Stopwatch.StartNew ();
			buffer.Clear ();
			temp.Start ();
			maxRectangle (A);

			temp.Stop ();
			Debug.Log (string.Format ("TICKS {0}, MS: {1}", temp.ElapsedTicks, temp.ElapsedMilliseconds));

			temp.Start ();
			_GrowRectangles ();

			temp.Stop ();
			Debug.Log (string.Format ("TICKS {0}, MS: {1}", temp.ElapsedTicks, temp.ElapsedMilliseconds));


		}
	}

	public void FixedUpdate(){

		//find all rects,

		//remove all enclosing rects

		//remove all subset rects
	
//		rectangles.Clear ();
//		buffer.Clear ();
//
//		var temp = System.Diagnostics.Stopwatch.StartNew ();
//		temp.Start ();
//		//int[]  c = ;
//		var r = maxRectangle (A);
//		temp.Stop ();
//
//		Debug.Log( string.Format("TICKS {0}", temp.ElapsedTicks));
//		Debug.Log (Time.fixedDeltaTime);
//		Debug.Log (rectangles.Count);
//
//		temp.Start ();
//		//int[]  c = ;
//		_GrowRectangles();
//		temp.Stop ();
//
//		Debug.Log( string.Format("TICKS {0}", temp.ElapsedTicks));
//

	}

	void updateStateRectangle(int row, int column, Block.BlockColor color){
		var propogate_val = -1;
		for (var i = row; i < R; i++) {
			var val = state [color] [i-1] [column];

			if (state [color] [i][column] > 0) { 
				if (propogate_val > 0) {
					state [color] [i] [column] += propogate_val;
					propogate_val = -1;
				} else {
				state [color] [i] [column] += val;
				}
			} else if (state [color] [i][column] < 0 && propogate_val < 0) {
				propogate_val = val;
				continue;
			}

		}
	}

	const int R = 9;
	const int C = 6;
	// Returns area of the largest rectangle with all 1s in A[][]
	int maxRectangle(int[][] A)
	{
		// Calculate area for first row and initialize it as
		// result
		int result = maxHist(A[0],0);

		//lets update the matrix with the rectangles in the buffer
		//Recall A[height][width] i.e. A[9][6]
		foreach(Rect r in rectangles){
			Debug.Log (r);
			for(int w = 0; w< r.width; w++){
				//everything above the height of the rectangle will be 0, only
				//the last row of a rectangle will have the full height to it
				for(int h =0; h < r.height; h++){
					A  [(int)r.y + h][(int)r.x + w] = 0;
				}
				A [(int)r.y + (int)r.height - 1][(int)r.x + w]  = (int)r.height;
			}
		}
		RectangleSystemExtensionMethods.DebugLogMatrix (A);
		// iterate over row to find maximum rectangular area
		// considering each row as histogram

		for (int i = 1; i < R; i++)
		{

			for (int j = 0; j < C; j++)

			// if A[i][j] is 1 then add A[i -1][j]
				if (A [i] [j] == 1) { 
					A [i] [j] += A [i - 1] [j];
				} else if (A [i] [j] > 1) {
					A [i] [j] += A [i - A [i] [j]] [j];
				}

			// Update result if area with current row (as last row)
			// of rectangle) is more
			result = Mathf.Max(result, maxHist(A[i],i));
		}

		RectangleSystemExtensionMethods.DebugLogMatrix (A);
		//UniqueRects ();
		return result;
	}

	public int maxHist(int[] row, int heightIndex)
	{
		// Create an empty stack. The stack holds indexes of
		// hist[] array/ The bars stored in stack are always
		// in increasing order of their heights.
		Stack<int> result = new Stack<int>();


		int top_val;     // Top of stack

		int max_area = 0; // Initialize max area in current
		// row (or histogram)

		int area = 0;    // Initialize area with current top

		// Run through all bars of given histogram (or row)
		int i = 0;
		while (i < row.Length)
		{

			// If this bar is higher than the bar on top stack,
			// push it to stack
			if (result.Count==0 || row[result.Peek()] <= row[i])
				result.Push(i++);

			else
			{
				// If this bar is lower than top of stack, then
				// calculate area of rectangle with stack top as
				// the smallest (or minimum height) bar. 'i' is
				// 'right index' for the top and element before
				// top in stack is 'left index'
				top_val = row[result.Peek()];
				result.Pop();
				area = top_val * i;
				int width = i;
				if (result.Count > 0) {
					area = top_val * (i - result.Peek () - 1);
					width = (i - result.Peek () - 1);
				}
//				if (width > 1 && top_val > 1) {
//					var temp = new Rect (i - width, heightIndex-top_val, width, top_val);
//					if (USE_RANGE) {
//						var xy = Enumerable.Range (2, top_val - 1).ToList ()
//						.SelectMany (y => Enumerable.Range (2, width - 1).ToList ().Select (x => new Rect (i - width, heightIndex - y, x, y)).ToList ())
//						.ToList ();
//						var tempRange = Enumerable.Range (2, width - 1).Select (x => new Rect (i - width, heightIndex - top_val, x, top_val)).ToList ();
//					
//						buffer.AddRange (xy);
//					} else {
//						buffer.Add (temp);
//					}
//				}

				if (width > 1 && top_val > 1) {
					var temp = new Rect (i - width, heightIndex-top_val+1, width, top_val);
					buffer.Add (temp);
				}
				max_area = Mathf.Max(area, max_area);
			}
		}

		// Now pop the remaining bars from stack and calculate area
		// with every popped bar as the smallest bar
		while (result.Count>0)
		{
			top_val = row[result.Peek()];
			result.Pop();

			area = top_val * i;
			int width = i;
			if (result.Count > 0) {
				area = top_val * (i - result.Peek () - 1);
				width = (i - result.Peek () - 1);
			}
			//				if (width > 1 && top_val > 1) {
			//					var temp = new Rect (i - width, heightIndex-top_val, width, top_val);
			//					if (USE_RANGE) {
			//						var xy = Enumerable.Range (2, top_val - 1).ToList ()
			//						.SelectMany (y => Enumerable.Range (2, width - 1).ToList ().Select (x => new Rect (i - width, heightIndex - y, x, y)).ToList ())
			//						.ToList ();
			//						var tempRange = Enumerable.Range (2, width - 1).Select (x => new Rect (i - width, heightIndex - top_val, x, top_val)).ToList ();
			//					
			//						buffer.AddRange (xy);
			//					} else {
			//						buffer.Add (temp);
			//					}
			//				}

			if (width > 1 && top_val > 1) {
				var temp = new Rect (i - width, heightIndex-top_val+1, width, top_val);
				buffer.Add (temp);
			}

			max_area = Mathf.Max(area, max_area);

		}



		return max_area;
	}


	//Use the area to discern which objects should be tested



	private void _GrowRectangles(){
		for (int r=0; r< rectangles.Count; r++) {
			for(int i=0; i < buffer.Count; i++){
				if (buffer [i]!=Rect.zero) {
					var flag = rectangles [r].GrowRect (buffer [i]);
					//if r has adjacency to b, r = r +b
					//remove b from buffer
					//rectangles[r] = rectangles[r]+buffer[i];
					if (flag) {
						buffer [i] = Rect.zero;
					}
				}
			}
		}


//		//execute immediate lookup vs deferred groupby
//		var rlut = buffer
//			.ToLookup (b => new {b.x,b.y});
//		var result = new List<Rect> ();
//		var removeKey = new List<Object> ();
//		foreach (var r in rectangles) {
//			foreach(var lookup in rlut){
//				foreach (var b in lookup) {
//					if (b.EnclosesRect (r)) {
//						result.Add (b);
//
//						//break;
//					} else {
//						
//					}
//				}
//			}
//		}
//
//
//		var grown = rectangles.Select(r=> 
//			buffer.Find(b => b.EnclosesRect (r))
//		).ToList();
//
//
//
//		buffer.RemoveAll (b=>grown.Contains(b));
		//lets group the rectangles by their x,y coordinate ordered by area; 

		//go through each buffer rectangle and see if its exclusive


//		LinkedList<Rect> result = new LinkedList<Rect> ();
//		var tempBuffer = new List<Rect> ();
//		foreach (Rect b in buffer) {
//			foreach(Rect r in rectangles){
//				if (b.Encloses (r)) {
//					result.AddLast (b);
//					continue;
//				} else {
//					tempBuffer.Add (b);
//				}
//				if (r.width * r.height > b.width * b.height)
//					continue;
//				var enclose = b.EnclosesRect (r);
//				switch (enclose) {
//					case 0:
//					//remove r, replace with b
//				break;
//				case 4:
//					//exclusive;
//				break;
//				default:
//					//remove
//					break;
//				} 
//			}
//		}
		//for each buffer rect, check if it encloses a result rect or intersects
		//todo: Check if buffer grows and rect,
		//if grows:
		//  remove all children rects
		//if it intersects but doesnt grow
		// remove the rect
	}

	private void _RemoveEnclosing(){
	
	}



	public static bool Intersect(Rect rectA, Rect rectB)
	{

		return (Mathf.Abs(rectA.x - rectB.x) < (Mathf.Abs(rectA.width + rectB.width) / 2)) &&
			(Mathf.Abs(rectA.y - rectB.y) < (Mathf.Abs(rectA.height + rectB.height) / 2));
	}


	private string hashRectangle(Rect r){
		return string.Format ("{0}-{1}", (int)r.x, (int)r.y);
	}


}

public static class RectangleSystemExtensionMethods{

	public static void DebugLogMatrix(int[][] A){
		string buffer = "";
		for (var i = 0; i < A.Length; i++) {
			for (var j = 0; j < A [i].Length; j++) {
				buffer = string.Concat(buffer,string.Format("|{0}|", A[i][j]));
			}
			buffer = string.Concat(buffer,"\r\n");
		}
		Debug.Log (buffer);
	}




	/// <summary>
	/// if b fully encloses a we return 16
	/// if b intersects a we return 15-1
	/// if b is mutex from a we return 0 
	/// </summary>
	/// <param name="b">The blue component.</param>
	/// <param name="a">The alpha component.</param>
	public static int Enclose(this Rect b, Rect a){
		//condition?true:false;
		var left = b.xMin <= a.xMin && a.xMin <= b.xMax-1? true:false;
		var right = b.xMin <= a.xMax-1 && a.xMax-1 <= b.xMax-1 ? true:false;
		var top = b.yMin <= a.yMin && a.yMin <= b.yMax-1? true:false;
		var bottom = b.yMin <= a.yMax-1 && a.yMax-1 <= b.yMax-1? true:false;


		bool intersect = right && !top && bottom || 
			left && top && !bottom || 
			left && !right && bottom || 
			!left && right && top;

//		intersect = (left || right) && (top && bottom) ||
//			(top || bottom) && (left && right) ||
//			(left && top) || (left && bottom) || (right && top) || 
//			(right && bottom);
		

		bool encloses = left && right && top && bottom;

		bool mutex = !intersect && !encloses;

		Debug.Log (string.Format ("{3} intersect:{0}, enclose:{1}, mutex:{2} {4}", 
			intersect, encloses, mutex,RectToString(b), RectToString(a)));

		var result = 0;
//		result|= left;
//		result<<=1;
//		result |=right;
//		result<<=1;
//		result |= top;
//		result<<=1;
//		result |= bottom;

	
		return result;
	}

	public static bool GrowRect(this Rect a, Rect b){
		return a.TopAdjacent (b) || a.LeftAdjacent (b) || a.BottomAdjacent (b) ||
		a.RightAdjacent (b);
	}
	public static bool LeftAdjacent(this Rect a, Rect b){
		if (a.xMin == b.xMax && a.height <= b.height) {
			a.xMax = b.xMin;
			return true;
		}
		return false;
	}

	public static bool TopAdjacent(this Rect a, Rect b){
		if (a.yMin == b.yMax && a.width <= b.width) {
			a.yMin = b.yMin;
			return true;
		}
		return false;
	}
	public static bool BottomAdjacent(this Rect a, Rect b){
		if (a.yMin == b.yMax && a.width <= b.width) {
			a.yMax = b.yMax;
			return true;
		}
		return false;

	}
	public static bool RightAdjacent(this Rect a, Rect b){
		if (a.xMax == b.xMin && a.height <= b.height) {
			a.xMax = b.xMax;

			return true;
		}
		return false;
	}


	public static float Area(this Rect r){
		return (r.width * r.height);
	}

	public static string RectToString(Rect r){
		return string.Format ("({0},{1}), ({2},{3})", r.xMin, r.yMin, r.xMax-1, r.yMax-1);

	}
}

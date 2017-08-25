using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RectangleAlgorithm : MonoBehaviour
{

	public class Rectangle{
		//define top left corner of rectangle
		public int xMin; //min x
		public int yMin; //max y
		public int xMax;
		public int yMax;
		public int width;
		public int height;

		public Rectangle(int xMin,int yMax, int xMax, int yMin){
			this.xMin = xMin;
			this.xMax = xMax;
			this.yMin = yMin;
			this.yMax = yMax;
			this.width = this.xMax -this.xMin;
			this.height = this.yMax - this.yMin;
		}

		public int contains(Rectangle b){
			//var contains = this.xMin <= b.xMin && this.xMax >= b.xMax && 
			return -1;
		}
	}


	//http://www.geeksforgeeks.org/maximum-size-rectangle-binary-sub-matrix-1s/
	List<Rect> rects = new List<Rect>();
	List<Rect> rects2 = new List<Rect>();
	Dictionary<string,Rect> rectangles;
	Dictionary<string,float> areas;


	LinkedList<Rect> r;
	LinkedList<Rect> buffer;


	int[][] A = new int[R][];

	public void Start(){
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

		A [0] = new int[]{ 0, 0, 0, 0, 0, 0 };//,
		A [1] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		A [2] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		A [3] =  new int[]{ 0, 0, 0, 0, 0, 0 };//,
		A [4] = new int[]   {0, 0,0, 0,0,0 };//,
		A [5] = new int[]   { 0, 1, 1, 0, 1, 1 };
		A [6] = new int[]   { 0, 1, 1, 0, 1, 1 };
		A [7] = new int[]   { 1, 1, 1, 1, 1, 1 };
		A [8] = new int[]	{ 1, 1, 1, 1, 1, 1 };
		rectangles = new Dictionary<string, Rect> ();
		areas = new Dictionary<string,float> ();
	}

	public void Update(){
		if(Input.GetKeyDown(KeyCode.U)){
			
		}
	}

	public void FixedUpdate(){

		//find all rects,

		//remove all enclosing rects

		//remove all subset rects
		rects.Clear ();
		rectangles.Clear ();
		areas.Clear ();
		var temp = System.Diagnostics.Stopwatch.StartNew ();
		temp.Start ();
		//int[]  c = ;
		var r = maxRectangle (A);
		temp.Stop ();

		Debug.Log( string.Format("TICKS {0}", temp.ElapsedTicks));
		Debug.Log (Time.fixedDeltaTime);
		Debug.Log (rects.Count);
		Debug.Log (r);
	}

	const int R = 9;
	const int C = 6;
	// Returns area of the largest rectangle with all 1s in A[][]
	int maxRectangle(int[][] A)
	{
		// Calculate area for first row and initialize it as
		// result
		int result = maxHist(A[0],0);

		// iterate over row to find maximum rectangular area
		// considering each row as histogram
		for (int i = 1; i < R; i++)
		{

			for (int j = 0; j < C; j++)

			// if A[i][j] is 1 then add A[i -1][j]
				if (A [i] [j] == 1) { 
					A [i] [j] += A [i - 1] [j];
				}


			// Update result if area with current row (as last row)
			// of rectangle) is more
			result = Mathf.Max(result, maxHist(A[i],i));
		}
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
					//left_index = result.Peek ();

				}
				if (width > 1 && top_val > 1) {
					var rr = new Rect (i - width, heightIndex-top_val, width, top_val);
					var hashKey = hashRectangle (rr);

					if (rectangles.ContainsKey (hashKey) && areas[hashKey] < area) {
						rectangles [hashKey] = rr;
						areas [hashKey] = area;
					}else {
						rectangles [hashKey] = rr;
						areas [hashKey] = area;
					}
					rects.Add(rr);

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

			if (width > 1 && top_val > 1) {
				var rr = new Rect (i - width, heightIndex-top_val, width, top_val);
				var hashKey = hashRectangle (rr);
				if (rectangles.ContainsKey (hashKey) && (areas [hashKey] < area || rr.Encloses(rectangles[hashKey])) ) {
					
					rectangles [hashKey] = rr;
					areas [hashKey] = area;
				} else {
					rectangles [hashKey] = rr;
					areas [hashKey] = area;
				}
				rects.Add (rr);
			}

			max_area = Mathf.Max(area, max_area);

		}



		return max_area;
	}

	public void ContainsRect(Rect rr){
		bool a = false;
		foreach (Rect r in rects) {
			
			if (rr.Overlaps (r, false)) {
				rects.Remove (r);
			}
			a = true;
		}
		rects.Add(rr);

	}

	private void UniqueRects(){
		var resultRect = new List<Rect> ();
		//largest to smallest order
		rects.Reverse ();
		foreach (Rect r in rects) {
			var a = true;
			foreach (Rect b in resultRect) {
				if (RectangleAlgorithm.Intersect (r, b)) {
					Debug.Log ("interset");
					a = false;
					continue;
				}

			}
			if (a) {
				resultRect.Add (r);
			}
		}
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

public static class RectangleExtensionMethods{
	public static bool Encloses(this Rect rectA, Rect rectB)
	{
		return !(rectA.xMin > rectB.xMin || rectA.xMax < rectB.yMax
			|| rectA.yMin > rectB.yMin || rectA.yMax < rectB.yMax);
		

	}
}

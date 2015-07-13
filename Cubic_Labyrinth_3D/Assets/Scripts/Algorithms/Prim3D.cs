
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Prim3D {

	static int maxRAND = 10;
	static int[,,] cube;
	static bool[, ,] checkedCubes;
	static int[, ,] cubeWeight;
	static CubeBrick[, ,] Grid;
	static List<Vector3> Set;

	public Prim3D()
	{

	}

	public static int[,,] prim (int x, int y, int z){
		Set = new List<Vector3>();
		cubeSizeGen (x, y, z);
		cubeGen (x, y, z);
		prim (new Vector3 (0, 0, 0));
		return cube;
	}
	
	static void cubeGen (int x, int y, int z)
	{
		Grid = new CubeBrick[x, y, z];
		for (int j = 0; j < x; j++)
		{
			for (int k = 0; k< y; k++)
			{
				for(int r = 0; r<z; r++)
				{
					Grid[j, k, r] = new CubeBrick(new Vector3(j,k,r), cubeWeight, new Vector3(x,y,z),  maxRAND);
				}
			}
		}
	}
	
	static void cubeSizeGen(int x, int y, int z)
	{
		cubeWeight = new int[x + 1, y + 1, z + 1];
		cube = new int[x, y, z];
		checkedCubes = new bool[x, y, z];
		for (int j = 0; j < x; j++)
		{
			for (int k = 0; k < y; k++)
			{
				for (int r = 0; r < z; r++)
				{
					cube[j, k, r] = 1;
					checkedCubes[j, k, r] = false;
					cubeWeight[j, k, r] = Random.Range(1, maxRAND);
				}
			}
		}
		cubeWeight[x, y, z] = maxRAND+2;
	}
	
	
	private static void prim(Vector3 s)
	{
		bool t = true;
		SetStart(s);
		while(t)
		{
			t = SetNext(cubeWeight);
		}
	}
	static void SetStart(Vector3 s)
	{
		cube[(int)s.x, (int)s.y, (int)s.z] = 0;
		checkedCubes[(int)s.x, (int)s.y, (int)s.z] = true;
		//for (int i = 0; i < (int)Grid[(int)s.X, (int)s.Y, (int)s.Z].GetNeighborNumber(); i++)
		//{
		//    Grid[(int)Grid[(int)s.X, (int)s.Y, (int)s.Z].positionN[i].X, (int)Grid[(int)s.X, (int)s.Y, (int)s.Z].positionN[i].Y, (int)s.Z].Remove(Grid[(int)s.X, (int)s.Y, (int)s.Z].position, cubeWeight);
		//}
		Set.Add(s);
	}
	static bool SetNext(int[, ,] w)
	{
		Vector3 next;
		CubeBrick nextB = new CubeBrick();
		bool answer = false;
		Vector3 minNext = new Vector3(-1,-1,-1);
		int freeN = 0;
		bool free = false;
		for (int k = 0; k < Set.Count; k++)
		{
			next = Set[k];
			nextB = Grid[(int)next.x, (int)next.y, (int)next.z];
			for (int i = 0; i < (int)nextB.NeighoborNumber; i++)
				if (checkedCubes[(int)nextB.positionN[i].x, (int)nextB.positionN[i].y, (int)nextB.positionN[i].z] == false)
			{
				freeN = 0;
				for (int j = 0; j < Grid[(int)nextB.positionN[i].x, (int)nextB.positionN[i].y, (int)nextB.positionN[i].z].NeighoborNumber; j++)
				{
					if (Grid[(int)nextB.positionN[i].x, (int)nextB.positionN[i].y, (int)nextB.positionN[i].z].positionN[j] != nextB.positionOf && 1 == cube[(int)Grid[(int)nextB.positionN[i].x, (int)nextB.positionN[i].y, (int)nextB.positionN[i].z].positionN[j].x, (int)Grid[(int)nextB.positionN[i].x, (int)nextB.positionN[i].y, (int)nextB.positionN[i].z].positionN[j].y, (int)Grid[(int)nextB.positionN[i].x, (int)nextB.positionN[i].y, (int)nextB.positionN[i].z].positionN[j].z])
					{
						freeN++;
						if (freeN == Grid[(int)nextB.positionN[i].x, (int)nextB.positionN[i].y, (int)nextB.positionN[i].z].NeighoborNumber - 1)
						{
							free = true;
						}
						else
						{
							free = false;
						}
					}
				}
				if (free)
				{
					if (minNext == new Vector3(-1, -1, -1))
					{
						minNext = new Vector3((int)nextB.positionN[i].x, (int)nextB.positionN[i].y, (int)nextB.positionN[i].z);
					}
					else if (w[(int)nextB.positionN[i].x, (int)nextB.positionN[i].y, (int)nextB.positionN[i].z] < w[(int)minNext.x, (int)minNext.y, (int)minNext.z])
					{
						minNext = new Vector3((int)nextB.positionN[i].x, (int)nextB.positionN[i].y, (int)nextB.positionN[i].z);
					}
				}
			}
		}
		if (minNext != new Vector3(-1, -1, -1))
		{
			cube[(int)minNext.x, (int)minNext.y, (int)minNext.z] = 0;
			checkedCubes[(int)minNext.x, (int)minNext.y, (int)minNext.z] = true;
			Set.Add(minNext);
			//Grid[(int)minNext.X, (int)minNext.Y, (int)minNext.Z].RemoveFirstNeighbor();
			answer = true;
		}
		else
		{
			answer = false;
		}
		return answer;
	}
}

using UnityEngine;
using System.Collections;

public class CubeBrick
{
	public Vector3 positionOf;
	public int weight;
	public int NeighoborNumber;
	public Vector3 size;
	public Vector3[] positionN;
	
	public CubeBrick()
	{
		
	}
	
	public CubeBrick(Vector3 p, int[,,] w, Vector3 s, int RandMax)
	{
		positionOf = p;
		size = s;
		weight = w[(int)positionOf.x, (int)positionOf.y, (int)positionOf.z];
		positionN = new Vector3[6];
		for (int i = 0; i < 6; i++)
		{
			positionN[i] = new Vector3(size.x, size.y, size.z);
		}
		NeighoborNumber = 0;
		
		if (positionOf.x - 1 >= 0)
		{
			positionN[0] = new Vector3(positionOf.x - 1, positionOf.y, positionOf.z);
			NeighoborNumber++;
		}
		else
		{
			positionN[0] = new Vector3(size.x, size.y, size.z);
		}
		if (positionOf.y - 1 >= 0)
		{
			if (w[(int)positionOf.x, (int)positionOf.y - 1, (int)positionOf.z] > w[(int)positionN[0].x, (int)positionN[0].y, (int)positionN[0].z])
				positionN[1] = new Vector3(positionOf.x, positionOf.y - 1, positionOf.z);
			else
			{
				positionN[1] = positionN[0];
				positionN[0] = new Vector3(positionOf.x, positionOf.y - 1, positionOf.z);
			}
			
			NeighoborNumber++;
		}
		else
		{
			positionN[1] = new Vector3(size.x, size.y, size.z);
		}
		if (positionOf.z - 1 >= 0)
		{
			if (w[(int)positionOf.x, (int)positionOf.y, (int)positionOf.z - 1] > w[(int)positionN[1].x, (int)positionN[1].y, (int)positionN[1].z])
				positionN[2] = new Vector3(positionOf.x, positionOf.y, positionOf.z - 1);
			else if (w[(int)positionOf.x, (int)positionOf.y, (int)positionOf.z - 1] > w[(int)positionN[0].x, (int)positionN[0].y, (int)positionN[0].z])
			{
				positionN[2] = positionN[1];
				positionN[1] = new Vector3(positionOf.x, positionOf.y, positionOf.z - 1);
			}
			else
			{
				positionN[2] = positionN[1];
				positionN[1] = positionN[0];
				positionN[0] = new Vector3(positionOf.x, positionOf.y, positionOf.z - 1);
			}
			NeighoborNumber++;
		}
		else
		{
			positionN[2] = new Vector3(size.x, size.y, size.z);
		}
		if (positionOf.x + 1 < size.x)
		{
			if (w[(int)(positionOf.x + 1), (int)positionOf.y, (int)positionOf.z] > w[(int)positionN[2].x, (int)positionN[2].y, (int)positionN[2].z])
				positionN[3] = new Vector3(positionOf.x + 1, positionOf.y, positionOf.z);
			else if (w[(int)positionOf.x + 1, (int)positionOf.y, (int)positionOf.z] > w[(int)positionN[1].x, (int)positionN[1].y, (int)positionN[1].z])
			{
				positionN[3] = positionN[2];
				positionN[2] = new Vector3(positionOf.x + 1, positionOf.y, positionOf.z);
			}
			else if (w[(int)(positionOf.x + 1), (int)positionOf.y, (int)positionOf.z] > w[(int)positionN[0].x, (int)positionN[0].y, (int)positionN[0].z])
			{
				positionN[3] = positionN[2];
				positionN[2] = positionN[1];
				positionN[1] = new Vector3(positionOf.x + 1, positionOf.y, positionOf.z);
			}
			else
			{
				positionN[3] = positionN[2];
				positionN[2] = positionN[1];
				positionN[1] = positionN[0];
				positionN[0] = new Vector3(positionOf.x + 1, positionOf.y, positionOf.z);
				
			}
			NeighoborNumber++;
		}
		else
		{
			positionN[3] = new Vector3(size.x, size.y, size.z);
		}
		if (positionOf.y + 1 < size.y)
		{
			if (w[(int)positionOf.x, (int)positionOf.y + 1, (int)positionOf.z] > w[(int)positionN[3].x, (int)positionN[3].y, (int)positionN[3].z])
				positionN[4] = new Vector3(positionOf.x, positionOf.y + 1, positionOf.z);
			else if (w[(int)positionOf.x, (int)positionOf.y + 1, (int)positionOf.z] > w[(int)positionN[2].x, (int)positionN[2].y, (int)positionN[2].z])
			{
				positionN[4] = positionN[3];
				positionN[3] = new Vector3(positionOf.x, positionOf.y + 1, positionOf.z);
			}
			else if (w[(int)positionOf.x, (int)positionOf.y + 1, (int)positionOf.z] > w[(int)positionN[1].x, (int)positionN[1].y, (int)positionN[1].z])
			{
				positionN[4] = positionN[3];
				positionN[3] = positionN[2];
				positionN[2] = new Vector3(positionOf.x, positionOf.y + 1, positionOf.z);
			}
			else if (w[(int)positionOf.x, (int)positionOf.y + 1, (int)positionOf.z] > w[(int)positionN[0].x, (int)positionN[0].y, (int)positionN[0].z])
			{
				positionN[4] = positionN[3];
				positionN[3] = positionN[2];
				positionN[2] = positionN[1];
				positionN[1] = new Vector3(positionOf.x, positionOf.y + 1, positionOf.z);
			}
			else
			{
				positionN[4] = positionN[3];
				positionN[3] = positionN[2];
				positionN[2] = positionN[1];
				positionN[1] = positionN[0];
				positionN[0] = new Vector3(positionOf.x, positionOf.y + 1, positionOf.z);
				
			}
			NeighoborNumber++;
		}
		else
		{
			positionN[4] = new Vector3(size.x, size.y, size.z);
		}
		if (positionOf.z + 1 < size.z)
		{
			if (w[(int)positionOf.x, (int)positionOf.y, (int)positionOf.z + 1] > w[(int)positionN[4].x, (int)positionN[4].y, (int)positionN[4].z])
				positionN[5] = new Vector3(positionOf.x, positionOf.y, positionOf.z + 1);
			else if (w[(int)positionOf.x, (int)positionOf.y, (int)positionOf.z + 1] > w[(int)positionN[3].x, (int)positionN[3].y, (int)positionN[3].z])
			{
				positionN[5] = positionN[4];
				positionN[4] = new Vector3(positionOf.x, positionOf.y, positionOf.z + 1);
			}
			else if (w[(int)positionOf.x, (int)positionOf.y, (int)positionOf.z + 1] > w[(int)positionN[2].x, (int)positionN[2].y, (int)positionN[2].z])
			{
				positionN[5] = positionN[4];
				positionN[4] = positionN[3];
				positionN[3] = new Vector3(positionOf.x, positionOf.y, positionOf.z + 1);
			}
			else if (w[(int)positionOf.x, (int)positionOf.y, (int)positionOf.z + 1] > w[(int)positionN[1].x, (int)positionN[1].y, (int)positionN[1].z])
			{
				positionN[5] = positionN[4];
				positionN[4] = positionN[3];
				positionN[3] = positionN[2];
				positionN[2] = new Vector3(positionOf.x, positionOf.y, positionOf.z + 1);
			}
			else if (w[(int)positionOf.x, (int)positionOf.y, (int)positionOf.z + 1] > w[(int)positionN[0].x, (int)positionN[0].y, (int)positionN[0].z])
			{
				positionN[5] = positionN[4];
				positionN[4] = positionN[3];
				positionN[3] = positionN[2];
				positionN[2] = positionN[1];
				positionN[1] = new Vector3(positionOf.x, positionOf.y, positionOf.z + 1);
			}
			else
			{
				positionN[5] = positionN[4];
				positionN[4] = positionN[3];
				positionN[3] = positionN[2];
				positionN[2] = positionN[1];
				positionN[1] = positionN[0];
				positionN[0] = new Vector3(positionOf.x, positionOf.y, positionOf.z + 1);
				
			}
			NeighoborNumber++;
		}
		else
		{
			positionN[5] = new Vector3(size.x, size.y, size.z);
		}
	}
	
	public int getWeight()
	{
		return weight;
	}
	public Vector3 getPosition()
	{
		return positionOf;
	}
	public Vector3 GetNeighbor()
	{
		return positionN[0];
	}
	public int GetNeighborNumber()
	{
		return NeighoborNumber;
	}
	public int GetNeighborWeight(int[,,] w)
	{
		return w[(int)positionN[0].x, (int)positionN[0].y, (int)positionN[0].z];
	}
	public int TakeNeighborWeight(int[, ,] w)
	{
		Vector3 p = positionN[1];
		if (NeighoborNumber > 1)
			positionN[0] = positionN[1];
		if (NeighoborNumber > 2)
			positionN[1] = positionN[2];
		if (NeighoborNumber > 3)
			positionN[2] = positionN[3];
		if (NeighoborNumber > 4)
			positionN[3] = positionN[4];
		if (NeighoborNumber > 5)
			positionN[4] = positionN[5];
		NeighoborNumber -= 1;
		return w[(int)p.x, (int)p.y, (int)p.z];
	}
	public void RemoveFirstNeighbor()
	{
		if (NeighoborNumber > 1)
			positionN[0] = positionN[1];
		if (NeighoborNumber > 2)
			positionN[1] = positionN[2];
		if (NeighoborNumber > 3)
			positionN[2] = positionN[3];
		if (NeighoborNumber > 4)
			positionN[3] = positionN[4];
		if (NeighoborNumber > 5)
			positionN[4] = positionN[5];
		NeighoborNumber -= 1;
	}
	
	public void Remove(Vector3 r, int[, ,] w)
	{
		if (positionN[0] == r)
			positionN[0] = new Vector3(size.x, size.y, size.z);
		if (positionN[1] == r)
			positionN[1] = new Vector3(size.x, size.y, size.z);
		if (positionN[2] == r)
			positionN[2] = new Vector3(size.x, size.y, size.z);
		if (positionN[3] == r)
			positionN[3] = new Vector3(size.x, size.y, size.z);
		if (positionN[4] == r)
			positionN[4] = new Vector3(size.x, size.y, size.z);
		if (positionN[5] == r)
			positionN[5] = new Vector3(size.x, size.y, size.z);
		NeighoborNumber -= 1;
		SortWeights(w);
	}
	
	public void SortWeights(int[,,] w)
	{
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < i; j++)
			{
				if(w[(int)positionN[j].x,(int)positionN[j].y,(int)positionN[j].z]>w[(int)positionN[i].x,(int)positionN[i].y,(int)positionN[i].z])
				{
					Vector3 temp = positionN[j];
					positionN[j] = positionN[i];
					positionN[i] = temp;
				}
			}
		}
	}
}
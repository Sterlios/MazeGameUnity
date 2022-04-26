using UnityEngine;

public class Maze : MonoBehaviour
{
	[SerializeField] private int sizeX, sizeZ;

	[SerializeField] private MazeCell cellPrefab;

	private MazeCell[,] cells;

	public void Generate()
	{
		cells = new MazeCell[sizeX, sizeZ];
		for (int x = 0; x < sizeX; x++)
		{
			for (int z = 0; z < sizeZ; z++)
			{
				CreateCell(x, z);
			}
		}
	}

	private void CreateCell(int x, int z)
	{
		MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
		cells[x, z] = newCell;
		newCell.name = "Maze Cell " + x + ", " + z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3(x - sizeX * 0.5f + 0.5f, 0f, z - sizeZ * 0.5f + 0.5f);
	}
}
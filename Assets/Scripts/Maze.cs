using UnityEngine;

public class Maze : MonoBehaviour
{
	[SerializeField] private IntVector2 size;

	[SerializeField] private MazeCell cellPrefab;

	private MazeCell[,] cells;

	public void Generate()
	{
		cells = new MazeCell[size.x, size.z];
		for (int x = 0; x < size.x; x++)
		{
			for (int z = 0; z < size.z; z++)
			{
				CreateCell(new IntVector2(x, z));
			}
		}
	}

	private void CreateCell(IntVector2 coordinates)
	{
		MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
		cells[coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
	}
}
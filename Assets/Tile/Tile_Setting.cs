using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Setting : MonoBehaviour
{
    [SerializeField]
    public struct Count
    {
        public int Minimum;
        public int Maximum;
    }
    public int colums = 8; //ї­
    public int rows = 8; //За
    public GameObject[] floor_Tiles;

    private Transform boardHolder;
    private List<Vector3> GridPositions = new List<Vector3>();

    private void InitialiseList()
    {
        GridPositions.Clear();

        for(int x = 0; x < colums; x++ )
        {
            for(int y = 0; y < rows; y++)
            {
                GridPositions.Add(new Vector3(x, y, 0.0f));
            }
        }
    }

    private void BoardSetUp()
    {
        boardHolder = new GameObject("Board").transform;
        for(int x = -1; x< colums +1; x++)
        {
            for(int y = -1; y<rows+1;y++)
            {
                GameObject ToInstantiate = floor_Tiles[Random.Range(0, floor_Tiles.Length)];
                GameObject Instance = Instantiate(ToInstantiate, new Vector3(x, y, 0.0f), Quaternion.identity) as GameObject;
                
                Instance.transform.SetParent(boardHolder);
            }
        }
    }
    public void SetupScene(int level)
    {
        BoardSetUp();
        InitialiseList();
    }

    private void Awake()
    {
        SetupScene(0);
    }
}

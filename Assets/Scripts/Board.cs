using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject tilePrefab;
    private BackgroundTile[,] allTiles;
    public GameObject[] dots;
    public GameObject[,] allDotes;

    // Start is called before the first frame update
    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        allDotes = new GameObject[width, height];
        SetUp();
    }
    
    private void SetUp()
    {
        for (int i = 0; i < width; i++) 
        { 
            for (int j = 0; j < height; j++)
            {
                Vector2 tempPositoin = new Vector2(i,j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPositoin,Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "(" + i + ", " + j + ")";

                int dotToUse = Random.Range(0, dots.Length);
                GameObject dot = Instantiate(dots[dotToUse], tempPositoin, Quaternion.identity);
                dot.transform.parent = this.transform;
                dot.name = "(" + i + ", " + j + ")";

                allDotes[i,j] = dot;
            }
        }
    }
}

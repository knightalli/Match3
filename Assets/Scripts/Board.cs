using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width; // Размеры доски.
    public int height;
    public GameObject tilePrefab;  //Объект - ячейка.
    private BackgroundTile[,] allTiles; //Все координаты ячеек.
    public GameObject[] dots; //Все варианты значков (в нашем случае по вариации цветов).
    public GameObject[,] allDotes; //Все координаты значков.

    // Start is called before the first frame update
    void Start()
    {
        allTiles = new BackgroundTile[width, height];  //Инициализируем ячейки и значки.
        allDotes = new GameObject[width, height];
        SetUp(); //Устанавливаем и наполняем доску.
    }
    
    private void SetUp()
    {
        for (int i = 0; i < width; i++) 
        { 
            for (int j = 0; j < height; j++) //Делаем цикл в цикле, чтобы захватить все ячейки по координатам, как в матрице.
            {
                Vector2 tempPositoin = new Vector2(i,j);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPositoin,Quaternion.identity) as GameObject; //Instantiate - метод по созданию объекта.
                                                                                                                     //tilePrefab - сам объект.
                                                                                                                     //tempPosition - его координаты.
                                                                                                                     //Quaternion - вращение предмета.
                                                                                                                     //.identify - оставляем его в первоначальном виде.
                backgroundTile.transform.parent = this.transform; //Каждую ячейку мы делаем дочерней для Board.
                backgroundTile.name = "(" + i + ", " + j + ")"; //Называем ячейку.

                int dotToUse = Random.Range(0, dots.Length); //Возвращает любое из вариантов значков по цвету.
                GameObject dot = Instantiate(dots[dotToUse], tempPositoin, Quaternion.identity); //Создаем значок.
                dot.transform.parent = this.transform; //Каждый значок мы делаем дочерним для Board.
                dot.name = "(" + i + ", " + j + ")"; //Называем значок.

                allDotes[i,j] = dot; //Заполняем доску.
            }
        }
    }
}

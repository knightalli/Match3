using UnityEngine;

public class Dot : MonoBehaviour
{
    public int column;
    public int row;
    public int targetX;
    public int targetY;
    private Board board;
    private GameObject otherDot;
    private Vector2 firstTouchPosition;
    private Vector2 finalTouchPosition;
    private Vector2 tempPosition;
    public float swipeAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>(); //Берем уже инициализированную доску и работаем с ней.
        targetX = (int)transform.position.x; //Берем позицию по x этого значка.
        targetY = (int)transform.position.y; //Берем позицию по y этого значка.
        row = targetY; //Назначаем строку и столбец данного значка.
        column = targetX;
    }

    // Update is called once per frame
    void Update()
    {
        targetX = column;
        targetY = row;
        if (Mathf.Abs(targetX - transform.position.x) > 0.1)
        {
            //Подвинуться в направлении цели
            tempPosition = new Vector2 (targetX, transform.position.y);
            transform.position = Vector2.Lerp(transform.position, tempPosition, 0.4f); //Делаем плавное передвижение значка по заданному направлению.
        }
        else
        {
            //Установить точную позицию
            tempPosition = new Vector2(targetX, transform.position.y);
            transform.position = tempPosition;
            board.allDotes[column, row] = this.gameObject;
        }
        if (Mathf.Abs(targetY - transform.position.y) > 0.1)
        {
            //Подвинуться в направлении цели
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.Lerp(transform.position, tempPosition, 0.4f);
        }
        else
        {
            //Установить точную позицию
            tempPosition = new Vector2(transform.position.x, targetY);
            transform.position = tempPosition;
            board.allDotes[column, row] = this.gameObject;
        }
    }

    private void OnMouseDown()
    {
        firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(firstTouchPosition); Была проверка, что передает координаты точки.
    }

    private void OnMouseUp()
    {
        finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CalculateAngle();
    }

    void CalculateAngle()
    {
        swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x) * 180 / Mathf.PI;
        //Debug.Log(swipeAngle); Была проверка, что вычисляет угол.
        MovePieces(); 
    }

    void MovePieces()
    {
        if (swipeAngle > -45 && swipeAngle <= 45 && column < board.width)
        {
            //Движение направо
            otherDot = board.allDotes[column + 1, row];
            otherDot.GetComponent<Dot>().column -= 1;
            column += 1;
        }
        else if (swipeAngle > 45 && swipeAngle <= 135 && row < board.height)
        {
            //Движение вверх
            otherDot = board.allDotes[column, row + 1];
            otherDot.GetComponent<Dot>().row -= 1;
            row += 1;
        }
        else if ((swipeAngle > 135 || swipeAngle <= -135) && column > 0)
        {
            //Движение налево
            otherDot = board.allDotes[column - 1, row];
            otherDot.GetComponent<Dot>().column += 1;
            column -= 1;
        }
        else if (swipeAngle < -45 && swipeAngle >= -135 && row > 0)
        {
            //Движение вниз
            otherDot = board.allDotes[column, row - 1];
            otherDot.GetComponent<Dot>().row += 1;
            row -= 1;
        }
    }
}

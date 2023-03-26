using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static int[] dx = { 1, -1, 0, 0 };
    private static int[] dy = { 0, 0, 1, -1 };

    [SerializeField]
    private float speed = 0.1f;

    private bool isMoving = false;

    public int i;
    public int j;
    
    private void Move(int k)
    {
        if (isMoving)
            return;
        
        int n = Levels.n;
        int x = i + dx[k];
        int y = j + dy[k];

        if (x >= 0 && x < n && y >= 0 && y < n)
        {
            if(Levels.loadedLevel[x, y] == '.')
            {
                StartCoroutine(MovePlayer(new Vector2(Tile.size * y - (n / 2) * Tile.size, -Tile.size * x + (n / 2) * Tile.size)));

                Levels.loadedLevel[x, y] = 'P';
                Levels.loadedLevel[i, j] = '.';
                i = x;
                j = y;
                
            }
            else if(Levels.loadedLevel[x, y] == '@')
            {
                ;
            }
            else if(Levels.loadedLevel[x, y] == '#')
            {
                int x_2 = x + dx[k];
                int y_2 = y + dy[k];
                if(x_2 >= 0 && x_2 < n && y_2 >= 0 && y_2 < n)
                {
                    if(Levels.loadedLevel[x_2, y_2] == '.')
                    {
                        
                    }
                }
            }
        }
        
    }

    private IEnumerator MovePlayer(Vector2 targetPosition)
    {
        isMoving = true;
        int n = Levels.n;
        Vector2 startPosition = new Vector2(Tile.size * j - (n / 2) * Tile.size, -Tile.size * i + (n / 2) * Tile.size);
        float time = 0;
        while (time < speed)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / speed);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    } 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Move(1);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            Move(0);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            Move(2);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Move(3);
    }
}

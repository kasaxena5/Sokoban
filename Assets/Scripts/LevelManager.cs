using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Box boxPrefab;

    private List<Tile> backgroundTiles;
    private Box[,] boxes;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void InitializeLevelBackground()
    {
        int n = Levels.n;
        backgroundTiles = new List<Tile>();
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                Tile tile = Instantiate(tilePrefab, new Vector3(Tile.size * j - (n / 2) * Tile.size, -Tile.size * i + (n / 2) * Tile.size, 0), Quaternion.identity);

                switch(Levels.loadedLevel[i][j])
                {
                    case '@':
                        tile.SetState(Tile.TileState.Wall);
                        break;
                    case '.':
                        tile.SetState(Tile.TileState.Ground);
                        break;
                    default:
                        tile.SetState(Tile.TileState.Ground);
                        break;
                }
                backgroundTiles.Add(tile);

            }
        }
    }

    private void InitializeLevelForeground()
    {
        int n = Levels.n;
        boxes = new Box[n, n];
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(Levels.loadedLevel[i][j] == '#')
                {
                    boxes[i, j] = Instantiate(boxPrefab, new Vector3(Tile.size * j - (n / 2) * Tile.size, -Tile.size * i + (n / 2) * Tile.size, 0), Quaternion.identity);
                }
            }
        }
    }

    private void LoadLevel()
    {
        Levels.loadedLevel = Levels.level1;
        InitializeLevelBackground();
        InitializeLevelForeground();
    }

    private void DestroyLevelBackground()
    {
        int n = Levels.n;
        for (int i = 0; i < n * n; i++)
        {
            Destroy(backgroundTiles[i].gameObject);
        }
        backgroundTiles = null;
    }

    private void DestroyLevelForeground()
    {

    }

    private void DestroyLevel()
    {
        DestroyLevelBackground();
        DestroyLevelForeground();
    }

    void Start()
    {
        LoadLevel();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private TileState state = TileState.Ground;
    [SerializeField] private Sprite wallSprite;
    [SerializeField] private Sprite groundSprite;

    public enum TileState
    {
        Wall,
        Ground
    }

    public void SetState(TileState newState)
    {
        state = newState;
        this.GetComponent<SpriteRenderer>().sprite = state switch
        {
            TileState.Wall => wallSprite,
            TileState.Ground => groundSprite,
            _ => groundSprite,
        };
    }

    public TileState GetState()
    {
        return state;
    }

    public static int size = 1;
}

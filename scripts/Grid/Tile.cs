using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    private GameObject tile;

    public Tile(GameObject tile)
    {
        this.tile = MonoBehaviour.Instantiate(tile);
        this.tile.gameObject.SetActive(false);
    }

    public void setPosition(float x, float y)
    {
        Vector2 position = new Vector2(x, y);
        tile.transform.position = position;
    }

    public void setPosition(Vector2 position)
    {
        tile.transform.position = position;
    }

    public Vector2 getPosition()
    {
        return tile.transform.position;
    }

    public void setScale(float x, float y)
    {
        Vector2 scale = new Vector2(x, y);
        tile.transform.localScale = scale;
    }

    public void setScale(Vector2 scale)
    {
        tile.transform.localScale = scale;
    }

    public Vector2 getScale()
    {
        return tile.transform.localScale;
    }

    public Vector2 getDimensions()
    {
        Vector2 dimensions = new Vector2(tile.GetComponent<SpriteRenderer>().bounds.size.x, tile.GetComponent<SpriteRenderer>().bounds.size.y);
        return dimensions;
    }

    public void setObject(GameObject tile)
    {
        this.tile = tile;
    }

    public GameObject getObject()
    {
        return tile;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid {

    private Tile[,] grid_raster;
    public int width, height;
    Vector2 pos;

    public Grid(int width, int height, GameObject tilePrefab)
    {
        grid_raster = new Tile[width, height];
        pos.x = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        pos.y = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.y;
        
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Tile tile = new Tile(tilePrefab);
                tile.setPosition(j * tile.getDimensions().x, i * tile.getDimensions().y);
                grid_raster[j, i] = tile;
            }
        }

        this.width = width;
        this.height = height;
    }

    public void Display()
    {
        GameObject parent = new GameObject("Tiles");
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                grid_raster[j, i].getObject().transform.parent = parent.transform;
                grid_raster[j, i].getObject().SetActive(true);
            }
        }
    }

    public Tile getTile(int x, int y)
    {
        return grid_raster[x, y];
    }

    public GameObject getTileAsGameObject(int x, int y)
    {
        return grid_raster[x, y].getObject();
    }

    public void setTexture(int x, int y, Sprite sprite)
    {
        grid_raster[x, y].getObject().GetComponent<SpriteRenderer>().sprite = sprite;
    }

    int number = 0;
    public bool clickOnSprite(Sprite sprite)
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        for (int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                float x = grid_raster[j,i].getObject().transform.position.x;
                float y = grid_raster[j, i].getObject().transform.position.y;
                float xWidth = grid_raster[j, i].getObject().transform.position.x + getTile(j, i).getDimensions().x;
                float yWidth = grid_raster[j, i].getObject().transform.position.x + getTile(j, i).getDimensions().y;


                if (mousePos.x > x && mousePos.x < x + xWidth && mousePos.y > y && mousePos.y < y + yWidth)
                {
                    MonoBehaviour.print("SPRITE DETECTED: " + grid_raster[j, i].getObject().GetComponent<SpriteRenderer>().sprite.name);
                    if (grid_raster[j, i].getObject().GetComponent<SpriteRenderer>().sprite.name == sprite.name)
                    {
                        number++;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        return false;
    }
    
    /*Use Vector4's for begin x/y and end x/y*/
    public void FillRect(Sprite sprite, params Vector4[] positions)
    {
        for(int k = 0; k < positions.Length; k++)
        {
            for (int i = 0; i < grid_raster.GetLength(1); i++)
                for (int j = 0; j < grid_raster.GetLength(0); j++)
                {
                    if (j >= positions[k].x && j <= positions[k].z && i >= positions[k].y && i <= positions[k].w)
                    {
                        grid_raster[j, i].getObject().GetComponent<SpriteRenderer>().sprite = sprite;
                    }
                }
        }
    }

}

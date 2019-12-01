using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

    public Grid grid;

    public GameObject tile, waypointGO;
    public Sprite path, grass;
    public Vector2[] waypointList;

	void Start () {

        tile.GetComponent<SpriteRenderer>().sprite = grass;
        
        waypointList = new Vector2[12];

        //Grid and path creation
        grid = new Grid(19, 11, tile);

        grid.FillRect(path, new Vector4(14,5,19,5), new Vector4(14,5,14,9), new Vector4(5,9,14,9), new Vector4(5,3,5,9),
        new Vector4(5,3,8,3), new Vector4(8,3,8,7), new Vector4(8,7,11,7), new Vector4(11,1,11,7), new Vector4(2,1,11,1),
        new Vector4(2,1,2,6), new Vector4(1,6,2,6), new Vector4(1,6,1,11));

        for (int i = 0; i < waypointGO.transform.childCount; i++)
        {
            waypointList[i] = waypointGO.transform.GetChild(i).position;
        }

        grid.Display();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_placement : MonoBehaviour
{

    Vector3 pos;
    SpriteRenderer sprtr;
    float rgb;
    public bool isReady;
    float radius;
    Color radColor;
    bool mouseHover = false;

    GameObject grid;

    public Sprite path, mySprite, grass;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        sprtr = GetComponent<SpriteRenderer>();
        rgb = 1 / 255;
        radius = GetComponentInChildren<CircleCollider2D>().radius;

        gameObject.transform.GetChild(0).localScale = new Vector3(radius / 3, radius / 3, radius / 3);
        radColor = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
        grid = GameObject.FindGameObjectWithTag("GridManager");

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && !hoverMouseOver(path))
        {
            sprtr.color = new Color(sprtr.color.r, sprtr.color.g, sprtr.color.b, 1);
            Color radColor = gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(radColor.r, radColor.g, radColor.b, 0);
            isReady = true;
        }

        if (!isReady)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.tag == "tile")
                {
                    transform.position = hits[i].collider.transform.position;
                }
            }
        }

        if (mouseHover)
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(radColor.r, radColor.g, radColor.b, 0.53333333f);
        }
        else
        {
            gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(radColor.r, radColor.g, radColor.b, 0.0f);
        }

    }

    bool hoverMouseOver(Sprite sprite)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider != null)
            {
                if (hits[i].collider.GetComponent<SpriteRenderer>().sprite == sprite)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnMouseEnter()
    {
        mouseHover = true;
    }

    private void OnMouseExit()
    {
        mouseHover = false;
    }
}



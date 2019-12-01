using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_elements : MonoBehaviour {

    internal uint currency = 40;
    public GameObject soldier, tank;
    public Text dollarUI;

    GameObject tower_category;

	// Use this for initialization
	void Start () {
        tower_category = GameObject.FindGameObjectWithTag("Tower_category");
	}

    bool holding_key;

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Alpha1) && currency >= 20 && !holding_key)
        {
            Vector3 pos;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z + 5.0f;
            var tow = Instantiate(soldier, pos, Quaternion.identity, tower_category.transform);
            currency -= 20;
            holding_key = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && currency >= 60 && !holding_key)
        {
            Vector3 pos;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = transform.position.z + 5.0f;
            var tow = Instantiate(tank, pos, Quaternion.identity, tower_category.transform);
            currency -= 60;
            holding_key = true;
        }

        if(Input.GetMouseButton(0))
        {
            holding_key = false;
        }

        dollarUI.text = "$" + currency;

	}
}

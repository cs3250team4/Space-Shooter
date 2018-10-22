/* This script controls the persentation of a menu on a GUI canvas
 * Use this as a base for your menu.
 * The hot key is ESC.
 * Pete Fennell 10-1-2018
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public OptionsMenuGeneral optionsMenu;

	// Use this for initialization
	void Start () {

        optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (Time.timeScale == 1)

                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            }

        }
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Runtime;


public class MenuController : MonoBehaviour {

    public GameObject[] menus;

    public enum MenuState {
        Home,
        Settings,
        SelectMode,
        TableSize,
        PlayerSelect
    }

    public MenuState menuState;

    public void Start() {

        StartCoroutine(ActiveThisMenu());
    }

     IEnumerator ActiveThisMenu() {

        for (int i = 0; i<menus.Length; i++) {

            if (menuState.ToString()==menus[i].name) {

                menus[i].SetActive(true);
            }else {
                menus[i].SetActive(false);
            }
        }
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(ActiveThisMenu());
    }

    public void MenuName(string menu) {

        switch (menu) {

            case "Home":
                menuState=MenuState.Home;
                break;
            case "Settings":
                menuState=MenuState.Settings;
                break;
            case "SelectMode":
                menuState=MenuState.SelectMode;
                break;
            case "TableSize":
                menuState=MenuState.TableSize;
                break;
            case "PlayerSelect":
                menuState=MenuState.PlayerSelect;
                break;
        }
    }

    public static string ExternalAccessCodeMenuName(string menu) {

        MenuController menuController =  new MenuController();
        menuController.MenuName(menu);
        return menu;
    }
}

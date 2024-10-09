using Assets.Script.Template;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonControllerTemplate<UIManager>
{    
    public GameObject _mainMenu;
    public GameObject _pauseMenu;  
    public GameObject _ui;

    public void OpenMainMenu()
    {
        _mainMenu.SetActive(true);
    }
    public void CloseMainMenu()
    {
        _mainMenu.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        _pauseMenu.SetActive(true);
    }
    public void ClosePauseMenu()
    {
        _pauseMenu.SetActive(false);
    }

    public void OpenUI()
    {
        _ui.SetActive(true);
    }
    public void CloseUI()
    {
        _ui.SetActive(false);
    }
}
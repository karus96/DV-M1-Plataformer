using Assets.Script.Template;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameStatus { MainMenu = 0, Pause = 1, Play = 2 }

public class GameManager : SingletonControllerTemplate<GameManager>
{   
    [SerializeField] private GameStatus _status;
    [SerializeField] private int _score;

    public void AddScore(int score)
    {
        _score += score;
    }
    
    public GameStatus Status => _status;

    public void NewGame()
    {
        _status = GameStatus.Play;
        UIManager.CurrentInstance.CloseMainMenu();
        UIManager.CurrentInstance.OpenUI();
    }
    public void ContinueGame()
    {
        UIManager.CurrentInstance.ClosePauseMenu();
        _status = GameStatus.Play;
    }
    
    void Update()
    {
        switch (_status) 
        { 
            case GameStatus.MainMenu:
                Debug.Log("Estoy en MainMenu");
                break;
            case GameStatus.Pause:
                Debug.Log("Estoy en Pause");
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    ContinueGame();
                }
                break;
            case GameStatus.Play:
                Debug.Log("Estoy en Play");               
                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    UIManager.CurrentInstance.OpenPauseMenu();
                    _status = GameStatus.Pause;
                }
                break;
        }        
    }
}

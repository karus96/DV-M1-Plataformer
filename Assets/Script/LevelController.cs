
using UnityEngine;

public class LevelController : MonoBehaviour
{    
    public Transform _endPoint;
    private bool _oneUse = false;
    private void CreateBlockLevel()
    {
        int random = Random.Range(0, GameManager.CurrentInstance.LevelControllers.Count);
        LevelController levelController = Instantiate(GameManager.CurrentInstance.LevelControllers[random]);
        levelController.transform.position = _endPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_oneUse)
        {
            _oneUse = true; 
            CreateBlockLevel();
        }
        
    }
}

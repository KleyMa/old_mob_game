using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    int coinsGrabbedOnAllLevels;
    public int coinsGrabbedOnThisLevel = 0;
    int coinsOnThisLevel = 9;
    bool gamePaused = false;
    [SerializeField] TextMeshProUGUI coinsText;
    // Start is called before the first frame update
    void Start()
    {
        coinsOnThisLevel = FindObjectsOfType<Coin>().Length;
        coinsText.text = coinsGrabbedOnThisLevel.ToString() + " / "  + coinsOnThisLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGameIsPaused();
    }

    public void AddCoins()
    {
        coinsGrabbedOnThisLevel++;
        coinsGrabbedOnAllLevels++;
        coinsText.text = coinsGrabbedOnThisLevel.ToString() + " / " + coinsOnThisLevel.ToString();
    }

    private void CheckIfGameIsPaused()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && gamePaused)
        {
            Time.timeScale = 1f;
            gamePaused = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            gamePaused = true;
        }
    }
}

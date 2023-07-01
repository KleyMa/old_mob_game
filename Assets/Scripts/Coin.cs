using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinSfx;
    Player player;
    GameStatus gameStatus;
    CoinsCanvas coinsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        gameStatus = FindObjectOfType<GameStatus>();
        coinsCanvas = FindObjectOfType<CoinsCanvas>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSfx, player.transform.position);
            gameStatus.AddCoins();
            coinsCanvas.ActivateAnimation();
            Destroy(gameObject);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    bool isDeath, isInmortal;
    float activeVelocity;
    Vector2 input;
    SpriteRenderer spriteRenderer;
    ImageUIScript imageUIScript;
    [SerializeField] AudioClip damagedSfx;
    [SerializeField] TextMeshProUGUI vidasText;
    [SerializeField] float tiempoDeInmortalidad = 1f;
    [SerializeField] float moveVelocity = 1f;
    [SerializeField] float dashVelocity = 5f;
    [SerializeField] float dashLength = .5f;
    [SerializeField] int health = 6;
    [SerializeField] float dashCooldown = 1f;

    float dashCounter, dashCoolCounter;

    Rigidbody2D thisRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        isDeath = false;
        isInmortal = false;
        activeVelocity = moveVelocity;
        imageUIScript = FindObjectOfType<ImageUIScript>();
        thisRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        vidasText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if(isDeath)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Revivir");
                FindObjectOfType<SceneLoader>().ReloadCurrentScene();
            }
        }
        
    }

    private void MovePlayer()
    {
        if (!isDeath)
        {
            input.x = Input.GetAxis("Horizontal");
            input.y = Input.GetAxis("Vertical");
            input.Normalize();
            thisRigidbody.inertia = 0;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                thisRigidbody.velocity = (activeVelocity * input) / 2;
            }
            else
            {
                thisRigidbody.velocity = activeVelocity * input;
            }
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                spriteRenderer.color = Color.white;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (dashCoolCounter <= 0 && dashCounter <= 0)
                {
                    activeVelocity = dashVelocity;
                    dashCounter = dashLength;
                    spriteRenderer.color = new Color32(160, 160, 160, 255);
                }

            }

            if (dashCounter > 0)
            {
                dashCounter -= Time.deltaTime;
                isInmortal = true;
                if (dashCounter <= 0)
                {
                    activeVelocity = moveVelocity;
                    dashCoolCounter = dashCooldown;
                    isInmortal = false;
                    
                }
            }
            if (dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
        }
    }
    private void Die() 
    {
        isDeath = true;
        spriteRenderer.color = new Color32(234, 88, 100, 255);
        
    }
    private void GetDamaged()
    {
        //Dar feedback al jugador que fuiste golpeado
    }
    private void SetMortal() 
    { 
        isInmortal = false;
        Debug.Log("ssss");
    }
    public void DecreaseHealth()
    {
        
        if (!isInmortal && health > 0)
        {
            health--;
            CinemachineVibration.Instance.MoverCamara(25f, 25f, 0.3f);
            AudioSource.PlayClipAtPoint(damagedSfx, gameObject.transform.position);
            isInmortal = true;
            Debug.Log(isInmortal);
            vidasText.text = health.ToString();
            Invoke("SetMortal", tiempoDeInmortalidad);
            Debug.Log("me quitas vida" + health);
            if(health <= 1)
            {
                imageUIScript.ChangeSprite();
            }
            if (health <= 0)
            {
                GetDamaged();
                Die();
            }
        }
    }
}

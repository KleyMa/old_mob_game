using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsCanvas : MonoBehaviour
{
    Animator animator;
    float timerAnimation = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerAnimation <= 0)
        {
            animator.SetBool("CoinGrabbed", false);
        }
        timerAnimation -= Time.deltaTime;
    }
    
    public void ActivateAnimation()
    {
        timerAnimation = 5f;
        animator.SetBool("CoinGrabbed", true);
    }
}

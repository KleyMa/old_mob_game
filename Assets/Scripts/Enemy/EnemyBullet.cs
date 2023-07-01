using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Bullet Config")]
    [SerializeField] GameObject bullet;
    [SerializeField] float interval;
    [SerializeField] float velocityBullet;
    [SerializeField] float angle;

    private float timerTime;
    private GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        timerTime = interval;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerTime > 0)
        {
            timerTime -= Time.deltaTime;
        }
        else
        {
            SpawnBullet();
            timerTime = interval;
        }
    }

    private void SpawnBullet()
    {
        child = Instantiate(bullet, transform.position, Quaternion.identity);
        child.GetComponent<Rigidbody2D>().velocity = new Vector2(velocityBullet * Time.deltaTime, Mathf.Sin(Mathf.PI/360 * child.transform.rotation.z * angle) * Time.deltaTime);
    }
}

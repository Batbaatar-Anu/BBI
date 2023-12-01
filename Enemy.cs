using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    public int health;
    [Range(0,1)]
    public float speed;

    public Animator animator;
    public GameObject player;
    public bool isAlive = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        float Distance = Vector3.Distance(transform.position, player.transform.position);
        if (Distance > 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * 0.02f);
            animator.SetFloat("Speed", speed);
            speed+= Mathf.Lerp(0,2,Time.deltaTime);
            transform.LookAt(player.transform.position);
        }else if(Distance<10){
            speed -= Mathf.Lerp(0, 5, Time.deltaTime);
        }
    }
    public void TakeDamage(int damage) {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
            //animation
        }
        
    }
}

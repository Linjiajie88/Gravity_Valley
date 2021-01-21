using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarController healthBar;

    public AudioClip hurtAudio;
    private AudioSource audioSource;

    public GameObject respawnPoint;
    private float damageHeight = 150.0f;
    private Rigidbody rb;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();	
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            die();
        }
        if (transform.position.y >= damageHeight)
        {
            TakeDamage(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Fist")
        {
            TakeDamage(10);
        }
        if(other.gameObject.tag == "item")
        {
            heal(10);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Boulder")
        {
            TakeDamage(50);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        audioSource.PlayOneShot(hurtAudio);
        healthBar.SetHealth(currentHealth);
    }

    public void heal(int heal)
    {
        currentHealth += heal;
        if(currentHealth > 100)
        {
            currentHealth = 100;
        }
        healthBar.SetHealth(currentHealth);
    }

    private void die()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        transform.position = respawnPoint.transform.position;
        rb.velocity = Vector3.zero;
    }
}

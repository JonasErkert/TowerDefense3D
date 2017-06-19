using UnityEngine;

public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    public float health = 100f;
    public int moneyGain = 50;
    public GameObject deathEffect;

    [HideInInspector]
    public float speed;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += moneyGain;

        GameObject deathEffectGO = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(deathEffectGO, 5f);
        Destroy(gameObject);
    }

    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }
}

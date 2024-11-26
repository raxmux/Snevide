using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Drag your projectile prefab here
    public Transform firePoint; // The position where the projectile will spawn
    public Transform player; // The player's transform (set in the Inspector)
    public float fireCooldown = 2f; // Cooldown time in seconds
    public float projectileSpeed = 10f; // Speed of the projectile
    public float projectileLifetime = 5f; // Time before bullets are destroyed

    private float fireTimer = 0f; // Tracks time since last shot
    private bool isShooting = false; // Tracks whether the player is actively shooting

    void Update()
    {
        // Ensure the player exists
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing!");
            return;
        }

        // Aim towards the player
        Vector2 direction = (player.position - firePoint.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Check input for shooting
        if (Input.GetMouseButtonDown(0)) // Left mouse button pressed
        {
            isShooting = true;
        }
        if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            isShooting = false;
        }

        // Handle cooldown timer and shooting
        fireTimer += Time.deltaTime;
        if (isShooting && fireTimer >= fireCooldown)
        {
            Shoot(direction);
            fireTimer = 0f; // Reset cooldown
        }
    }

    void Shoot(Vector2 direction)
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Ensure the projectile has a Rigidbody2D
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
        else
        {
            Debug.LogError("Projectile prefab is missing a Rigidbody2D!");
        }

        // Attach collision handling to the projectile
        ProjectileCollisionHandler projectileHandler = projectile.AddComponent<ProjectileCollisionHandler>();
        projectileHandler.lifetime = projectileLifetime; // Assign lifetime
    }
}

// Collision handling for projectiles
public class ProjectileCollisionHandler : MonoBehaviour
{
    public float lifetime = 5f; // Time before the projectile is destroyed

    void Start()
    {
        // Destroy the projectile after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the projectile on collision
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    public static float health;
    public static float damage;
    public static float speed;
    public static float attackspeed ;
    void Start()
    {
        health = 100f;
        damage = 5f;
        speed = 5f;
        attackspeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

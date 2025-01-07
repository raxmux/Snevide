using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class EnemyMovement : MonoBehaviour
{
    public Transform PlayerTransform;
    float test = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //FollowPlayerNot();
        //yield return new WaitForSeconds(5);
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 moveDirection = PlayerTransform.position - transform.position;
        moveDirection.z = 0;
        moveDirection.Normalize();
        transform.position += moveDirection * Time.deltaTime;
    }
    void FollowPlayerNot()
    {
        Vector3 moveDirection = transform.position - PlayerTransform.position;
        moveDirection.z = 0;
        moveDirection.Normalize();
        transform.position += moveDirection * Time.deltaTime;
    }
}

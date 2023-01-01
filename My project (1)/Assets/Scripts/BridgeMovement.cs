using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMovement : MonoBehaviour
{

    Transform targetPoint;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPoint = GameObject.FindGameObjectWithTag("BridgeTarget").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        if(transform.position.z < -10)
        {
            BridgeSpawner.bridgeCount--;
            Destroy(gameObject);
        }
    }
}

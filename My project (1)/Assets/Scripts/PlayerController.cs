using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent navMesh;
    [SerializeField]Transform targetPoint;
    Rigidbody rb;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        navMesh = GetComponent<NavMeshAgent>();
        targetPoint.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Vector3 screenPosDepth = Input.mousePosition;
            screenPosDepth.z = 5;
            targetPoint.position = new Vector3(Camera.main.ScreenToWorldPoint(screenPosDepth).x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPoint.position, 80f * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        navMesh.velocity = new Vector3(navMesh.velocity.x, navMesh.velocity.y, speed * Time.deltaTime);
    }
}

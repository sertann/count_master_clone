using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    Transform humanToFollow;
    [HideInInspector] public bool aggressive = false;
    float maxDistance = 1.9f;
    float followSpeed = 3.5f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        humanToFollow = GameObject.FindGameObjectWithTag("Group").transform;
    }

    private void Update()
    {
        if (aggressive)
        {
            
            FollowChosenHuman();
            Fight();
            
        }
    }
    void ChooseHumanToFollow()
    {
        Collider[] humans = Physics.OverlapCapsule(transform.position, transform.position, 4);
        foreach (var human in humans)
        {
            if(Vector3.Distance(transform.position, human.transform.position) < maxDistance)
            {
                humanToFollow = human.transform;
            }
        }
    }

    void FollowChosenHuman()
    {
        transform.position = Vector3.Lerp(transform.position,humanToFollow.position , followSpeed * Time.deltaTime);
        transform.LookAt(humanToFollow);
    }

    void Fight()
    {
        if(Vector3.Distance(transform.position, humanToFollow.position) <= maxDistance)
        {
            Debug.Log(Vector3.Distance(transform.position, humanToFollow.position));
            GameObject[] humans = GameObject.FindGameObjectsWithTag("Human");
            int index = Random.RandomRange(0, humans.Length);
            humans[index].GetComponent<TeamMember>().LeaveTeam();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}

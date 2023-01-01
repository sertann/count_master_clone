using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiningTrigger : MonoBehaviour
{

    [SerializeField] GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            manager.Win();
        }
    }
}

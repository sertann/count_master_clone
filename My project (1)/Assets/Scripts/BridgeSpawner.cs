using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpawner : MonoBehaviour
{
    [SerializeField] GameObject bridge;
    public static int bridgeCount = 0;
    float bridgePos = 0;
    List<GameObject> bridges = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartingSpawn(8);
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBridge(8);
        Debug.Log(bridges);
    }

    void SpawnBridge(int maxBridge)
    {
        if(bridgeCount < maxBridge)
        {
            GameObject _bridge = Instantiate(bridge, transform);
            Vector3 lastBridgePos = _bridge.transform.position;
            Vector3 newBridgePos = new Vector3(0, 0, lastBridgePos.z + 9.7f);
            bridge.transform.position = newBridgePos;
            
            bridgeCount++;
        }
    }

    void StartingSpawn(int _bridgeCount)
    {
        for (int i = 0; i < _bridgeCount; i++)
        {
            GameObject _bridge = Instantiate(bridge, transform);
            bridges.Add(bridge);
            bridge.transform.position = new Vector3(0, 0, bridgePos);
            bridgePos += 9.7f;
            bridgeCount++;
        }
    }

}

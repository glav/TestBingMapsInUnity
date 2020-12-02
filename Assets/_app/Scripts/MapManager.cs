using Microsoft.Maps.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] MapSession mapSession;

    private void OnEnable()
    {
        Debug.Log("Initialising BING SDK Key");
        var keys = BingKeys.LoadInstance();
        if (string.IsNullOrWhiteSpace(keys.bingMapSdkKey))
        {
            Debug.Log(" BING SDK Key not found.");
            throw new System.Exception("No Key!");
        }
        mapSession.DeveloperKey = keys.bingMapSdkKey;
        Debug.Log("Done initialising BING SDK Key");

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

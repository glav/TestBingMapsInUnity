using Microsoft.Geospatial;
using Microsoft.Maps.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    [SerializeField] MapSession mapSession;
    [SerializeField] MapPin mapPinPrefab;
    private MapRenderer mapRenderer;
    private MapPinLayer pinLayer;
    private List<LatLon> pins = new List<LatLon>();
    [SerializeField] Text longitudeText;
    [SerializeField] Text latitudeText;
    [SerializeField] int zoomLevelOnAddPin = 18;

    private void OnEnable()
    {
        Debug.Log("Initialising BING SDK Key");
        var keys = BingKeys.LoadInstance();
        if (string.IsNullOrWhiteSpace(keys.bingMapSdkKey))
        {
            Debug.Log(" BING SDK Key not found.");
            throw new System.Exception("No Key!");
        }

        mapRenderer = GetComponent<MapRenderer>();
        pinLayer = GetComponent<MapPinLayer>();
        mapSession.DeveloperKey = keys.bingMapSdkKey;
        Debug.Log("Done initialising BING SDK Key");

    }

    private void Awake()
    {
        // Default to 400 George st
        longitudeText.text = "151.2073577699742";
        latitudeText.text = "-33.868812556313266";

        longitudeText.SetAllDirty();

    }

    public void Reset()
    {
        pinLayer.MapPins.Clear();
        mapRenderer.ZoomLevel = 1;
    }

    public void Add()
    {
        var pin = Instantiate(mapPinPrefab);
        //pin.Location = new LatLon(-33.868812556313266, 151.2073577699742); // 400 george st

        Debug.Log($"Trying to add Lat:{latitudeText.text}, Long:{longitudeText.text}");
        pin.Location = new LatLon(Convert.ToDouble(latitudeText.text), Convert.ToDouble(longitudeText.text)); // 400 george st
        pinLayer.MapPins.Add(pin);
        mapRenderer.Center = pin.Location;
        mapRenderer.ZoomLevel = zoomLevelOnAddPin;

    }
}

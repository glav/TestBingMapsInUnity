using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BingMap/Keys", fileName = "BingKeys")]
public class BingKeys : ScriptableObject
{
    public string bingMapSdkKey;

    public static BingKeys LoadInstance()
    {
        var secrets = Resources.Load<BingKeys>("BingKeys");
        if (secrets == null)
        {
            Debug.LogError("No secrets/BinKeys defined.  Please create secrets asset in Resources/Secrets.asset");
        }
        else
        {
            Debug.Log($"Loaded secrets/keys from asset");
        }

        return secrets;
    }
}

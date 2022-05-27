using Network.Kaiba;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerunoManager
{
    public static TerunoManager Instance
    {
        get
        {
            if (m_Instance == null)
                m_Instance = new TerunoManager();

            return m_Instance;
        }
        private set => m_Instance = value;
    }

    public static TerunoManager m_Instance;


    public static bool IsNetworkHost = false;

    public static bool isOffline = true;

    public static bool IsHost { get => isOffline || IsNetworkHost; }

    public static bool IsVREnabled = false;


    public static void InstantiateTrackedBodyPart(TrackedBodyPart part)
    {
        var obj = NetworkUtility.Instantiate("Prefabs/PlayerTrackedBody_Hand", Vector3.zero, Quaternion.identity, 0, new object[] { part });
        if (!NetworkUtility.IsNetworkAvailable)
            obj.GetComponent<PlayerTrackedBody>().Initialize(part);
    }
}

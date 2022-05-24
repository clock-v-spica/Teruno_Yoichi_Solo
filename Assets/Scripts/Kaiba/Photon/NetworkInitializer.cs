using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInitializer : MonoBehaviour
{
    [SerializeField]
    PlayerHand_NetSync head;
    [SerializeField]
    PlayerHand_NetSync rightHand;
    [SerializeField]
    PlayerHand_NetSync leftHand;

    [SerializeField]
    bool isOffline;

    private void Start()
    {
        ResumeNetworkMessaging();
        PlayerTrackedBody.OnTrackedPartsUpdated += PlayerTrackedBody_OnTrackedPartsUpdated;
        if (OctSystemCore.IsHost)
            AssignToVRPlayer();
        else
            AssignToTabletPlayer();
    }

    private void PlayerTrackedBody_OnTrackedPartsUpdated(TrackedBodyPart obj)
    {
        if (OctSystemCore.IsHost)
        {
            if (obj == TrackedBodyPart.PlayerOne_Head)
            {
                rightHand.Init(0);
                leftHand.Init(0);
            }
        }
        else
        {
            if (obj == TrackedBodyPart.PlayerTwo_Head)
            {
                rightHand.Init(1);
                leftHand.Init(1);
            }
        }
    }

    public void ResumeNetworkMessaging()
    {
        PhotonNetwork.IsMessageQueueRunning = true;
    }

    void AssignToVRPlayer()
    {
        head.Init(0);
    }

    void AssignToTabletPlayer()
    {
        head.Init(1);
    }
}

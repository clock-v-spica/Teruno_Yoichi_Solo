using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkInitializer : MonoBehaviour
{
    [SerializeField]
    PlayerBody_NetSync head;
    [SerializeField]
    PlayerBody_NetSync rightHand;
    [SerializeField]
    PlayerBody_NetSync leftHand;

    [SerializeField]
    Transform shooterAnchor;
    [SerializeField]
    Transform catcherAnchor;

    [SerializeField]
    GameObject VRCameraRig;
    [SerializeField]
    GameObject RemotePlayerPrefab;
    [SerializeField]
    GameObject remotePlayer;


    [SerializeField]
    bool isOffline;

    private void Awake()
    {
        TerunoManager.shooterAnchor = shooterAnchor;
        TerunoManager.catcherAnchor = catcherAnchor;
    }

    private void Start()
    {
        PlayerTrackedBody.OnTrackedPartsUpdated += PlayerTrackedBody_OnTrackedPartsUpdated;

        remotePlayer = Instantiate(RemotePlayerPrefab);
        ResumeNetworkMessaging();

        if (TerunoManager.IsHost)
            AssignToVRPlayer();
        else
            AssignToTabletPlayer();
    }

    private void PlayerTrackedBody_OnTrackedPartsUpdated(TrackedBodyPart obj)
    {
        if (TerunoManager.IsHost)
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
        VRCameraRig.GetComponent<PlayerSetup>().Init(true);
        VRCameraRig.transform.SetParent(shooterAnchor.parent);
        VRCameraRig.transform.position = shooterAnchor.position;
        VRCameraRig.transform.rotation = shooterAnchor.rotation;

        remotePlayer.GetComponent<RemotePlayerSetup>().Init(false);
        remotePlayer.transform.SetParent(catcherAnchor.parent);
        remotePlayer.transform.position = catcherAnchor.position;
        remotePlayer.transform.rotation = catcherAnchor.rotation;
        head.Init(0);

    }

    void AssignToTabletPlayer()
    {
        VRCameraRig.GetComponent<PlayerSetup>().Init(false);
        VRCameraRig.transform.SetParent(catcherAnchor.parent);
        VRCameraRig.transform.position = catcherAnchor.position;
        VRCameraRig.transform.rotation = catcherAnchor.rotation;

        remotePlayer.GetComponent<RemotePlayerSetup>().Init(true);
        remotePlayer.transform.SetParent(shooterAnchor.parent);
        remotePlayer.transform.position = shooterAnchor.position;
        remotePlayer.transform.rotation = shooterAnchor.rotation;

        head.Init(1);
    }
}

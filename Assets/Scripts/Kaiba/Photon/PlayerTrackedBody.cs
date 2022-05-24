using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class PlayerTrackedBody : MonoBehaviour, IPunInstantiateMagicCallback
{
    public static Dictionary<TrackedBodyPart, PlayerTrackedBody> TrackedBodyDict = new Dictionary<TrackedBodyPart, PlayerTrackedBody>();
    public static event Action<TrackedBodyPart> OnTrackedPartsUpdated;

    IObjectBinderInterface legBinder;

    [SerializeField]
    TrackedBodyPart bodyPart;


    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        var part = (TrackedBodyPart)info.photonView.InstantiationData[0];
        Initialize(part);
    }

    public void Initialize(TrackedBodyPart part)
    {
        bodyPart = part;
        TrackedBodyDict.Add(part, this);
        if (PlayerHand_NetSync.HandDict.TryGetValue(part, out GameObject obj))
        {
            transform.SetParent(obj.transform);
            if (part == TrackedBodyPart.PlayerOne_Head || part == TrackedBodyPart.PlayerTwo_Head)
                OctopusManager.Instance.transform.SetParent(transform, true);
        }

        legBinder = GetComponent<IObjectBinderInterface>();

        OnTrackedPartsUpdated?.Invoke(part);
    }


    public void BindLeg(int leg,IObjectBinderInterface binder)
    {
        var part = (TrackedBodyPart)((leg / 3) * 3);

        binder.Bind(leg,gameObject, TrackedBodyDict[part].gameObject);
    }
}

public enum TrackedBodyPart : int
{
    PlayerOne_Head = 0,
    PlayerOne_RightHand = 1,
    PlayerOne_LeftHand = 2,
    PlayerTwo_Head = 3,
    PlayerTwo_RightHand = 4,
    PlayerTwo_LeftHand = 5,
    PlayerThree_Head = 6,
    PlayerThree_RightHand = 7,
    PlayerThree_LeftHand = 8,
    PlayerFourth_Head = 9,
    PlayerFourth_RightHand = 10,
    PlayerFourth_LeftHand = 11,
}

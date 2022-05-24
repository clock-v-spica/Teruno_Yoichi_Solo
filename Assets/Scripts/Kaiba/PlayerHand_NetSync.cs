using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Network.Kaiba;

public class PlayerHand_NetSync : MonoBehaviour
{
    [SerializeField]
    bool isHead;
    [SerializeField]
    bool isRight;

    [Tooltip("0 = Head, 1 = RightHand, 2 = LeftHand")]
    [SerializeField]
    int partIndex;

    public static Dictionary<TrackedBodyPart, GameObject> HandDict = new Dictionary<TrackedBodyPart, GameObject>();

    public void Init(int PlayerIndex)
    {
        TrackedBodyPart part;

        part = (TrackedBodyPart)(PlayerIndex * 3 + partIndex);

        HandDict.Add(part, gameObject);

        OctSystemCore.InstantiateTrackedBodyPart(part);
    }
}

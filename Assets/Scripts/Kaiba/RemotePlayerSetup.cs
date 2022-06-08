using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemotePlayerSetup : MonoBehaviour
{
    [SerializeField]
    GameObject bow;

    [SerializeField]
    GameObject target;

    [SerializeField]
    VRIK vrIK;

    public void Init(bool isShooter)
    {
        if (isShooter)
        {
            target.SetActive(false);
        }
        else
        {
            bow.SetActive(false);
        }
    }

    private void Awake()
    {
        PlayerTrackedBody.OnTrackedPartsUpdated += PlayerTrackedBody_OnTrackedPartsUpdated;
    }

    private void PlayerTrackedBody_OnTrackedPartsUpdated(TrackedBodyPart obj)
    {
        var remote_h = TerunoManager.IsHost ? TrackedBodyPart.PlayerTwo_Head : TrackedBodyPart.PlayerOne_Head;
        var remote_rh = TerunoManager.IsHost ? TrackedBodyPart.PlayerTwo_RightHand : TrackedBodyPart.PlayerOne_RightHand;
        var remote_lh = TerunoManager.IsHost ? TrackedBodyPart.PlayerTwo_LeftHand : TrackedBodyPart.PlayerOne_LeftHand;

        if (!PlayerTrackedBody.TrackedBodyDict.ContainsKey(remote_h))
            return;

        if (!PlayerTrackedBody.TrackedBodyDict.ContainsKey(remote_rh))
            return;

        if (!PlayerTrackedBody.TrackedBodyDict.ContainsKey(remote_lh))
            return;

        transform.localEulerAngles = new Vector3(0, 180, 0);

        vrIK.solver.spine.headTarget = PlayerTrackedBody.TrackedBodyDict[remote_h].transform;
        vrIK.solver.rightArm.target = PlayerTrackedBody.TrackedBodyDict[remote_rh].transform;
        vrIK.solver.leftArm.target = PlayerTrackedBody.TrackedBodyDict[remote_lh].transform;
    }
}

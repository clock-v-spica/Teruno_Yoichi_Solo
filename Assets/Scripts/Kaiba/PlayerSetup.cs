using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField]
    GameObject bow;

    [SerializeField]
    GameObject target;

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
}

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kaiba.Network
{
    public static class NetworkUtility
    {

        public static GameObject GetObjectFromNetworkId(int id)
        {
            return PhotonNetwork.GetPhotonView(id).gameObject;
        }

        public static bool IsNetworkAvailable
        {
            get => PhotonNetwork.IsConnectedAndReady;
        }

        public static bool IsRoomMaster
        {
            get => PhotonNetwork.IsMasterClient;
        }

        public static bool HasAuthority(GameObject view)
        {
            return view.GetComponent<PhotonView>().IsMine;
        }

        public static GameObject Instantiate(string prefab, Vector3 pos, Quaternion rot, byte group = 0, object[] param = null)
        {
            if (PhotonNetwork.InRoom)
                return PhotonNetwork.Instantiate(prefab, pos, rot, group, param);
            else
            {
                var obj = GameObject.Instantiate(Resources.Load(prefab) as GameObject, pos, rot);
                return obj;
            }
        }

        public static void DestroyNetworkObject(GameObject obj)
        {
            PhotonNetwork.Destroy(obj);
        }


        public static void ExitRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

    }

}


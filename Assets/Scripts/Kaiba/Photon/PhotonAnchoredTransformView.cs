using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PhotonAnchoredTransformView : MonoBehaviourPun, IPunObservable
{
    private float m_Distance;
    private float m_Angle;

    private Vector3 m_Direction;
    private Vector3 m_NetworkPosition;
    private Vector3 m_NetworkAnchoredPosition;
    private Vector3 m_StoredPosition;

    private Quaternion m_NetworkRotation;
    private Quaternion m_NetworkAnchoredRotation;

    public bool m_SynchronizePosition = true;
    public bool m_SynchronizeRotation = true;
    public bool m_SynchronizeScale = false;

    [SerializeField]
    PhotonAnchorView anchor;


    bool m_firstTake = false;

    public void Awake()
    {
        m_StoredPosition = transform.localPosition;
        m_NetworkPosition = Vector3.zero;

        m_NetworkRotation = Quaternion.identity;
    }

    public void Init()
    {
        anchor = transform.root.GetComponentInChildren<PhotonAnchorView>();
    }

    private void Reset()
    {

    }

    void OnEnable()
    {
        m_firstTake = true;
    }

    public void Update()
    {
        var tr = transform;

        if (!this.photonView.IsMine)
        {
            tr.position = Vector3.MoveTowards(tr.position, m_NetworkAnchoredPosition, this.m_Distance * (1.0f / PhotonNetwork.SerializationRate));
            tr.rotation = Quaternion.RotateTowards(tr.rotation, m_NetworkAnchoredRotation, this.m_Angle * (1.0f / PhotonNetwork.SerializationRate));

        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        var tr = transform;

        // Write
        if (stream.IsWriting)
        {
            if (this.m_SynchronizePosition)
            {
                var pos = anchor.transform.InverseTransformPoint(tr.position);
                this.m_Direction = pos - this.m_StoredPosition;
                this.m_StoredPosition = pos;
                stream.SendNext(pos);
                stream.SendNext(this.m_Direction);
            }

            if (this.m_SynchronizeRotation)
            {
                var rot = Quaternion.Inverse(anchor.transform.rotation) * transform.rotation;
                stream.SendNext(rot);
            }

            if (this.m_SynchronizeScale)
            {
                stream.SendNext(tr.localScale);
            }
        }
        // Read
        else
        {
            if (this.m_SynchronizePosition)
            {
                this.m_NetworkPosition = (Vector3)stream.ReceiveNext();
                this.m_Direction = (Vector3)stream.ReceiveNext();
                m_NetworkAnchoredPosition = anchor.transform.TransformPoint(m_NetworkPosition);

                if (m_firstTake)
                {
                    tr.position = m_NetworkAnchoredPosition;

                    this.m_Distance = 0f;
                }
                else
                {
                    float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.SentServerTime));
                    m_NetworkAnchoredPosition += this.m_Direction * lag;
                    this.m_Distance = Vector3.Distance(tr.position, m_NetworkAnchoredPosition);

                }

            }

            if (this.m_SynchronizeRotation)
            {
                this.m_NetworkRotation = (Quaternion)stream.ReceiveNext();
                m_NetworkAnchoredRotation = anchor.transform.rotation * m_NetworkRotation;

                if (m_firstTake)
                {
                    this.m_Angle = 0f;

                    tr.rotation = m_NetworkAnchoredRotation;
                }
                else
                {
                    this.m_Angle = Quaternion.Angle(tr.rotation, m_NetworkAnchoredRotation);

                }
            }

            if (this.m_SynchronizeScale)
            {
                tr.localScale = (Vector3)stream.ReceiveNext();
            }

            if (m_firstTake)
            {
                m_firstTake = false;
            }
        }
    }
}

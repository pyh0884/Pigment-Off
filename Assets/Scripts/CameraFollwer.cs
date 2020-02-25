using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollwer : MonoBehaviour
{
    public Transform[] transforms;
    Cinemachine.CinemachineTargetGroup.Target target;
    Cinemachine.CinemachineTargetGroup targetGroup;
    List<CinemachineTargetGroup.Target> targets = new List<CinemachineTargetGroup.Target>();

    private void Start()
    {
        targetGroup = GetComponent<CinemachineTargetGroup>();
    }
    //public void RemoveNull()
    //{
    //    var list = targets.
    //    for (int i = targets.Count - 1; i >= 0; i--)
    //    {
    //        if (targets.Index(i) != null)
    //        {
    //            //Do stuff
    //        }
    //        else
    //        {
    //            ObjectsInSight[i] = ObjectsInSight[ObjectsInSight.Count - 1];
    //            ObjectsInSight.RemoveAt(ObjectsInSight.Count - 1);
    //        }
    //    }
    //}
    //private void Update()
    //{
    //    targets.Add(new CinemachineTargetGroup.Target { target = theTransform[0], radius = 0.8f, weight = 1f });
    //    targets.Add(new CinemachineTargetGroup.Target { target = theTransform[1] ransform, radius = 0.8f, weight = 1f });
    //    ctg.m_Targets = targets.ToArray();

    //}
}
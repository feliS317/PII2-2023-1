using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Cinemachine.CinemachineTargetGroup targetGroup;
    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;
    public bool coop = false;

    void Start()
    {
        var Targets = targetGroup.m_Targets;      // arreglo que contiene los targets de la cámara
        Targets[0].target = playerOne.transform;
        if(coop)
        {
            playerTwo.SetActive(true);
            Targets[1].target = playerTwo.transform;
            Targets[0].radius = 5.0f;
        }
    }
}

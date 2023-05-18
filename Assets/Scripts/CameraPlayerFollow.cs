using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    private void Awake()
    {
        Steamworks.SteamUserStats.SetAchievement("CameraControlled");
    }
    private void LateUpdate()
    {
        transform.position = PlayerController.Instance.transform.position + offset;
    }
}

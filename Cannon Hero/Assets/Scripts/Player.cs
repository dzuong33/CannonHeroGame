using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.InteropServices.ComTypes;

public class Player : MonoBehaviour
{
    [SerializeField] Gun gun;
    public static bool isAiming;
    public static bool isShooting;
    public static bool isShot;
    public static bool needMovePlayer;
    public Transform playerTransform;

    public static Player Instance;
    
    private void Awake()
    {
        Player.isShooting = false;
        Player.isShot = false;
        Player.isAiming = false;
        Player.needMovePlayer = false;
        Instance = this;
    }
    public void Renew()
    {
        Player.isAiming = false;
        Player.isShooting = false;
        Player.isShot = false;
        Player.needMovePlayer= false;
    }
    public void MovePlayer()
    {
        SpawnManager.isChangingLevel = true;
    }
    private void Update()
    {

        if(Input.GetMouseButtonDown(0) && !Utility.IsPointerOverUIObject() && ! isAiming)
        {
            Player.needMovePlayer = false;
            isAiming = true;
        }

        if(isAiming)
        {
            gun.Aiming();
        }
        if(Input.GetMouseButtonUp(0) && isAiming)
        {
            StartCoroutine(Fire());
        }
        if(Player.needMovePlayer)
        {
            //movePlayer();
        }
    }
    private IEnumerator Fire()
    {
        isAiming = false;
        isShooting = true;

        float timeWaitToFire = 0.05f;
        yield return new WaitForSeconds(timeWaitToFire);

        gun.GetComponent<Gun>().Fire();
    }
}



using UnityEngine;
using System.Collections;

public class RocketGun : Gun
{
    [SerializeField] private GameObject normalBullet;

    public override void Renew()
    {
        base.Renew();
        normalBullet.transform.position = firePoint.position;
        normalBullet.transform.rotation = Quaternion.identity;
    }

    protected override void NormalFire(float shotAngle)
    {
        normalBullet.SetActive(true);
        normalBullet.GetComponent<Rigidbody2D>().AddForce(Utility.CalculateDirection(shotAngle) * fireForce);
    }

}
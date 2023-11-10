using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class GunSystem : MonoBehaviour
{
    public MoneyScript Moneycrip;

    public int ammoBoxRefill;
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int BulletsRemaining, bulletsPerTap; //bullets remaining is number on right
    public bool allowButtonHold;
    public int BulletsInMag, bulletsShot; //bulletsinmag is on left
    public Animator ShootingAnim;
    public GameObject MuzzleFlash;
    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    
    public Camera camShake;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;

    private void Awake()
    {
        BulletsInMag = BulletsRemaining;
        readyToShoot = true;
        


    }
    private void Update()
    {
        MyInput();
        if(GameObject.Find("RedButton").GetComponent<startButton>().buttonPressed == false)
        {
            //SetText
            text.SetText(BulletsInMag + " / " + BulletsRemaining);
        }
      
    }
    private void MyInput()
    {
        if (GameObject.Find("MP5") != null)
        {
            if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
            else shooting = Input.GetKeyDown(KeyCode.Mouse0);

            if (Input.GetKeyDown(KeyCode.R) && !reloading) Reload();

            //Shoot
            if (readyToShoot && shooting && !reloading && BulletsInMag > 0)
            {
                bulletsShot = bulletsPerTap;
                Shoot();
            }
        }
    }
    private void Shoot()
    {
        readyToShoot = false;
        ShootingAnim.SetBool("IsShooting", true);
        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy) && GameObject.Find("RedButton").GetComponent<startButton>().buttonPressed == false)
        {

           if(rayHit.collider.CompareTag("Baby"))
            {
                DestroyImmediate(rayHit.collider.gameObject);
                Moneycrip.Money += 1;
            }
           
        }
        MuzzleFlash.SetActive(true);
        //ShakeCamera

        //Graphics
       

        BulletsInMag--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);
        Debug.Log(timeBetweenShooting);
        //if (bulletsShot > 0 && BulletsInMag > 0)
            //Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        ShootingAnim.SetBool("IsShooting", false);
        readyToShoot = true;
        MuzzleFlash.SetActive(false);
        

    }
    private void Reload()
    {
        if(BulletsRemaining > 0)
        {
            reloading = true;
            Invoke("ReloadFinished", reloadTime);

        }
       
    }
    private void ReloadFinished()
    {
        if(BulletsRemaining + BulletsInMag <= 25)
        {
            BulletsInMag = BulletsInMag + BulletsRemaining;
            BulletsRemaining = 0;
            reloading = false;
        }
        else
        {
            int bulletsToSubtract = 25 - BulletsInMag;
            BulletsInMag += bulletsToSubtract;
            BulletsRemaining -= bulletsToSubtract;
            reloading = false;
        }
        
        
    }
  public void BUYAMMO()
    {
        BulletsRemaining += 25;
    }
}

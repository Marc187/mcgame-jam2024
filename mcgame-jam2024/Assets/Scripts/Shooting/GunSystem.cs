using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    // bools
    bool shooting,  readyToShoot, reloading;

    // Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    // Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    public CameraShake camShake;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;


    public AudioSource shootSound;
    public AudioSource reloadSound;


    public GameObject bulletPrefab;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        MyInput();

        // Set text
        text.SetText(bulletsLeft + " / " + magazineSize);
    }

    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }

        // Shoot 
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        readyToShoot = false;

        // Spread 
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // Calculate Direction with spread 
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //Debug.DrawRay(fpsCam.transform.position, direction * range, Color.red, 2.0f);
        //// Raycast
        //if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        //{
        //    Debug.Log("Hello cunt");

        //    if (rayHit.collider.tag == "Enemy")
        //    {
        //        var enemyHit = rayHit.collider.GetComponent<SC_NPCEnemy>();
        //        enemyHit.ApplyDamage((float)damage);
        //        Debug.Log(enemyHit.npcHP);
        //    }
        //}

        GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, Quaternion.identity) as GameObject;
        var bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.direction = direction;



        // Camera Shake
        //StartCoroutine(camShake.Shake(camShakeDuration, camShakeMagnitude));
        var sound1 = Instantiate(shootSound);
        sound1.enabled = true;
        sound1.Play();
        Destroy(sound1, sound1.clip.length);
        // Graphics
        Instantiate(muzzleFlash, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        var sound1 = Instantiate(reloadSound);
        sound1.enabled = true;
        sound1.Play();
        Destroy(sound1, sound1.clip.length);
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}

using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class GunShoot : MonoBehaviour
{

    [SerializeField] 
    GameObject referenceProjectile;
    [SerializeField] 
    Transform barrel;

    Vector3 destination;

    // Update is called once per frame
    void Update()
    {
        // left click to shoot
        if (Input.GetMouseButtonDown(0))
        {
            OnFire();
        }
    }

    void CreateProjectile()
    {

        // makes the bullet actually come out of it's spawn point
        GameObject projectile = Instantiate(referenceProjectile, barrel.position, Quaternion.identity);
        
        // automatically destroy projectile after 10 seconds
        Destroy(projectile, 10);

        // propells projectile forwards
        projectile.GetComponent<Rigidbody>().AddForce((destination - projectile.transform.position).normalized * 500.0f, ForceMode.Impulse);

    }

    void OnFire()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            destination = hit.point;
        }
        else
        {

            destination = ray.GetPoint(1000);
        }

        Debug.DrawRay(ray.GetPoint(0),ray.direction,Color.red);

        CreateProjectile();

    }
}

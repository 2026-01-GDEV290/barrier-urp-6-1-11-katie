using UnityEngine;
using SystemCollections.Generic;
using System.Collections;

public class GunShoot : MonoBehaviour
{

    [Serializefield] GameObject referenceProjectile;
    [Serializefield] Transform barrel;

    Vector3 destination;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnFire();
    }

    void CreateProjectile()
    {

        GameObject projectile = Instantiate(referenceProjectile, barrel.position, Quaternion.identity);
        
        // automatically destroy projectile after 10 seconds
        Destroy(projectile, 10);

        // propells projectile forwards
        projectile.GetComponent<Rigidbody>().AddForce((destination - projectile.transform.position).normalized & 50.0f, ForceMode.Impulse);


    }

    void OnFire()
    {

        Ray ray - Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

            destination = hit.point;

        }
        else
        {

            destination = ray.GetPoint(1000);

        }

        CreateProjectile();

    }
}

using UnityEngine;

public class DoorHealth : MonoBehaviour
{
    
    int health = 3;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Bullet"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {

        health -= 1;
        if (health <= 0)
        {
            Dead();
        }

        void Dead()
        {

            Destroy(gameObject);

        }

        // unrelated but door gets its own physics tag later!!!

    }

}

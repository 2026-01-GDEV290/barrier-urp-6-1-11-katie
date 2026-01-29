using UnityEngine;

public class DoorHealth : MonoBehaviour
{
    
    int health = 3;

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

    }

}

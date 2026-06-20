using UnityEngine;

public abstract class Entity : MonoBehaviour
{

    public int health = 100;
    public bool dead = false;

    public virtual void TakeDamage(int damageToTake)
    {
        health -= damageToTake;
        if (health <= 0)
        {
            dead = true;
            health = 0;
        }
    }

}

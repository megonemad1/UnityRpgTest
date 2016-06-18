using UnityEngine;
using System.Collections;

public class LivingStatsManager : MonoBehaviour
{
    public float Health = 20;
    public float Stamina = 20;
    public float Manna = 20;
    public float MaxHealth=20;
    public float MaxStamina=20;
    public float MaxManna=20;
    public float WalkingSpeed=1;
    public float runningModifyer=2;
    public bool Is_Alive { get { return Health > 0; } set { Health = (value) ? MaxHealth : 0; } }
    
    void Update()
    {
        if (Health > MaxHealth)
        {
            Health = Mathf.Lerp(Health, MaxHealth, 0.1f);

        }
        if (Stamina > MaxStamina)
        {
            Stamina = Mathf.Lerp(Stamina, MaxStamina, 0.1f);
        }
        if (Manna > MaxManna)
        {
            Manna = Mathf.Lerp(Manna, MaxManna, 0.1f);
        }
    }
    



}

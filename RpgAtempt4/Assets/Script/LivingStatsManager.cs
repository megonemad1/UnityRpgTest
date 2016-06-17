using UnityEngine;
using System.Collections;

public class LivingStatsManager : MonoBehaviour
{
    public float Health { get { return health; } set { health = (value > MaxHealth) ? MaxHealth : value; } }
    public float Stamina { get { return stamina; } set { stamina = (value > MaxStamina) ? MaxStamina : value; } }
    public float Manna { get { return manna; } set { manna = (value > MaxManna) ? MaxManna : value; } }
    public float MaxHealth;
    public float MaxStamina;
    public float MaxManna;
    float health=20;
    float stamina=20;
    float manna=20;



}

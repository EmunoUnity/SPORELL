using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighting : MonoBehaviour
{
    public float normaldamage = 100;
    public EnemyNav enemyNav;

    private Animation help;
    

    public static bool comboOne;
    public static bool comboTwo;

    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    public Transform Projectile;
    private Transform myTransform;
    public Transform throwingPoint;

    // Start is called before the first frame update
    void Start()
    {
        //enemyNav = GetComponent<EnemyNav>();

        comboOne = false;
        comboTwo = false;

        help = gameObject.GetComponent<Animation>();
        
    }

    void Awake()
    {
        myTransform = throwingPoint;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(SimulateProjectile());
        }
        
        //help.Play("SwingOne");

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!comboOne && !comboTwo)
            {
                help.Play("SwingOne");
                comboOne = true;
                StartCoroutine(comboOnePause());
            }
            else if (comboOne && !comboTwo)
            {
                help.Play("SwingTwo");
                comboTwo = true;
                StartCoroutine(comboTwoPause());
                
            }
            else if (comboTwo && comboOne)
            {
                help.Play("SwingThree");
                comboOne = false;
                comboTwo = false;
            }
        }
        
    }

    public IEnumerator comboOnePause()
    {
        yield return new WaitForSeconds(2);
        comboOne = false;
    }

    public IEnumerator comboTwoPause()
    {
        yield return new WaitForSeconds(2);
        comboTwo = false;
    }

    IEnumerator SimulateProjectile()
    {
        // Short delay added before Projectile is thrown
        yield return new WaitForSeconds(1.5f);

        // Move projectile to the position of throwing object + add some offset if needed.
        Projectile.position = myTransform.position + new Vector3(0, 1.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }
}

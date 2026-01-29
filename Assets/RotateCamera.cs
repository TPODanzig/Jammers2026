using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public float speed = 0.1f;
    public float timer = 0;
    public bool targetINT;
    Vector3 relativePos;

    void Update()
    {
        timer += Time.deltaTime;
        if (targetINT == true)
        {
            relativePos = target.position - transform.position;
        }
        else
        {
            relativePos = target2.position - transform.position;
        }

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
       
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,  Time.deltaTime
);

        if (timer > 2)
        {
            Debug.Log("yay");
            timer = 0;
            if (targetINT == true)
            {
                targetINT = false;
            }
            else
            {
                targetINT = true;
            }

        }
    }
}


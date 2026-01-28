using Unity.VisualScripting;
using UnityEngine;

public class MoveSecurityCamera : MonoBehaviour
{
    [SerializeField] private Vector3 _position1;
    [SerializeField] private Vector3 _position2;

    [SerializeField] bool MovingTowards = true;



    //move gameobject between 2 points though code

    private void Start()
    {
        _position1 = this.gameObject.transform.position;
    }

    private void Update()
    {
        if (MovingTowards == true)
        {
            if ( this.transform.position == _position2)
            {
                MovingTowards = false;
            }
            
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, _position2, Time.deltaTime);
        }
           
         else
            {
                this.gameObject.transform.position = Vector3.MoveTowards(transform.position, _position1, Time.deltaTime);
            }

        }
    }


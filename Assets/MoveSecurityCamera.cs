using Unity.VisualScripting;
using UnityEngine;

public class MoveSecurityCamera : MonoBehaviour
{
    [SerializeField] private Vector3 _position1;
    [SerializeField] private Vector3 _position2;

    [SerializeField] bool MovingTowards = true;
    [SerializeField] private float _speed = 1;
    //move gameobject between 2 points though code

    private void Start()
    {
        _position1 = this.gameObject.transform.position;
    }

    private void Update()
    {
        if (MovingTowards == true)
        {
            if (this.transform.position == _position2)
            {
                MovingTowards = false;
            }

            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, _position2, _speed * Time.deltaTime);
        }
        else
        {
            if (this.transform.position == _position1)
            {
                MovingTowards = true;
            }
            this.gameObject.transform.position = Vector3.MoveTowards(transform.position, _position1, _speed * Time.deltaTime);

        }
    }
}


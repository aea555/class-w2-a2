using UnityEngine;

public class Chase : MonoBehaviour
{
    public GameObject target;
    public float speed = 8f;
    public float fov = 60f;
    public float viewDistance = 10f;
    public float searchTurnSpeed = 25f;
    public float catchDistance = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0;

        if (CanSeeTarget(direction))
        {
            transform.forward = direction.normalized;
            if (direction.sqrMagnitude > catchDistance * catchDistance)
            {
                transform.position += speed * Time.deltaTime * direction.normalized;
            }
            else 
                Debug.Log("domuz balkabağını yedi");
        }
        else
        {
            transform.Rotate(0, searchTurnSpeed * Time.deltaTime, 0);
        }

    }

    bool CanSeeTarget (Vector3 direction)
    {
        if (direction.sqrMagnitude > viewDistance * viewDistance) return false;
        float angle = Vector3.Angle(transform.forward, direction);
        return angle <= fov / 2f;
    }
}

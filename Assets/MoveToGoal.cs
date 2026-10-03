using UnityEngine;

public class MoveToGoal : MonoBehaviour
{
    public GameObject goal;
    public float speed = 4f;
    public float stopDistance = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // hedef yoksa bişey yapma
        if (goal == null) return;

        // kalan mesafe vektörü
        Vector3 direction = goal.transform.position - transform.position;

        // hedefe doğru baksın
        if (direction != Vector3.zero)
            transform.forward = direction.normalized;

        // sadece durma mesafesinden uzaktaysa ilerlet
        if (direction.sqrMagnitude > stopDistance * stopDistance)
            transform.position = Vector3.MoveTowards(transform.position, goal.transform.position, speed * Time.deltaTime);



    }
}

using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField]private float timer = 3.0f;
    private bool isExploded = false;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Explode()
    {
        isExploded = true;
        // Add explosion force to nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5.0f);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(700.0f, transform.position, 5.0f);
            }
        }
        // Destroy the bomb object after explosion
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;
        timer -= deltaTime;
        if (timer <= 0 && !isExploded)
        {
            Explode();
        }
    }
}

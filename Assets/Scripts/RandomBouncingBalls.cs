using UnityEngine;

public class RandomBouncingBalls : MonoBehaviour
{
    public float moveSpeed = 5f; // سرعة الحركة
    public float rotationSpeed = 100f; // سرعة الدوران
    public float boundaryX = 5f; // حدود الحركة على محور X
    public float boundaryZ = 5f; // حدود الحركة على محور Z

    void Start()
    {
        // قم بتحريك كل كرة باتجاه عشوائي عند بداية اللعبة
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            rb.velocity = Random.onUnitSphere * moveSpeed;
            rb.angularVelocity = Random.onUnitSphere * rotationSpeed;
        }
    }

    void Update()
    {
        // يقوم بتحديث حركة الكرات
        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            Vector3 currentPosition = child.position;

            // حساب اتجاه الحركة
            Vector3 moveDirection = rb.velocity.normalized;

            // يتم تغيير اتجاه الحركة عند التصادم مع أي كرة أخرى
            RaycastHit hit;
            if (Physics.Raycast(currentPosition, moveDirection, out hit, 1f))
            {
                if (hit.collider.CompareTag("Ball"))
                {
                    Vector3 newDirection = Vector3.Reflect(moveDirection, hit.normal);
                    rb.velocity = newDirection * moveSpeed;
                }
            }

            // تحديد حدود الحركة
            float clampedX = Mathf.Clamp(currentPosition.x, -boundaryX, boundaryX);
            float clampedZ = Mathf.Clamp(currentPosition.z, -boundaryZ, boundaryZ);

            // تحديث موقف الكرة بشكل صحيح
            rb.position = new Vector3(clampedX, currentPosition.y, clampedZ);
        }
    }
}

using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private IEnumerator Start()
    {
        while (true)
        {
            Move();

            yield return null;
        }
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = transform.right * x + transform.forward * z;

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}

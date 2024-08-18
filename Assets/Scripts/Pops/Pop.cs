using System.Collections;
using UnityEngine;

public enum PopType
{
    Cube,
    Sphere
}

public class Pop : MonoBehaviour
{
    private Pop pop;
    public Pop POP => pop;

    [SerializeField]
    private int power;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private PopType popType;

    public PopType PopType => popType;

    private bool isPushPop;

    private void Awake()
    {
        pop = this;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            if (rigidbody.velocity.y <= 0.5f)
            {
                PushPop();
            }

            yield return null;
        }
    }

    private void PushPop()
    {
        if (!isPushPop)
        {
            isPushPop = true;

            StartCoroutine(PushPopCoroutine());
        }
    }

    public void FreePop()
    {
        gameObject.SetActive(false);

        transform.position = Vector3.zero;
    }

    private IEnumerator PushPopCoroutine()
    {
        rigidbody.AddForce(Vector3.up * power, ForceMode.Impulse);

        yield return new WaitForSeconds(0.5f);

        rigidbody.AddForce(Vector3.down * power * 0.25f, ForceMode.Impulse);

        yield return new WaitForSeconds(0.25f);

        isPushPop = false;
    }
}

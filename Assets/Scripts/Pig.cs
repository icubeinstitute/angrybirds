using UnityEngine;

public class Pig : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            GetComponentInParent<PigContainer>().OnPigDestroy();
            Destroy(gameObject);
        }
    }
}

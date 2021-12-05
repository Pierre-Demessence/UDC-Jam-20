using UnityEngine;

public class DeleteBadStuff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
            Destroy(other.gameObject);
    }
}
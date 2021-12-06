using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HitDetection : MonoBehaviour
{
    private static readonly int _invulnerable1 = Animator.StringToHash("Invulnerable");
    [SerializeField] private float _knockbackForce = 1f;
    [SerializeField] private float _invulnerabilityTime = 1.5f;
    [SerializeField] private float _invincibilityDeltaTime = 0.15f;

    private bool _invulnerable;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHit();
            other.tag = "Untagged";
        }
    }

    private void EnemyHit()
    {
        if (_invulnerable) return;

        StartCoroutine(HandleInvulnerability());
        transform.Translate(Vector2.left * _knockbackForce);
    }

    private IEnumerator HandleInvulnerability()
    {
        _invulnerable = true;

        for (float i = 0; i < _invulnerabilityTime; i += _invincibilityDeltaTime)
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;

            yield return new WaitForSeconds(_invincibilityDeltaTime);
        }

        _spriteRenderer.enabled = true;
        _invulnerable = false;
    }
}
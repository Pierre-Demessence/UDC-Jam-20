using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10;
    private bool _isGrounded;
    private AudioSource _jumpAudioSource;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _jumpAudioSource = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) _isGrounded = false;
    }

    public void OnJump()
    {
        DoJump();
    }

    private void DoJump()
    {
        if (!_isGrounded) return;

        _jumpAudioSource.Play();
        _rigidbody2D.AddRelativeForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}
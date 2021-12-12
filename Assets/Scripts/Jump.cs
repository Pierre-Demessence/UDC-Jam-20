using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private AudioSource _jumpAudioSource;
    private bool _isGrounded;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Animator animator;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            animator.SetBool("Jump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
            animator.SetBool("Jump", true);
        }
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
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private float _minDuration = 0.5f;
    [SerializeField] private float _maxDuration = 2;
    [SerializeField] private AudioSource _jumpAudioSource;
    private bool _isGrounded;
    private bool _isJumpButtonHold;
    private bool _isJumpCancelled;
    private bool _isJumping;
    private float _jumpStartTime = -float.MinValue;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_isJumpButtonHold && _isGrounded && !_isJumping)
        {
            _jumpAudioSource.Play();
            _jumpStartTime = Time.time;
            _isJumping = true;
            _isJumpCancelled = false;
        }

        if (!_isJumping) return;

        var jumpDuration = Time.time - _jumpStartTime;
        if (jumpDuration > _maxDuration) return;

        if (_isJumpButtonHold && !_isJumpCancelled || jumpDuration <= _minDuration) _rigidbody2D.AddRelativeForce(Vector2.up * _jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) _isGrounded = false;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started) _isJumpButtonHold = true;
        else if (context.phase == InputActionPhase.Canceled)
        {
            _isJumpButtonHold = false;
            _isJumpCancelled = true;
        }
    }
}
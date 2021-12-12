using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10;
    [SerializeField] private float _fallForce = 10;
    [SerializeField] private float _minDuration = 0.5f;
    [SerializeField] private float _maxDuration = 2;

    [SerializeField] private AudioSource _jumpAudioSource;
    private bool _isGrounded;
    private bool _isJumpButtonHold;
    private bool _isJumpCancelled;
    private bool _isJumping;
    private float _jumpStartTime = -float.MinValue;
    private Rigidbody2D _rigidbody2D;
    private ScoreManager _scoreManager;

    private void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
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

        if (_isJumpButtonHold && jumpDuration < _maxDuration / _scoreManager.ScoreSpeedModifier && !_isJumpCancelled || jumpDuration <= _minDuration / _scoreManager.ScoreSpeedModifier) _rigidbody2D.velocity = Vector2.up * _jumpForce * _scoreManager.ScoreSpeedModifier;
        else _rigidbody2D.velocity = Vector2.down * _fallForce * _scoreManager.ScoreSpeedModifier;
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
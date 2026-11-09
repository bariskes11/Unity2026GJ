using Cysharp.Threading.Tasks;
using PrimeTween;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;

    //private InputSystem_Actions inputActions;
    Rigidbody2D rigidBody2d;
    private Vector2 inputVector;
    private bool isDashing = false;
    private Vector2 dashDirection;
    private Vector2 lastMoveDirection = Vector2.right;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing) return;
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        inputVector = new Vector2(hInput, vInput).normalized;
        if (inputVector != Vector2.zero)
        {
            lastMoveDirection = inputVector;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            dashDirection = inputVector != Vector2.zero ? inputVector : lastMoveDirection;
            PerformDashAsync(this.GetCancellationTokenOnDestroy()).Forget();
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            rigidBody2d.linearVelocity = dashDirection * dashSpeed * Time.deltaTime;
        }
        else
        {
            rigidBody2d.linearVelocity = inputVector * moveSpeed * Time.deltaTime;
        }


    }

    private async UniTaskVoid PerformDashAsync(CancellationToken ct)
    {
        isDashing = true;

        Tween.StopAll(transform);
        transform.localScale = Vector3.one;

        // 1. Rotate the circle's local X-axis (right) to point directly at dashDirection
        transform.right = dashDirection;

        // 2. Stretch along local X (forward) and squash local Y (sides)
        Tween.Scale(transform, endValue: new Vector3(1.4f, 0.6f, 1f), duration: dashDuration / 2f, ease: Ease.OutQuad, cycles: 2, cycleMode: CycleMode.Yoyo);

        try
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(dashDuration), cancellationToken: ct);
        }
        catch (System.OperationCanceledException)
        {
        }
        finally
        {
            isDashing = false;
        }
    }

}

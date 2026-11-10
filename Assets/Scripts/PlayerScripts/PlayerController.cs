using Cysharp.Threading.Tasks;
using PrimeTween;
using System;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float speedModeMoveSpeed;
    [SerializeField] GameObject speedTrail;
    [SerializeField] float speedModeTimeOut;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashDuration;
    

    //private InputSystem_Actions inputActions;
    Rigidbody2D rigidBody2d;
    private Vector2 inputVector;
    private bool isDashing = false;
    private Vector2 dashDirection;
    private Vector2 lastMoveDirection = Vector2.right;
    private bool isSpeedBonusMode = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing) return;
        
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");
        inputVector = new Vector2(hInput, vInput).normalized;
        if (inputVector != Vector2.zero)
        {
            lastMoveDirection = inputVector;
            transform.up = inputVector;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            PerformDashAsync(this.GetCancellationTokenOnDestroy()).Forget();
        }
    }
    private void FixedUpdate()
    {
        
        
        if (isDashing)
        {
            float currentDashSpeed = isSpeedBonusMode ? dashSpeed : dashSpeed * 1.4F;
            transform.up = lastMoveDirection;
            rigidBody2d.linearVelocity = lastMoveDirection * dashSpeed * Time.fixedDeltaTime;
        }
        else
        {
            float currentMove = isSpeedBonusMode ? speedModeMoveSpeed : moveSpeed;
            rigidBody2d.linearVelocity = inputVector * currentMove * Time.fixedDeltaTime;
        }


    }

    private async UniTaskVoid PerformDashAsync(CancellationToken ct)
    {
        isDashing = true;

        Tween.StopAll(transform);
        transform.localScale = Vector3.one;

        
        transform.right = dashDirection;

        
        await Tween.Scale(transform, endValue: new Vector3(1.4f, 0.6f, 1f), duration: dashDuration / 2f, ease: Ease.OutQuad, cycles: 2, cycleMode: CycleMode.Yoyo);

        try
        {
            await UniTask.Delay(System.TimeSpan.FromSeconds(dashDuration), cancellationToken: ct);
            transform.localScale = Vector3.one;

        }
        catch (System.OperationCanceledException)
        {
        }
        finally
        {
            transform.localScale = Vector3.one;
            isDashing = false;
        }
    }

    public void EnableSpeedBoost()
    {
        isSpeedBonusMode = true;
        speedTrail.gameObject.SetActive(true);
        TimeoutAndDisable();




    }
    async UniTask TimeoutAndDisable()
    {

        await UniTask.Delay(TimeSpan.FromSeconds(speedModeTimeOut));
        isSpeedBonusMode = false;
        speedTrail.gameObject.SetActive(false);





    }

}

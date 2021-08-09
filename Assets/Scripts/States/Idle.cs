using UnityEngine;

public class Idle : Grounded
{
    private float _horizontalInput;

    public Idle (MovementSM stateMachine) : base("Idle", stateMachine) {}

    public override void Enter()
    {
        base.Enter();
        sm.spriteRenderer.color = Color.black;
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(sm.movingState);
    }

}

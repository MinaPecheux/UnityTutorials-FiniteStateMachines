using UnityEngine;

public class Moving : Grounded
{
    private float _horizontalInput;

    public Moving(MovementSM stateMachine) : base("Moving", stateMachine) {}

    public override void Enter()
    {
        base.Enter();
        sm.spriteRenderer.color = Color.red;
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(sm.idleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = sm.rigidbody.velocity;
        vel.x = _horizontalInput * ((MovementSM)stateMachine).speed;
        sm.rigidbody.velocity = vel;
    }

}

using UnityEngine;

public class Jumping : BaseState
{
    private MovementSM _sm;

    private bool _grounded;
    private int _groundLayer = 1 << 6;

    public Jumping(MovementSM stateMachine) : base("Jumping", stateMachine)
    {
        _sm = (MovementSM)this.stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _sm.spriteRenderer.color = Color.green;

        Vector2 vel = _sm.rigidbody.velocity;
        vel.y += _sm.jumpForce;
        _sm.rigidbody.velocity = vel;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (_grounded)
            stateMachine.ChangeState(_sm.idleState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        _grounded = _sm.rigidbody.velocity.y < Mathf.Epsilon && _sm.rigidbody.IsTouchingLayers(_groundLayer);
    }

}

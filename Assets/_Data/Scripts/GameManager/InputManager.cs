using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : DinoBehaviourScript
{
    [Header("Input Manager")]
    private int On = 0;
    protected static InputManager instance;
    public static InputManager Instance => instance;
    [SerializeField] protected float inputHorizontal;
    public float InputHorizontal => inputHorizontal;
    [SerializeField] protected float inputVertical;
    public float InputVertical => inputVertical;
    [SerializeField] protected bool inputSwitchWeapon;
    public bool InputSwitchWeapon => inputSwitchWeapon;
    [SerializeField] protected bool inputAttack;
    public bool InputAttack => inputAttack;
    [SerializeField] protected bool inputDash = true;
    public bool InputDash => inputDash;
    protected override void Awake()
    {
        base.Awake();
        if (InputManager.instance != null) Debug.LogWarning("Only 1 InputManager allow exist");
        InputManager.instance = this;
    }
    protected void Update()
    {
        this.GetInputAttack();
        this.GetInputMovement();
        this.GetInputChangeWeapon();
        this.GetInputDash();
        this.GetInputHealing();
    }
    public void SetAttack(bool _bool)
    {
        this.inputAttack = _bool;
    }
    public void SetDash(bool _bool)
    {
        this.inputDash = _bool;
    }
    protected void GetInputMovement()
    {
        this.inputHorizontal = Input.GetAxisRaw("Horizontal");
        this.inputVertical = Input.GetAxisRaw("Vertical");
    }
    protected void GetInputChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R) && this.On == 0)
        {
            this.inputSwitchWeapon = true;
            this.On = 1;
        }
        else if (Input.GetKeyDown(KeyCode.R) && this.On == 1)
        {
            this.inputSwitchWeapon = false;
            this.On = 0;
        }
    }
    protected void GetInputAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) this.inputAttack = true;
    }
    protected void GetInputDash()
    {
        if (Input.GetKeyDown(KeyCode.Space)) this.inputDash = false;
    }
    public bool GetInputHealing()
    {
        if (Input.GetKeyDown(KeyCode.F)) return true;

        if (Input.GetKeyUp(KeyCode.F)) return false;

        return false;
    }
}

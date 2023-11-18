using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimStateManager : MonoBehaviour
{
    float xAxis, yAxis;
    [SerializeField] Transform camFollowPos;
    [SerializeField] float mouseSens = 1;

    AimBaseState currentState;
    public HipFireState Hip = new HipFireState();
    public AimState Aim = new AimState();

    [SerializeField] Transform aimPos;
    [SerializeField] float aimSmoothSpeed = 20;
    [SerializeField] LayerMask aimMask;

    [HideInInspector] public Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        SwitchState(Hip);
    }

    // Update is called once per frame
    void Update()
    {
        //xAxis.Update(Time.deltaTime);
        //yAxis.Update(Time.deltaTime);
        xAxis += Input.GetAxisRaw("Mouse X") * mouseSens;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSens;
        yAxis = Mathf.Clamp(yAxis, -80, 80);

        Vector2 screenCentre = new Vector2(Screen.width/2, Screen.height/2);
        Ray ray = Camera.main.ScreenPointToRay(screenCentre);

        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {
            aimPos.position =  Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
        }

        currentState.UpdateState(this);

    }

    private void LateUpdate()
    {
        camFollowPos.localEulerAngles = new Vector3(yAxis, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }

    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}

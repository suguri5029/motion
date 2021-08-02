using UnityEngine;

public class Climb : MonoBehaviour
{
    [SerializeField] private bool onWall;
    [SerializeField] private float input;

    private Vector3 targetPos;
    private Vector3 headPos;
    private RaycastHit hit;
    private RaycastHit headHit;

    private float climbUpSpeed = 0.005f;
    private float climbDownSpeed = 0.02f;

    #region AnimationIK
    public Transform leftHand, rightHand, leftFoot, rightFoot, head;

    private RaycastHit hitInfoLH, hitInfoRH, hitInfoLF, hitInfoRF;

    /*    // internal vars to control IK behavior
        private float handIKSmooth = 3f;
        private float handWeight = 0;
        private float weightRH = 1;
        private float deltaLF = 0;
        private float deltaRF = 0;

        [SerializeField] private bool runFootIK = true;
        private float WallOfssetLF = 0.48f;
        private float WallOfssetRF = 0.48f;*/

    private Vector3 targetLH;
    private Vector3 targetRH;
    private Vector3 targetLF;
    private Vector3 targetRF;
    #endregion

    public float WallRayDistance = 1f;
    public float wallOffset = 0.5f;
    public Transform climbHelper;

    public Animator anim;

    void Start()
    {
        CheckClimb();
    }

    void Update()
    {
        if (!onWall)
        {
            SetBodyPositionToWall();
        }
        else
        {
            UpdateTarget();
            FixBodyPos();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-headHit.normal), 0.2f);
            MoveHandle();
        }
    }

    void OnAnimatorIK(int layerIndex)
    {

    }

    private void UpdateTarget()
    {
        if (Physics.Raycast(leftHand.position, leftHand.forward, out hitInfoLH, .5f))
        {
            targetLH = hitInfoLH.point;
        }

        if (Physics.Raycast(rightHand.position, rightHand.forward, out hitInfoRH, .5f))
        {
            targetRH = hitInfoRH.point;
        }
    }

    private void SetBodyPositionToWall()
    {
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            onWall = true;
            transform.position = targetPos;
            return;
        }

        Vector3 lerpTargetPos = Vector3.MoveTowards(transform.position, targetPos, .2f);
        transform.position = lerpTargetPos;
    }

    private void FixBodyPos()
    {
        Vector3 localClimbHelperPos = transform.InverseTransformPoint(climbHelper.position);
        Vector3 localHeadPos = new Vector3(localClimbHelperPos.x, localClimbHelperPos.y, 0f);
        headPos = transform.TransformPoint(localHeadPos);

        Debug.DrawRay(headPos, transform.forward * 1f, Color.red);
        if (Physics.SphereCast(headPos, 0.1f, transform.forward, out hit, 1f))
        {
            Vector3 offset = transform.position - climbHelper.position;
            if (Vector3.Distance(transform.position, hit.point + offset) > 0.05f)
            {
                transform.position = hit.point + offset;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(headPos, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(hit.point, .1f);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(hitInfoLH.point, .1f);
        Gizmos.DrawSphere(hitInfoRH.point, .1f);
    }

    private bool CheckClimb()
    {
        Vector3 origin = transform.position;
        Vector3 dir = transform.forward;

        if (Physics.Raycast(origin, dir, out headHit, WallRayDistance))
        {
            InitClimb(headHit);
            return true;
        }

        anim.CrossFade("Hanging_Idle", 0.2f);
        return false;
    }

    private void InitClimb(RaycastHit hit)
    {
        onWall = false;
        targetPos = hit.point + hit.normal * wallOffset;
    }

    private void MoveHandle()
    {
        input = Input.GetAxis("Vertical");
        bool move = true;

        if (Mathf.Abs(input) > 0.05f && move)
        {
            anim.SetFloat("InputVertical", input);
            float dir = input > 0f ? 1.0f : -1.0f;
            transform.Translate(head.up * dir * climbDownSpeed);
        }
        else
        {
            anim.SetFloat("InputVertical", 0);
        }
    }
}

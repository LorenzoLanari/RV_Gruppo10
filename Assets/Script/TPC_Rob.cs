using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TPC_Rob : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 3f;
    
    private Rigidbody _rigidbody;
    private Vector3 _inputVector;
    private float _inputSpeed;
    private Vector3 _targetDirection;
    private Vector3 newDir;
    private Animator _animator;
    private float distToGround;
    private bool jumping ;
    private bool patch = false;

    public bool shooting = false;
    private float jumpHeight = 2f;
    private float gravity = 9.8f;

    void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (patch)
        {
            if (IsGrounded())
            {
                jumping = false;
                _animator.SetBool("grounded", true);
            }
        }
        HandleInput();

        updateAnimations();
        //Compute direction According to Camera Orientation
        _targetDirection = _cameraT.TransformDirection(_inputVector).normalized;
        _targetDirection.y = 0f;
    }

    private void FixedUpdate()
    {
       
        newDir = Vector3.RotateTowards(transform.forward, _targetDirection, _rotationSpeed * Time.fixedDeltaTime, 0f);
          
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !jumping)
        {
            jumping = true;
            HandleJumping();

        } 
        

        Debug.DrawRay(transform.position + transform.up * 3f, _targetDirection * 5f, Color.red);
        Debug.DrawRay(transform.position + transform.up * 3f, newDir * 5f, Color.blue);

       if (!jumping)
        {
            if (!shooting)
            {
             _rigidbody.MoveRotation(Quaternion.LookRotation(newDir));
             _rigidbody.MovePosition(_rigidbody.position + transform.forward * _inputSpeed * _speed * Time.fixedDeltaTime);

            }
            else
            {
               _rigidbody.MovePosition(_rigidbody.position + _inputVector * _inputSpeed * _speed * Time.fixedDeltaTime);
            }

        }

       if(_rigidbody.velocity.y < 0.1f)
        {
            _rigidbody.AddForce(-Vector3.up* CalculateVerticalJump(), ForceMode.Force);
        }
    }
    private void HandleInput() {

        //Handle the Input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _inputVector = new Vector3(h, 0, v);
        _inputSpeed = Mathf.Clamp(_inputVector.magnitude, 0f, 1f);

        //RUNNING
        if (Input.GetKey(KeyCode.LeftShift))
            _inputSpeed *= 3;

        if (Input.GetKey(KeyCode.Mouse1))
            shooting = true;
        else
            shooting = false;
    }

    private void updateAnimations() {
        _animator.SetFloat("speed", _inputSpeed);

        if (shooting)
            _animator.SetBool("shooting_prep", true);
        else
            _animator.SetBool("shooting_prep", false);
    }
    
    bool IsGrounded()
    {
     
        return Physics.Raycast(_rigidbody.position, -Vector3.up, distToGround);
    }

    private void Land() {
        patch = true;
        _rigidbody.AddForce(Time.fixedDeltaTime * newDir*5000f*_inputSpeed, ForceMode.Force);
    }     

    private void HandleJumping()
    {
        patch = false;
        if (_inputSpeed > 1.1f)
        {
            StartCoroutine(ActualJump(0f,2f,0.81f,0.2f));
        }
        else if (_inputSpeed <= 1f) 
        {
            StartCoroutine(ActualJump(0.6f, 1.5f, 1f, 0.2f));          
        }
    }

    private IEnumerator ActualJump(float jumpingWait ,float jumpPower, float duration, float landingWait) {
        _animator.SetBool("grounded", false);
        yield return new WaitForSeconds(jumpingWait);
        _rigidbody.velocity = new Vector3(newDir.x , CalculateVerticalJump(),newDir.z);
        Invoke("Land", landingWait);        
    }

    private float CalculateVerticalJump()
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }


}

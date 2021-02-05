using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TPC_Rob : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 3f;
    [SerializeField] private float distToGround;
    [SerializeField] private Transform feet;

    public LayerMask groundCheckMask;
    private Grab _grab;
    private Rigidbody _rigidbody;
    private Vector3 _inputVector;
    private float _inputSpeed;
    private Vector3 _targetDirection;
    private Vector3 newDir;
    private Animator _animator;
    private bool jumping ;
    private bool patch = false;
    private bool dancing = false;
    public bool shooting = false;
    public bool dead = false; 
    private float jumpHeight = 2f;
    private float gravity = 9.8f;
    private  Rob_Health health;

    void Start()
    {

        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _grab = GetComponent<Grab>();
        health = GetComponent<Rob_Health>();
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

        if(!dead)
          HandleInput();

        updateAnimations();
        //Compute direction According to Camera Orientation
        _targetDirection = _cameraT.TransformDirection(_inputVector).normalized;
        _targetDirection.y = 0f;

        if(health.GetCurrentHealth() <= 0)
        {
            dead = true;
        }


    }

    private void FixedUpdate()
    {

        if (!dead)
        {
                newDir = Vector3.RotateTowards(transform.forward, _targetDirection, _rotationSpeed * Time.fixedDeltaTime, 0f);
        

                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !jumping && !dancing && !_grab.grabbing)
                {
                    jumping = true;
                    HandleJumping();

                } 
        
                Debug.DrawRay(transform.position + transform.up * 3f, _targetDirection * 5f, Color.red);
                Debug.DrawRay(transform.position + transform.up * 3f, newDir * 5f, Color.blue);

               if (!jumping && _grab.mutex &&!dancing)
                {
                    if (!shooting)
                    {

                     _rigidbody.MoveRotation(Quaternion.LookRotation(newDir));
                     _rigidbody.MovePosition(_rigidbody.position + transform.forward * _inputSpeed * _speed * Time.fixedDeltaTime);
               
                    }
                    else
                    {
   
                        _rigidbody.MovePosition(_rigidbody.position + transform.TransformDirection(_inputVector)  * _inputSpeed * _speed * Time.fixedDeltaTime);
                    }

                }

               if(_rigidbody.velocity.y < 0.1f)
                {
                    _rigidbody.AddForce(-Vector3.up* CalculateVerticalJump(), ForceMode.Force);
                }

        }
    }
    private void HandleInput() {

        //Handle the Input
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            _inputVector = new Vector3(h, 0, v);

            _inputSpeed = Mathf.Clamp(_inputVector.magnitude, 0f, 1f);
        if (!_grab.mutex)
            _inputSpeed = 0;
        //RUNNING
        if (Input.GetKey(KeyCode.LeftShift) && !_grab.grabbing &&!dancing &&!shooting )
            _inputSpeed *= 3;

        if (Input.GetKey(KeyCode.Mouse1) && !_grab.grabbing && !dancing &&_inputSpeed<=1)
            shooting = true;
        else
            shooting = false;

        if (Input.GetKeyDown(KeyCode.B) && !_grab.grabbing && !shooting && (_inputSpeed <0.1) && !dancing)
        {
            dancing = true;
            Invoke("Stop_Dancing", 7f);
        }

    }

    private void updateAnimations() {
       
        _animator.SetFloat("speed", _inputSpeed);

        if (shooting)
            _animator.SetBool("shooting_prep", true);
        else
            _animator.SetBool("shooting_prep", false);

        if(_grab.grabbing)
            _animator.SetBool("grab", true);
        else
            _animator.SetBool("grab", false);

        if (dancing)
            _animator.SetBool("dance", true);
        if (dead)
            _animator.SetTrigger("death");
        

    }
    

    bool IsGrounded()
    {
        Debug.DrawRay(feet.position, distToGround * -Vector3.up,Color.red);
        return Physics.Raycast(feet.position , -Vector3.up, distToGround, groundCheckMask);
    }
    private void Stop_Dancing()
    {
       
        dancing = false;
        _animator.SetBool("dance", false);
    }

    private void Land() {
        patch = true;
        _rigidbody.AddForce(Time.fixedDeltaTime * newDir*4000f*_inputSpeed, ForceMode.Force);
    }     

    private void HandleJumping()
    {
        patch = false;
        if (_inputSpeed > 2.5f)
        {
            StartCoroutine(ActualJump(0f,0.2f));
        }
        else if (_inputSpeed <= 1f) 
        {
            StartCoroutine(ActualJump(0.6f,  0.2f));          
        }
    }

    private IEnumerator ActualJump(float jumpingWait , float landingWait) {
        _animator.SetBool("grounded", false);
        yield return new WaitForSeconds(jumpingWait);
        _rigidbody.velocity = new Vector3(newDir.x*_inputSpeed*1.7f , CalculateVerticalJump(),newDir.z*_inputSpeed*1.7f);
        Invoke("Land", landingWait);        
    }

    private float CalculateVerticalJump()
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }


}

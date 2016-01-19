using UnityEngine;
using System.Collections;

public class FSM : MonoBehaviour {

	States currentState;

	//guard states
	States idleState;
	States lostState;
	States distractedState;
	States chasingState;
	States alertedState;

	States recoverState;
	States runState;
	States scaredState;
	States tripState;
	States crouchState;

    public Vector3 startPos; // stores start position for guard to return to
    public GameObject vision; // child object of guard, used for vision
	public Transform[] wayPoints; // waypts for gaurds to patrol around
    public int wayPtIndex = 0; //used to traverse through the array
    public Transform target; // stores information of target
    public float fRadius = 1.0f; // radius of the target to check if the guard has arrived at target position
    public float fSpeed = 5.0f; // speed of the guard
	public float fTimePassed; // check how much time has passed
    public GameObject guard; 
    public SphereCollider detection; // sphere collider of guard used to detect its surroundings
    public float fDist; // distance used to check the distance between the guard and the target
    public Animator anim;
    public NavMeshAgent agent; // used to store agent information
    public GameObject questionMark;

    public enum State // available states
    {
        _Alerted,
        _Chasing,
        _Crouch,
        _Distracted,
        _Idle,
        _Lost,
        _Recover,
        _Run,
        _Scared,
        _Trip
    }

	// Use this for initialization
	void Start () {

        //instantiating the states
		idleState = new Idle (this);
		lostState = new Lost (this);
		distractedState = new Distracted (this);
		chasingState = new Chasing (this);
		alertedState = new Alerted (this);

		recoverState = new Recover (this);
		runState = new Run (this);
		scaredState = new Scared (this);
		tripState = new Trip (this);
		crouchState = new Crouch (this);

        //obtain components from the guard
        detection = GetComponent<SphereCollider>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        //stop rotation of guard when navigating
        agent.updateRotation = false;

        vision = transform.FindChild("Vision").gameObject; //obtain child object info
        startPos = transform.position; //obtain the start position of the guard

        //set first state as idle

        currentState = idleState;
        changeState(State._Idle);

    }
	
	// Update is called once per frame
	void Update () {
        currentState.Execute (); // Execute state's functions
	}

	public void changeState(State newState)
	{
        currentState.Exit(); // exit current state
        fTimePassed = 0; // reset timer

        // Assign next state based of enum
        switch(newState)
        {
            case State._Alerted:
                currentState = alertedState;
                break;
            case State._Chasing:
                currentState = chasingState;
                break;
            case State._Crouch:
                currentState = crouchState;
                break;
            case State._Distracted:
                currentState = distractedState;
                break;
            case State._Idle:
                currentState = idleState;
                break;
            case State._Lost:
                currentState = lostState;
                break;
            case State._Recover:
                currentState = recoverState;
                break;
            case State._Run:
                currentState = runState;
                break;
            case State._Scared:
                currentState = scaredState;
                break;
            case State._Trip:
                currentState = tripState;
                break;
        }

        currentState.Enter(); // start new state
	}

    // timer
    public float getTime()
    {
        return fTimePassed += Time.deltaTime;
    }

    // trigger collider of the guard's detection
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // detects player
        {
            Debug.Log("Exclamation mark");
            changeState(State._Alerted);
        }

        else if (other.CompareTag("Ghost")) // detects ghost
        {
            Debug.Log("Ghost spotted");
            changeState(State._Scared);
        }

    }

    void OnTriggerStay (Collider other)
    {
        if (other.CompareTag("TripItem")) // touches item
        {
            fDist = Vector3.Distance(transform.position, other.transform.position);
            if (fDist < 0.5f)
            {
                Debug.Log("tripped");
                Destroy(other.gameObject);
                changeState(State._Trip);
            }
        }
    }

    public void look(State change) // used for guard to look around
    {
        Vector3 direction = vision.transform.right; // starting direction

        RaycastHit hit;
        Debug.DrawRay(vision.transform.position, direction);
        vision.transform.Rotate(Vector3.forward * Time.deltaTime * 80); // rotate vision for raycast to look around
        if (Physics.Raycast(vision.transform.position, direction, out hit, 30)) // if raycast hits something
        {
            if (hit.collider.CompareTag("Ghost")) // sees a ghost
            {
                target = hit.transform; //set seen as target
                changeState(change);
            }

            else if (hit.collider.CompareTag("Player")) // sees a player
            {
                target = hit.transform; //set seen as target
                changeState(change);
            }
        }
    }

    public void facing()
    {
        if (transform.position.z < target.position.z && // move backwards
            Square(transform.position.z - target.position.z) >
            Square(transform.position.x - target.position.x))
        {
            anim.SetInteger("Direction", 3);
        }

        else if (transform.position.z > target.position.z && // move forward
                 Square(transform.position.z - target.position.z) >
                 Square(transform.position.x - target.position.x))
        {
            anim.SetInteger("Direction", 0);
        }

        else if (transform.position.x > target.position.x && // move left
                 Square(transform.position.z - target.position.z) <
                 Square(transform.position.x - target.position.x))
        {
            anim.SetInteger("Direction", 2);
        }

        else if (transform.position.x < target.position.x && // move right
                 Square(transform.position.z - target.position.z) <
                 Square(transform.position.x - target.position.x))
        {
            anim.SetInteger("Direction", 1);
        }

    }

    public float Square(float val)
    {
        return val * val;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject playerModel;
    private Rigidbody body;
    private GameObject environment;
    private GameController gameController;
    public GameObject[] platforms;
    public bool specialLighting = false;

    public float health = 50;
    public float speed = 3;
    private int coffeeCount = 0;
    private bool canJump = false;
    private bool canAttack = false;

    // UI
    private UIHandler uiHandler;
    public GameObject canvas;
    private GameObject healthText;
    private Text hText;


    private int groundContactCount = 0;
    private float time = 0;
    private float launchTime = 0;
    private float jumpDelay = 1.0f;
    private float jumpTime;
    private bool start = false;
    private bool animationLock = false;
    private Animator anim;
    private Animator[] animPlatforms;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    private bool inRange = false;
    private GameObject currentEnemy;


    public bool IsGrounded() {

        return Physics.CheckSphere(groundCheck.position, .1f, ground);

    }

    // Start is called before the first frame update
    void Start()
    {
        uiHandler = GetComponent<UIHandler>();
        healthText = canvas.transform.Find("Health").gameObject;
        hText = healthText.GetComponent<Text>();
        anim = playerModel.GetComponent<Animator>();
        anim.SetBool("isJumping", false);
        anim.SetBool("isWalkingForwards", false);
        anim.SetBool("isWalkingBackwards", false);
        anim.SetBool("isFalling", false);
        body = GetComponent<Rigidbody>();
        environment = GameObject.Find("Environment");


        animPlatforms = new Animator[platforms.Length];

        for (int i = 0; i < platforms.Length; i++)
        {
            animPlatforms[i] = platforms[i].GetComponent<Animator>();
        }

        if (environment != null)
        {
            gameController = environment.GetComponent<GameController>();
        } else
        {
            Debug.Log("Error: Environment Variable is null.");
        }
    }
    public void setInRange(bool v){
        this.inRange = v;
    }

    public void setCurrentEnemy(GameObject enemy){
        this.currentEnemy = enemy;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.eulerAngles = new Vector3(0, transform.localRotation.eulerAngles.y, 0);
        // if (Input.GetKeyDown("space") && canJump)
        // {
        //     if (IsGrounded)
        //     {
        //         anim.Play("Jump");
        //         body.AddForce(Vector3.up * 6, ForceMode.Impulse);
        //         // if (start == false) {
        //         //     jumpTime = Time.deltaTime;
        //         //     start = true;
        //         // }

        //         // jumpDelay = 1.0f + jumpTime;


        //         // if (jumpDelay < jumpTime)
        //         // {

        //         //     start = false;
        //         // }

        //     }
        // }

        if (health > 0) {

            bool attacking = Input.GetKeyDown("q");
            bool isAttacking = anim.GetBool("isAttacking");

            if (!isAttacking && attacking && IsGrounded() && canAttack)
            {
                // anim.SetBool("isAttacking", true);
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) {
                    StartCoroutine(Attack());
                    if (inRange && currentEnemy != null){
                    SkeletonAI temp = currentEnemy.GetComponent<SkeletonAI>();
                    temp.enemyStruck();
                    Debug.Log(temp.health);
                }
                bool attackfor = Input.GetKey("w") && Input.GetKeyDown("q") && IsGrounded(); 
                if (attackfor) {
                    anim.SetBool("isWalkingForwards", false);
                    //anim.SetBool("isAttacking", true);
                }
                bool attackback = Input.GetKey("s") && Input.GetKeyDown("q") && IsGrounded(); 

                if (attackback) {
                    anim.SetBool("isWalkingBackwards", false);
                //anim.SetBool("isAttacking", true);
            }
                }


                //skeleton logic
                //TODO
                //possible imp vvv

                //if (m_Collider.bounds.Intersects(m_Collider2.bounds)){
                //reduce skeleton health
                //}
                //where m_collider is attack collider and m_collider2 is skeleton box collider
            }

            



            bool jump = Input.GetKeyDown("space") && canJump && IsGrounded();
            if (anim == null)
            {
                Debug.Log("Null anim");
            }
            bool isJumping = anim.GetBool("isJumping");
            bool isFalling = anim.GetBool("isFalling");
            if(jump && !animationLock) {
                body.AddForce(Vector3.up * 6, ForceMode.Impulse);
            }
            /*
            if (!isJumping && !IsGrounded() && Input.GetKey("space") && canJump)
            {
                anim.SetBool("isJumping", true);
                //transform.Translate(deltaDist(transform.forward));
            } 
            */

            if (!isJumping && !isFalling && !IsGrounded() && Input.GetKey("space") && canJump && !animationLock)
            {
                anim.SetBool("isJumping", true);
                //transform.Translate(deltaDist(transform.forward));
                Debug.Log("isJumping true");
            }

            if (isJumping && IsGrounded())
            {
                anim.SetBool("isJumping", false);
                //transform.Translate(deltaDist(transform.forward));
                Debug.Log("isJumping false");
            } 

            // if (!isJumping && !IsGrounded()) {
            //     anim.SetBool("isFalling", true);
            // }

            bool forward = Input.GetKey("up") || Input.GetKey("w");
            bool isWalkingForwards = anim.GetBool("isWalkingForwards");
            if(forward && !animationLock) {
                transform.Translate(deltaDist(Vector3.forward), Space.Self);
            }

            if (!isWalkingForwards && forward && !animationLock)
            {
                anim.SetBool("isWalkingForwards", true);
                //transform.Translate(deltaDist(transform.forward));
            } 

            if (isWalkingForwards && !forward)
            {
                anim.SetBool("isWalkingForwards", false);
                //transform.Translate(deltaDist(transform.forward));
            } 


            bool backward = Input.GetKey("down") || Input.GetKey("s");
            bool isWalkingBackwards = anim.GetBool("isWalkingBackwards");
            if(backward && !animationLock) {
                transform.Translate(deltaDist(Vector3.back), Space.Self);
            }

            if (!isWalkingBackwards && backward && !animationLock)
            {
                Debug.Log("starting");
                anim.SetBool("isWalkingBackwards", true);
                //transform.Translate(deltaDist(transform.forward));
            }
            
            if (isWalkingBackwards && !backward)
            {
                Debug.Log("stopping");
                anim.SetBool("isWalkingBackwards", false);
                //transform.Translate(deltaDist(transform.forward));
            } 

            if (forward && backward && !IsGrounded()) {
                anim.SetBool("isWalkingBackwards", false);
                anim.SetBool("isWalkingForwards", false);
            }


            if (Input.GetKey("left") || Input.GetKey("a"))
            {
                transform.Rotate(0, deltaDist(-90), 0, Space.World);
                //transform.position += deltaDist(Vector3.left);
            }
            if (Input.GetKey("right") || Input.GetKey("d"))
            {
                transform.Rotate(0, deltaDist(90), 0, Space.World);
                //transform.position += deltaDist(Vector3.right);
            }

            if (!IsGrounded()) {
                anim.SetBool("isWalkingBackwards", false);
                anim.SetBool("isWalkingForwards", false);
                anim.SetBool("isAttacking", false);
            }
      
        }
    }

    Vector3 deltaDist(Vector3 vector)
    {
        return vector * (speed * Time.deltaTime);
    }

    float deltaDist(float f)
    {
        return f * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.gameObject.tag == "ground")
        {
            ++groundContactCount;
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.gameObject.tag == "ground")
        {
            --groundContactCount;
        }
    }

    public void coffeeCollected()
    {
        coffeeCount += 1;
        switch (coffeeCount)
        {
            case 0:
                canJump = false;
                health = 50;
                canAttack = false;
                //Set game vision to dim
                /*
                if (specialLighting)
                {
                    gameController.LightStateChange(3);
                } else
                {
                    gameController.LightStateChange(1);
                }
                */
                break;
            case 1:
                canJump = true;
                health = 100;
                canAttack = false;
                uiHandler.JumpCoffee();
                //Set game vision to lighter
                gameController.LightStateChange(2);
                break;
            case 2:
                canJump = true;
                health = 150;
                canAttack = false;
                //Change speed?
                uiHandler.PlatformCoffee();
                //activate platform
                //Debug.Log("Changing decay Factor");
                gameController.LightStateChange(10);
                for (int i = 0; i < animPlatforms.Length; i++)
                {
                    animPlatforms[i].enabled = true;
                }

                break;
            case 3:
                canJump = true;
                health = 150;
                canAttack = true;
                gameController.LightStateChange(11);
                uiHandler.AttackCoffee();
                break;
        }
        if (coffeeCount < 0)
        {
            Debug.Log("Error: Variable coffeeCount is less than 0.");
        }
        if (coffeeCount > 3)
        {
            canJump = true;
            health = 150;
            canAttack = true;
            // Say "Health Restored"
        }
        hText.text = "Health: " + health;
    }

    public void DamagePlayer()
    {
        Debug.Log("Damaging Player");
        health = health - 50;
        Debug.Log("Actual Health: " + health);
        if (health >= 0)
        {
            hText.text = "Health: " + health;
        } else
        {
            hText.text = "Health: " + 0;
        }
        Debug.Log("HealthText: " + hText.text);
        if (health <= 0)
        {
            anim.Play("Death");
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.5f);
        uiHandler.LoseGame();
    }

    IEnumerator Attack()
    {
        animationLock = true;
        anim.Play("Attack",  -1, 0);
        yield return new WaitForSeconds(.8f);
        //anim.SetBool("isAttacking", false);
        animationLock = false;

    }

    void ResetPlayer()
    {
        this.transform.position = new Vector3(0, 1.54f, 0);
        switch (coffeeCount)
        {
            case 0:
                health = 50;
                break;
            case 1:
                health = 100;
                break;
            case 2:
                health = 150;
                break;
            case 3:
                health = 150;
                break;
            case 4:
                health = 150;
                break;
        }
        hText.text = "Health: " + health;
    }

}

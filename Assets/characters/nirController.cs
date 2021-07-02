using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nirController : MonoBehaviour
{
    protected Rigidbody rb;
    private bool isSlide = false;
    private Animator animator;
    private BoxCollider boxCol;
    private Vector3 startPoint;
    public bool isNir = true;
    private float rollAnimDur;
    public float NirRollAnimDur;
    public float TehilaRollAnimDur;
    public trigger upTrig;
    public trigger downTrig;
    private AudioSource audiosource;
    private bool canDoAction = false;
    private Vector3 finalPos;
    private bool move = false;
    private bool canRestart = false;
    // Start is called before the first frame update
    private void Start()
    {
        upTrig.triggerEvent.AddListener(nextObsUp);
        downTrig.triggerEvent.AddListener(nextObsDown);
        finalPos = new Vector3(2f, -0.17f, -1.75f);
        rb = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
        boxCol = GetComponent<BoxCollider>();
        startPoint = transform.position;
        if (isNir)
        {
            rollAnimDur = NirRollAnimDur;
        }
        else
        {
            rollAnimDur = TehilaRollAnimDur;
        }
    }

    private void nextObsUp()
    {
        isSlide = true ;
    }

    private void nextObsDown()
    {
        isSlide = false ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move && isNir)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPos, 5 * Time.fixedDeltaTime);
        }
    }

    private void OnJump()
    {
        print("jump");
        if (canDoAction && !move)
        {
            if (!isSlide)
            {
                rb.AddForce(Vector3.up * 6, ForceMode.Impulse);
            }
            else
            {
                boxCol.size = new Vector3(1, boxCol.size.y / 1.5f, 1);
                Invoke("reSize", rollAnimDur);
            }
            animator.SetTrigger("frontTwist");
            animator.SetBool("slide", isSlide);
            audiosource.Play();
            canDoAction = false;
            Invoke("setCanDoActionTrue", 2);
        }
        if (canRestart)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void reSize()
    {
        if (!boxCol)
        {
            boxCol = GetComponent<BoxCollider>();
        }
        boxCol.size = new Vector3(1, boxCol.size.y * 1.5f, 1);
        transform.position = startPoint;
    }

    public void setCanDoActionTrue()
    {
        canDoAction = true;
        print("nir");
    }

    public void setCanDoAction(bool can)
    {
        canDoAction = can;
        print("nir2");
    }

    public void finishControl()
    {
        move = true;
    }

    public void moveToFinalPosition()
    {
        move = true;
    }

    public void duck()
    {
        animator.SetTrigger("crouch");
    }

    public void idle()
    {
        animator.SetTrigger("idle");
    }

    public void excited()
    {
        animator.SetTrigger("excited");
    }

    public void dance()
    {
        animator.SetTrigger("dance");
    }

    public void setCanRestart()
    {
        canRestart = true;
    }
}

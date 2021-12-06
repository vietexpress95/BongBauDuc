using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BongBauDuc_Player : MonoBehaviour
{
    public static BongBauDuc_Player ins;
    public GameObject collisionEff;
    [HideInInspector] public Animator playerAnimator;
    public float moveSpeed;
    public BongBauDuc_Joystick joystick;
    private Vector3 huongQuayMat;
    private Transform skin;


    private void Awake() {
        ins = this;
    }

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        skin = transform.GetChild(0);
    }

    private void FixedUpdate() 
	{
        if(BongBauDuc_GameManager.ins.playerAlive == false) return;
        if(BongBauDuc_GameManager.ins.isEndGame == true) return;

        Vector3 moveVector = (transform.right * joystick.Horizontal + transform.forward * joystick.Vertical).normalized;

        if(moveVector != Vector3.zero)
        {

            BongBauDuc_GameManager.ins.StartGame();

            transform.Translate(moveVector * moveSpeed * Time.deltaTime);
            // transform.position = Vector3.Lerp(transform.position, transform.position + moveVector, moveSpeed * Time.deltaTime);
            // chuyển anim chạy
            playerAnimator.SetBool("isRun", true);
            huongQuayMat = moveVector;
        }
        else
        {
            playerAnimator.SetBool("isRun", false);
        }

        skin.rotation = Quaternion.LookRotation(huongQuayMat);
	}

    public void PlayerWin()
    {
        playerAnimator.SetBool("isWin", true);
    }

    public IEnumerator PlayerDie()
    {
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        transform.GetComponent<Rigidbody>().AddForce(200 * Vector3.up, ForceMode.Force);
        Destroy(playerAnimator);
        BongBauDuc_GameManager.ins.playerAlive = false;
        yield return new WaitForSeconds(1);
        BongBauDuc_GameManager.ins.EndGamePlayerDie();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("BBD_fish"))
        {
            StartCoroutine(PlayerDie());
            var ce = Instantiate(collisionEff, other.contacts[0].point, Quaternion.identity);
            Destroy(ce, 0.2f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BongBauDuc_Bot : MonoBehaviour
{
    public GameObject collisionEff;
    public GameObject dieEff;
    private NavMeshAgent agent;
    [HideInInspector] public bool isDie;
    private Animator botAnimator;
    private GameObject[] options;
    private Vector3 targetPoint;

    void Start()
    {
        options = new GameObject[BongBauDuc_GameManager.ins.locations.Length];
        agent = GetComponent<NavMeshAgent>();
        botAnimator = GetComponent<Animator>();
        targetPoint = transform.position;
    }

    private void Update()
    {
        if(BongBauDuc_GameManager.ins.isStartGame == false || BongBauDuc_GameManager.ins.isEndGame == true || isDie) return;

        if(Vector3.Distance(transform.position, targetPoint) <= 1)
        {
            botAnimator.SetBool("isRun", false);
        }
        else
        {
            botAnimator.SetBool("isRun", true);
        }
    }

    public IEnumerator FindLocationToRun()
    {
        // yield return new WaitForSeconds(0.5f + Random.Range(0.0f, 0.5f));
        yield return new WaitForSeconds(0.5f);
        if(isDie == false)
        {
            for(int i = 0; i < options.Length; i++)
            {
                options[i] = null;
            }

            for(int i = 0; i < options.Length; i++)
            {
                if(BongBauDuc_GameManager.ins.locationAlive[i] == true)
                {
                    options[i] = BongBauDuc_GameManager.ins.locations[i];
                }
            }

            // int ran;
            // do
            // {
            //     ran = Random.Range(0, 25);
            // } while(options[ran] == null);
            if(Random.Range(0, 6) != 2)
            {
                float min = 100;
                for(int i = 0; i < 25; i++)
                {
                    if(options[i] == null) continue;
                    float dis = Vector3.Distance(transform.position, options[i].transform.position);
                    if(dis < min)
                    {
                        targetPoint = new Vector3(options[i].transform.position.x, 0, options[i].transform.position.z);
                        min = dis;
                    }
                }
            }
            else
            {
                int ran = Random.Range(0, 25);
                targetPoint = new Vector3(BongBauDuc_GameManager.ins.locations[ran].transform.position.x, 0, BongBauDuc_GameManager.ins.locations[ran].transform.position.z);
            }
            Debug.Log(targetPoint);
            
            agent.SetDestination(targetPoint);
        }
    }

    public IEnumerator BotWin()
    {
        yield return new WaitForSeconds(Random.Range(0.0f, 0.3f));
        if(isDie == false)
            botAnimator.SetBool("isWin", true);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(isDie == true) return;
        if(other.transform.CompareTag("BBD_fish"))
        {
            Destroy(agent);
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>().AddForce(Vector3.up * 500, ForceMode.Force);
            isDie = true;
            Destroy(botAnimator);
            var ce = Instantiate(collisionEff, other.contacts[0].point, Quaternion.identity);
            Destroy(ce, 0.3f);
            StartCoroutine(BotDie());
        }
    }

    private IEnumerator BotDie()
    {
        BongBauDuc_GameManager.ins.botLenght--;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        var de = Instantiate(dieEff, transform.GetChild(0).GetChild(0).transform.position, Quaternion.identity);
        Destroy(de, 0.2f);

    }
}

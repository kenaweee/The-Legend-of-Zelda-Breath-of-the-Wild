using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pickup : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject tree;
    public GameObject bodyType;
    public Transform parent;
    Vector3 objOrigilanPosition;
    Quaternion objOriginalRotation;
    public List<GameObject> trees = new List<GameObject>();
    int z;
    public GameObject player;
    GameObject carried;
    NavMeshAgent agent;
    List<Transform> treePoints = new List<Transform>();
    //int current = 0;
   // public Animator animator;


    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("TreePoints");
        foreach (Transform t in go.transform)
            treePoints.Add(t);
        agent = GetComponent<NavMeshAgent>();
        /*if(trees != null)
        {
            for (int i = 0; i < trees.Count; i++)
            {
                Vector3 distance = trees[i].transform.position - bodyType.transform.position;
                float magnitude = distance.magnitude;
                //Debug.Log(magnitude + "mag");
                if (magnitude <= 10)
                {
                    objOrigilanPosition = trees[i].transform.position;
                    objOriginalRotation = trees[i].transform.rotation;
                }
            }
            
        }*/
        StartCoroutine(checking());
    }
    void Update()
    {


    }
    IEnumerator checking()
    {
        //GameObject go = GameObject.FindGameObjectWithTag("Tree");


        Debug.Log(treePoints.Count);
        //Transform firstTree = treePoints[0];
        agent.SetDestination(treePoints[Random.Range(0, trees.Count - 1)].position);
        yield return new WaitForSeconds(5f);
        //agent.SetDestination(trees[Random.Range(0, trees.Count-1)].transform.position);
        //Debug.Log(treePoints.Count);
        for (int i = 0; i < trees.Count; i++)
        {
            if (trees[i] == null)
            {
                continue;
            }
            Vector3 distance = trees[i].transform.position - bodyType.transform.position;
            float magnitude = distance.magnitude;
            Debug.Log(magnitude + "mag");
            if (magnitude <= 10)
            {
                carried = trees[i];
                onPickUp();
                //animator.SetBool("isPickingUp", false);
                break;

            }
            //current++;



        }

        yield return new WaitForSeconds(5f);
        StartCoroutine(checking());
    }
    public void onPickUp()
    {
        if (trees != null)
        {

            /*Vector3 distance = trees[i].transform.position - bodyType.transform.position;
            float magnitude = distance.magnitude;
            Debug.Log(magnitude + "mag");
            if (magnitude <= 8 )
            {*/
            carried.transform.SetParent(parent);
            carried.transform.localPosition = Vector3.zero;

            carried.SetActive(false);
            this.GetComponent<Animator>().SetBool("isPickingUp", true);
            GameObject newTree = Instantiate(tree, this.transform.position, transform.rotation) as GameObject;
            //newTree.transform.position = carried.transform.position;
            newTree.transform.localScale += new Vector3(-0.6f, -0.6f, -0.6f);
            newTree.transform.localEulerAngles += new Vector3(-90, 0, -90);
            this.transform.LookAt(player.transform);
            Rigidbody rb = newTree.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 10;
            Destroy(carried);





        }
    }

}
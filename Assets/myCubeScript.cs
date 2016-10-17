using UnityEngine;
using System.Collections;

public class myCubeScript : MonoBehaviour {


    // Use this for initialization
    void Start () {

	}
	
    public void setSize(float size)
    {
        this.transform.localScale = new Vector3(size, size, size);
    }

	// Update is called once per frame
	void Update () {

        
        /*if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100))
            {
                this.GetComponent<Renderer>().material.color = Color.red;
                this.GetComponent<myCubeScript>().setSize(0.3f);
                GetComponentInChildren<TextMesh>().text = Sketch.text;
                Debug.Log(hit.collider.name);
            }
        }
        */
    }
}

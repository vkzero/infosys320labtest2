using UnityEngine;
using Pathfinding.Serialization.JsonFx; //make sure you include this using

public class Sketch : MonoBehaviour {
    internal static string text;
    public GameObject myPrefab;
    // Put your URL here
    public string _WebsiteURL = "http://lyan677.azurewebsites.net/tables/TreeSurvey?zumo-api-version=2.0.0";

    void Start () {
        //Reguest.GET can be called passing in your ODATA url as a string in the form:
        //http://{Your Site Name}.azurewebsites.net/tables/{Your Table Name}?zumo-api-version=2.0.0
        //The response produce is a JSON string
        string jsonResponse = Request.GET(_WebsiteURL);

        //Just in case something went wrong with the request we check the reponse and exit if there is no response.
        if (string.IsNullOrEmpty(jsonResponse))
        {
            return;
        }

        //We can now deserialize into an array of objects - in this case the class we created. The deserializer is smart enough to instantiate all the classes and populate the variables based on column name.
        Product[] products = JsonReader.Deserialize<Product[]>(jsonResponse);
        float x;
        float y;
        float z;
        int totalCubes = products.Length;
        int i = 0;
        //We can now loop through the array of objects and access each object individually
        foreach (Product product in products)
        {
            //Example of how to use the object
            Debug.Log("This products name is: " + products[i].Location);
            //float perc = i / (float)totalCubes;
            i++;
            x = products[i].X;
            y = products[i].Y;
            z = products[i].Z;
            GameObject newCube = (GameObject)Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
            newCube.GetComponent<myCubeScript>().setSize(0.2f);
            newCube.GetComponentInChildren<TextMesh>().text = products[i].Location + "X: " + products[i].X + "Y: " + products[i].Y + "Z: " + products[i].Z;
            //text = this.GetComponentInChildren<TextMesh>().text = "X: " + products[i].X + "Y: " + products[i].Y + "Z: " + products[i].Z;
            for (int a = 0; a < totalCubes; a++) {
                text = "X" + products[a].X + "Y:" + products[a].Y + "Z=" + products[a].Z;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject) {
                    this.GetComponent<Renderer>().material.color = Color.red;
                    this.GetComponent<myCubeScript>().setSize(0.3f);
                    this.GetComponentInChildren<TextMesh>().text = Sketch.text;
                    Debug.Log(hit.collider.name);
                }
            }
        } 
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            //var hit : RaycastHit;
            RaycastHit hit;
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

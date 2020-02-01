using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualGameController : MonoBehaviour
{

    public float valveSpawnEverySeconds = 1f;
    public float pixelsPerFrame = 0.01f;
    
    public int width = 480;
    public int height = 720;

    public GameObject[] availableActionables;
    private List<GameObject> currentActionables = new List<GameObject>();

    private int maxActionablesPerIteration = 3;

    
    private GameObject gameContainer;

    void Awake()
    {
        // Uncommenting this will cause framerate to drop to 10 frames per second.
        // This will mean that FixedUpdate is called more often than Update.
        Application.targetFrameRate = 60;
        //availableActionables = Resources.LoadAll("Prefab/Valves", typeof(GameObject));

        
    }


    // Start is called before the first frame update
    void Start()
    {
        gameContainer = new GameObject();
        gameContainer.name = "Game container";
        gameContainer.transform.localScale = new Vector2(width, height);
        gameContainer.transform.parent = transform;
        SpriteRenderer spriteRenderer = gameContainer.AddComponent<SpriteRenderer>();



        /*  spriteRenderer.color = Color.red;
        
        spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Square") as Sprite;*/
        


        /*GameObject playerCameraGameObject = new GameObject("Player Camera");
        playerCameraGameObject.transform.parent = gameContainer.transform;
        Camera camera = playerCameraGameObject.AddComponent<Camera>();
        
        camera.orthographic = true;
        camera.orthographicSize = 9;
        camera.farClipPlane = 10;
        playerCameraGameObject.transform.position = new Vector3(0, 0, -10);
        */
        StartCoroutine(CreateValve());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increase the number of calls to FixedUpdate.
    void FixedUpdate()
    {
        
        currentActionables.ForEach(go =>
        {
            go.transform.position = go.transform.position - new Vector3(0, pixelsPerFrame);
        });



    }

#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
    IEnumerator CreateValve()
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados
    {

        while (true)
        {
            Debug.Log("Creating Valve interation");

            GameObject newValve = Instantiate(availableActionables[Random.Range(0, availableActionables.Length - 1)]);

            float valveWidth = newValve.GetComponent<SpriteRenderer>().size.x;
            float valveHeight = newValve.GetComponent<SpriteRenderer>().size.y;

            float randomX = Random.Range(valveWidth / 2, width - (valveWidth / 2))-(width/2);

            newValve.transform.position = new Vector3(randomX, (height / 2) + valveHeight, 0);
            newValve.transform.parent = gameContainer.transform;
            
            currentActionables.Add(newValve);

            yield return new WaitForSeconds(valveSpawnEverySeconds);
        }
    }


}

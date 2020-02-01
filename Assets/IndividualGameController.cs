using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualGameController : MonoBehaviour
{

    public float valveSpawnEverySeconds = 1f;
    public float pixelsPerFrame = 0.01f;
    
    public int width = 10;
    public int height = 10;

    public GameObject[] availableActionables;
    private List<GameObject> currentActionables = new List<GameObject>();
    private GameObject waterObject;

    public float waterLevelPercentage = 50;
    
    //private int maxActionablesPerIteration = 3;

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

        //Create the game container
        gameContainer = transform.Find("GameContainer").gameObject;
        gameContainer.transform.localScale = new Vector2(width, height);
        
        //Get the water
        waterObject = transform.Find("Water").gameObject;


        int wallCount = transform.Find("Walls").childCount;
        for(int i = 0; i< wallCount; i++)
        {
            Transform wallTransform = transform.Find("Walls").GetChild(i).transform;
            wallTransform.localScale = new Vector2(wallTransform.localScale.x, height);
        }


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
        float waterHeight = height * (waterLevelPercentage/100);
        waterObject.transform.localPosition = new Vector2(0, -(height/2)+(waterHeight/2));
        waterObject.transform.localScale = new Vector2(width, waterHeight);
        
        currentActionables.ForEach(go =>
        {
            go.transform.position = go.transform.position - new Vector3(0, pixelsPerFrame);
            if (go.transform.position.y < -((height / 2) +go.transform.lossyScale.y))
            {
                Destroy(go);
                currentActionables.Remove(go);
            }
        });



    }

#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
    IEnumerator CreateValve()
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados
    {

        while (true)
        {

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

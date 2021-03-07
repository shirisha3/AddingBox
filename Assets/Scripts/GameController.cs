using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public BoxSpawnerController box_SpawnerController;
    [HideInInspector]
    public BoxController currentBox;
    public UIManager uiMaganer; 
   

    public CameraFollow cameraFollow;
    private int moveCount;
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        cameraFollow.targetPos = new Vector3(0, 1, -10);
        box_SpawnerController.SpawnBox();

    }
    private void Update()
    {
        DetectInput();
    }
    void DetectInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            currentBox.DropBox();
        }
    }
    public void SpawnNewBox()
    {

        Invoke("NewBox",1f);

    }
    void NewBox()
        {
        box_SpawnerController.SpawnBox();
    }
    public void MoveCamera()
    {
        moveCount++;
        if(moveCount==3)
        {
            moveCount = 0;
           cameraFollow.targetPos.y += 1.5f;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}

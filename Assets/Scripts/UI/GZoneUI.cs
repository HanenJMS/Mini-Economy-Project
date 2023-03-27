using UnityEngine;
using UnityEngine.UI;

public class GZoneUI : MonoBehaviour
{
    Text text;
    [SerializeField] PlayerController playerController;
    private void Awake()
    {
        text = GetComponentInChildren<Text>();
    }
    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.OnSelectedZone += UpdateZone;
    }
    public void UpdateZone()
    {
        text.text = playerController.ReturnInventoryState();
    }
}

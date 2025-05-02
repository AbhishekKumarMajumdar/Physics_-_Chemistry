using UnityEngine;
using UnityEngine.UI;

public class EnableScriptController : MonoBehaviour
{
    // Reference to scripts to enable/disable
    public MonoBehaviour script1;
    public MonoBehaviour script2;
    public MonoBehaviour script3;

    // Buttons for each script
    public Button button1;
    public Button button2;
    public Button button3;

    private void Start()
    {
        // Set up button listeners to toggle scripts
        button1.onClick.AddListener(EnableScript1);
        button2.onClick.AddListener(EnableScript2);
        button3.onClick.AddListener(EnableScript3);

        // Disable all scripts initially (optional)
        DisableAllScripts();
    }

    private void EnableScript1()
    {
        script1.enabled = true;
        script2.enabled = false;
        script3.enabled = false;
    }

    private void EnableScript2()
    {
        script1.enabled = false;
        script2.enabled = true;
        script3.enabled = false;
    }

    private void EnableScript3()
    {
        script1.enabled = false;
        script2.enabled = false;
        script3.enabled = true;
    }

    private void DisableAllScripts()
    {
        script1.enabled = false;
        script2.enabled = false;
        script3.enabled = false;
    }
}

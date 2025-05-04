using UnityEngine;

namespace cakeslice
{
    public class TapToToggleAnimations : MonoBehaviour
    {
        public Material bulbNormalMaterial;
        public Material bulbGlowMaterial;

        public GameObject bulb1;
        public GameObject bulb2;

        public GameObject m1Collider; // Collider GameObject for M1
        public GameObject s1Collider; // Collider GameObject for S1
        public GameObject s2Collider; // Collider GameObject for S2

        public Outline m1Outline;
        public Outline s1Outline;
        public Outline s2Outline;

        public float materialChangeDelay = 0.5f; // Delay before changing material

        private bool m1IsOn = false;
        private bool s1IsOn = false;
        private bool s2IsOn = false;


        private void Start()
        {
            m1Outline.enabled=false;
            s1Outline.enabled = false;
            s2Outline.enabled = false;

            // Enable outline on M1 at the start of the game
            m1Outline.enabled = true;
        }

        private void Update()
        {
            // Check for tap input on both mouse and touch
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Vector3 tapPosition;

                // Check if it's a mouse click or touch input
                if (Input.GetMouseButtonDown(0))
                {
                    // Mouse click
                    tapPosition = Input.mousePosition;
                }
                else
                {
                    // Touch input
                    tapPosition = Input.GetTouch(0).position;
                }

                // Cast a ray from the screen where the user tapped
                Ray ray = Camera.main.ScreenPointToRay(tapPosition);
                RaycastHit hit;

                // Check if the ray hits any of the colliders
                if (Physics.Raycast(ray, out hit))
                {
                    // Check which collider was hit and toggle the corresponding animation
                    if (hit.collider.gameObject == m1Collider)
                    {
                        ToggleM1();
                    }
                    else if (hit.collider.gameObject == s1Collider)
                    {
                        ToggleS1();
                    }
                    else if (hit.collider.gameObject == s2Collider)
                    {
                        ToggleS2();
                    }
                }
            }
        }

        void ToggleM1()
        {
            m1IsOn = !m1IsOn;
            // Set trigger for M1 animation
            GetComponent<Animator>().SetTrigger(m1IsOn ? "m_switch_on" : "m_switch_off");
            Invoke("UpdateBulbs", materialChangeDelay); // Delay before updating bulbs
            m1Outline.enabled = !m1IsOn;
            s1Outline.enabled = m1IsOn;
            s2Outline.enabled = m1IsOn;
        }

        void ToggleS1()
        {
            s1IsOn = !s1IsOn;
            // Set trigger for S1 animation
            GetComponent<Animator>().SetTrigger(s1IsOn ? "s1_switch_on" : "s1_switch_off");
            Invoke("UpdateBulbs", materialChangeDelay); // Delay before updating bulbs
            s1Outline.enabled = !s1IsOn;

        }

        void ToggleS2()
        {
            s2IsOn = !s2IsOn;
            // Set trigger for S2 animation
            GetComponent<Animator>().SetTrigger(s2IsOn ? "s2_switch_on" : "s2_switch_off");
            Invoke("UpdateBulbs", materialChangeDelay); // Delay before updating bulbs

            // Toggle outline based on S2 state
            s2Outline.enabled = !s2IsOn;

        }

        void UpdateBulbs()
        {
            if (m1IsOn)
            {
                bulb1.GetComponent<Renderer>().material = s1IsOn ? bulbGlowMaterial : bulbNormalMaterial;
                bulb2.GetComponent<Renderer>().material = s2IsOn ? bulbGlowMaterial : bulbNormalMaterial;
            }
            else
            {
                bulb1.GetComponent<Renderer>().material = bulbNormalMaterial;
                bulb2.GetComponent<Renderer>().material = bulbNormalMaterial;
            }
        }
    }
}

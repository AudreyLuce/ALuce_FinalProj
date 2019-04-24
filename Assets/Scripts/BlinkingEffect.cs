using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingEffect: MonoBehaviour
{
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;

    void Update()
    {
        if (startBlinking == true)
        {
            StartBlinkingEffect();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            startBlinking = true;
        }
    }

    private void StartBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;

            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<MeshRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}

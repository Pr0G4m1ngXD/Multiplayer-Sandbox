using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class webhookscript : MonoBehaviour {
    public bool startpublicgame = false;
    void Start() {
        if (startpublicgame) {
            StartCoroutine(Upload());
        }
    }

    IEnumerator Upload() {
        WWWForm form = new WWWForm();
        
        form.AddField("content","**New Public Game from Player 456** \n\n**Join IP** \n127.0.0.1");

        using (UnityWebRequest www = UnityWebRequest.Post("https://discord.com/api/webhooks/903019125222309969/XZyDw39xJkHusg4NK4I_8LaCZhV9MIrd55MNe8zzwp5zm7FHHeYOUvWUE-sHmjCr3EDY", form)) {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            } else {
                Debug.Log("Form upload complete!");
            }
        }
    }
}

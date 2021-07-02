using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMGR : MonoBehaviour
{
    public GameObject nir;
    public GameObject tehila;
    public nirController nirCon;
    public nirController tehilaCon;
    public GameObject blackScreen;
    private Material mat;
    private AudioSource AS;
    private bool isRestarting = false;
    public spawner nirSpawner;
    public spawner tehilaSpawner;
    public cameraScript cameraScript;
    public Animator textObjAnimator;
    public Text text;
    public GameObject restartText;
    public GameObject textObj;
    public GameObject ring;
    public land landUp;
    public land landDown;
    public bool debug = false;
    private void fadeToBlack()
    {
        blackScreen.SetActive(true);
        mat = blackScreen.GetComponent<Renderer>().material;
        increaseAlbedo();
    }

    public void increaseAlbedo()
    {
        Color temp = mat.color;
        if (mat.color.a < 1)
        {
            temp.a+=0.1f;
            mat.color = temp;
            Invoke("increaseAlbedo", 0.1f);
        }
    }

    public void restart()
    {
        if (!isRestarting)
        {
            isRestarting = true;
            AS.clip = AssetsManager.AM.lostSound;
            AS.Play();
            fadeToBlack();
            Invoke("restartScene", 1);
        }
    }

    private void restartScene()
    {
        SceneManager.LoadScene(0);

    }
    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.clip = AssetsManager.AM.bgm;
        AS.Play();
        //Invoke("tehilaStart", 3);
        //Invoke("startFinishGame", 3);
        //Invoke("togetherStart", 3);
        IEnumerator coroutine = Game();
        StartCoroutine(coroutine);
    }

    public IEnumerator Game()
    {
        yield return new WaitForSeconds(3);
        text.text = "Press On Screen to avoid obstacles!!!";
        //text.fontSize += 15;
        text.rectTransform.localPosition += new Vector3(0, 20, 0);
        textObj.transform.localScale = new Vector3(0.7f, 0.7f, 0);
        textObj.SetActive(true);
        textObjAnimator.SetTrigger("start");
        if (!debug)
        {
            yield return new WaitForSeconds(5);
            tehilaStart();
            yield return new WaitForSeconds(13.5f);
            nirStart();
            yield return new WaitForSeconds(13.5f);
            togetherStart();
            yield return new WaitForSeconds(19);
        }

        IEnumerator coroutine = finishGame();
        StartCoroutine(coroutine);

    }
    private void tehilaStart()
    {
        tehilaCon.setCanDoAction(true);
        tehilaSpawner.startSpawn();
        cameraScript.changePosToTehila();
    }

    private void nirStart()
    {
        tehilaCon.setCanDoAction(false);
        tehilaSpawner.stop();
        nirCon.setCanDoAction(true);
        nirSpawner.startSpawn();
        cameraScript.changePosToNir();
    }

    private void togetherStart()
    {
        tehilaCon.setCanDoAction(true);
        tehilaSpawner.startSpawn();
        cameraScript.changePosToTogether();

    }

    public IEnumerator finishGame()
    {
        nirSpawner.stop();
        tehilaSpawner.stop();
        tehilaCon.finishControl();
        nirCon.setCanDoAction(false);
        cameraScript.changePosToFinal();
        yield return new WaitForSeconds(5);
        nir.transform.position = new Vector3(2.65f, -0.37f, 9.68f);
        nirCon.moveToFinalPosition();
//        tehilaCon.idle();
        yield return new WaitForSeconds(2);
        landUp.stop();
        landDown.stop();
        nirCon.duck();
        tehilaCon.excited();
        //text.fontSize -= 15;
        textObj.transform.localScale = new Vector3(1f, 1f, 0);
        text.rectTransform.localPosition -= new Vector3(0, 20, 0);
        text.text = "You are invited to our wedding!";
        textObjAnimator.SetTrigger("start");
        yield return new WaitForSeconds(3f);
        ring.SetActive(true);
        yield return new WaitForSeconds(3f);
        nirCon.transform.localRotation = Quaternion.Euler(0, 90, 0);
        tehilaCon.transform.localRotation = Quaternion.Euler(0, 90, 0);
        nirCon.dance();
        tehilaCon.dance();
        text.rectTransform.localPosition -= new Vector3(0, 20, 0);
        text.text = "Tehila AND Nir";
        textObjAnimator.SetTrigger("start");
        yield return new WaitForSeconds(6f);
        text.fontSize += 10;
        text.rectTransform.localPosition += new Vector3(0, 30, 0);
        text.text = "22.7.21\n19:00";
        textObjAnimator.SetTrigger("start");
        yield return new WaitForSeconds(6f);
        text.fontSize -= 15;
        text.rectTransform.localPosition -= new Vector3(0, 20, 0);
        text.text = "Cassiopeia\nHashunit 2, Hertzliya";
       // text.rectTransform.localPosition += new Vector3(0, 20, 0);
        textObjAnimator.SetTrigger("start");
        yield return new WaitForSeconds(6f);
        text.rectTransform.localPosition += new Vector3(0, 10, 0);
        text.fontSize -= 20;
        text.text = "Tehila and Nir\n" +
            "22.7.21 19:00\n" +
            "Cassiopeia (Hashunit 2, Hertzliya)";
        textObjAnimator.SetTrigger("start");
        yield return new WaitForSeconds(2f);
        textObjAnimator.SetTrigger("display");
        yield return new WaitForSeconds(8f);
        restartText.SetActive(true);
        nirCon.setCanRestart();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	//ゲームオーバーのテキスト
	private GameObject gameOverText;

	//走行距離のテキスト
	private GameObject runLengthText;

	//走った距離
	private float len=0;

	//走る速度
	private float speed =0.03f;

	//ゲームオーバーの判定
	private bool isGameOver = false;

	// Use this for initialization
	void Start () {
		this.gameOverText  = GameObject.Find ("GameOver");
		this.runLengthText = GameObject.Find ("RunLength");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isGameOver == false) {
			//走った距離の更新
			this.len += this.speed;

			this.runLengthText.GetComponent<Text> ().text = "Distance : " + len.ToString ("F2") + "m";
		}
		if(this.isGameOver==true && Input.GetMouseButtonDown (0)) {
				SceneManager.LoadScene ("GameScene");
			}
	}
//ゲームオーバになったときにテキストを表示してboolをtrueにするGameOver関数
	public void GameOver(){
		this.gameOverText.GetComponent<Text>().text = "GameOver";
		this.isGameOver = true;
		}
}

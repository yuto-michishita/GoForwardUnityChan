using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
	//コンポーネントを入れる箱
	Animator animator;
	Rigidbody2D rigid2D;

	//地面に着く座標
	private float groundLevel = -3.0f;

	//ジャンプ速度の減衰
	private float dump = 0.8f;

	//ジャンプ速度
	float jumpVelocity = 20;

	//GameOverになる位置（座標）
	private float deadLine = -9;
	// Use this for initialization
	void Start () {

		this.animator = this.GetComponent<Animator> ();
		this.rigid2D = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//アニメーションのパラメーターを１に
		this.animator.SetFloat ("Horizontal", 1);

		//着地しているかどうか
		bool isGround = (transform.position.y > this.groundLevel) ? false : true;
		this.animator.SetBool ("isGround", isGround);

		//ジャンプ中は足音のボリュームを０にする
		GetComponent<AudioSource>().volume = (isGround)?1:0;

		//着地かつマウスが押されたら飛ぶ
		if (Input.GetMouseButtonDown (0) && isGround) {
			this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);
		}

		//マウスが離れた時、さらにジャンプをしていない時
		if (Input.GetMouseButton (0) == false) {
			if (this.rigid2D.velocity.y > 0) {
				this.rigid2D.velocity *= this.dump;
			}
		}
		if (transform.position.x < this.deadLine) {

			//UIControllerのGameObject関数を呼び出して画面上に表示
			GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver ();
			//ユニティちゃんを消す
			Destroy (this.gameObject);
		}
		}
}

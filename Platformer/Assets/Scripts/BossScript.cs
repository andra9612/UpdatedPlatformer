using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour {

    [SerializeField] private GameObject particles;
    private const float DELAY_BEFORE_LEVEL_END = 5f;
    private bool isGameEnd = false;

	GameObject player;

	int health = 6;

	float posY, posZ;

	int action;

	float  skillCouldawn;

	float fallDelay = 5f;

	float delay;

	public Transform weapon;

	public Transform bullet;

	public static Transform shot;

	bool isFall = false;

	bool isActionEnd = true;

	Rigidbody2D boss;

	// Use this for initialization
	void Start () {
		boss = GetComponent<Rigidbody2D> ();
		posY = transform.position.y;
		posZ = transform.position.z;
		player = GameObject.FindGameObjectWithTag ("Player");
		
	}

	void Damage(){

		health -= 1;
		Debug.Log (health);
		if (health == 0) {
            StartCoroutine(LoadNextLevelWithDelay());
		}

	}

    private IEnumerator LoadNextLevelWithDelay()
    {
        isGameEnd = true;
        boss.gravityScale = 1f;
        particles.SetActive(true);
        yield return new WaitForSeconds(DELAY_BEFORE_LEVEL_END);
        Destroy(gameObject);
        Application.LoadLevel(Application.levelCount - 1);
    }

	void FixedUpdate () {
        if (!isGameEnd)
        {
            if (delay <= 0 && transform.position != player.transform.position && isFall == false)
            {
                transform.position = new Vector3(player.transform.position.x, posY, posZ);
                delay = 1;
            }

            delay -= Time.deltaTime;
            if (isActionEnd)
                action = Random.Range(1, 100);

            if (skillCouldawn <= 0)
            {

                if (action > 0 && action < 51)
                    Shoting();
                else if (action > 50 && action < 81)
                    Falling();
            }

            skillCouldawn -= Time.deltaTime;
        }

		

	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            Damage();
    }


    void Shoting(){
		shot = Instantiate (bullet,weapon.position, Quaternion.identity);
		Destroy (shot.gameObject, 5f);
		isActionEnd = true;
		skillCouldawn = 7f;
	}

	void  Falling(){
		isActionEnd = false;
		isFall = true;
		boss.gravityScale = 1f;

		if (fallDelay <= 0 && isFall) {

			isFall = false;
			boss.gravityScale = 0f;
			fallDelay = 5f;
			isActionEnd = true;
			skillCouldawn = 7f;
		}
		fallDelay -= Time.deltaTime;

	}

	void OnCollisionEnter2D(Collision2D col ){

		if (col.transform.tag == "Weapon")
			Damage ();

	}
}

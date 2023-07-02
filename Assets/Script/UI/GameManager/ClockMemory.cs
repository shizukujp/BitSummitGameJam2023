using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockMemory : MonoBehaviour
{
    public Sprite[] clockSprite;


	private const float k_maxLength = 1f;
	private const string k_propName = "_MainTex";

	//画像関連
	private Material m_material;
	Image Changingimg;


	//ループアニメーション関連
	bool MoveClockAnimPlaying = false;
	int Roundpreb = 0;
	float m_time = 10f;

	bool PlayerTurnpreb = true;

	private void Start()
	{
		Changingimg = GetComponent<Image>();
		if (Changingimg is Image i)
		{
			m_material = i.material;
		}
		RepeatMove(0.0033f,m_time);

		Roundpreb = RoundController.instance.GetETurn();
		RoundChaned();
	}
    private void Update()
	{
        //チェックする回数を減らすことでシステムへの負荷を軽減する
        if (Player.isPlayerTurn != PlayerTurnpreb)
        {
            PlayerTurnpreb = Player.isPlayerTurn;
            if (PlayerTurnpreb)
            {
                TurnCheck(new Color(1, 1f, 1f));
            }
            else
            {
				TurnCheck(new Color(1, 0.3f, 0.3f));
			}
        }
        //ターンごとに変わる
        if (RoundController.instance.GetETurn() != Roundpreb && RoundController.instance.GetETurn() != 12)
		{
			Roundpreb = RoundController.instance.GetETurn();
			if (Roundpreb == 0) { m_time = -15f; }
			Changingimg.sprite = clockSprite[0];
            if (!MoveClockAnimPlaying)
            {
				StartCoroutine(MoveClockAnim());
            }else
            {
				StartCoroutine(SpeedingMoveClockAnim());
            }
			
		}
        //Debug.Log(m_time);
    }


	//外部関数



	//内部関数
	//repeat animation
	IEnumerator MoveClockAnim()
	{
		MoveClockAnimPlaying = true;
		if (m_material)
		{
			var ClockAnim = 0;
			while(ClockAnim < 50)
            {
				m_time += 0.5f;
				ClockAnim++;
				RepeatMove(0.0033f,m_time);
				yield return new WaitForEndOfFrame();
			}
			RoundChaned();
		}
		MoveClockAnimPlaying = false;
	}
	IEnumerator SpeedingMoveClockAnim()
    {
		var ClockAnim = 0;
		while (ClockAnim < 5)
		{
			//Debug.Log("SpeedingClock");
			m_time += 5f;
			ClockAnim++;
			RepeatMove(0.033f, m_time);
			yield return new WaitForEndOfFrame();
		}
		RoundChaned();
	}

	void RoundChaned()
	{
		//ラウンドの色変更
		//Roundpreb = RoundController.instance.GetETurn();
		Changingimg.sprite = clockSprite[(Roundpreb + 1 > 12 ? 12 : Roundpreb + 1)];
	}


    //誰のターンを表示するメソッド
    void TurnCheck(Color color)
    {
        Changingimg.color = color;
    }


    //repeat to left
    void RepeatMove(float rptSpeed,float mTime)
    {
		// xとyの値が0 ～ 1でリピートするようにする
		var x = Mathf.Repeat(mTime * rptSpeed, k_maxLength);
		var y = Mathf.Repeat(0f, k_maxLength);
		var offset = new Vector2(x, y);
		m_material.SetTextureOffset(k_propName, offset);
	}



	//消す時にも度に戻す
    private void OnDestroy()
	{
		// ゲームをやめた後にマテリアルのOffsetを戻しておく
		if (m_material)
		{
			m_material.SetTextureOffset(k_propName, Vector2.zero);
		}
	}
}

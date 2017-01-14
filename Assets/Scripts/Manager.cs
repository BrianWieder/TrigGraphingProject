using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public static Manager instance = null;

	[SerializeField]
	private Slider AValue;
	[SerializeField]
	private Slider BValue;
	[SerializeField]
	private Slider CValue;
	[SerializeField]
	private Slider DValue;

	[SerializeField]
	private float maxValue = 10;

	[SerializeField]
	private float minValue = -10;

	public float getAValue(){
		return AValue.value;
	}

	public float getBValue(){
		return BValue.value;
	}

	public float getCValue(){
		return CValue.value;
	}

	public float getDValue(){
		return DValue.value;
	}

	void Start(){

		if(instance == null){
			AValue.maxValue = maxValue;
			AValue.minValue = minValue;

			BValue.maxValue = maxValue;
			BValue.minValue = minValue;

			CValue.maxValue = maxValue;
			CValue.minValue = minValue;

			CValue.maxValue = maxValue;
			CValue.minValue = minValue;
			instance = this;
		}else{
			Destroy(gameObject);
		}
		
	}

}
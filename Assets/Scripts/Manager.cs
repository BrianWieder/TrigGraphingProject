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
	private float addMaxValue = 10;

	[SerializeField]
	private float addMinValue = 0;

    [SerializeField]
    private float multiMaxValue = 3;

    [SerializeField]
    private float multiMinValue = 1;

    private float aValue;
    private float bValue;
    private float cValue;
    private float dValue;

	public float getAValue(){
		return aValue;
	}

	public float getBValue(){
		return bValue;
	}

	public float getCValue(){
		return cValue;
	}

	public float getDValue(){
		return dValue;
	}

	void Start(){

		if(instance == null){
			AValue.maxValue = multiMaxValue;
			AValue.minValue = multiMinValue;

			BValue.maxValue = multiMaxValue;
			BValue.minValue = multiMinValue;

			CValue.maxValue = addMaxValue;
			CValue.minValue = addMinValue;

			DValue.maxValue = addMaxValue;
			DValue.minValue = addMinValue;


            aValue = AValue.value;
            bValue = BValue.value;
            cValue = CValue.value;
            dValue = DValue.value;

            AValue.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
            BValue.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
            CValue.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
            DValue.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

            instance = this;
		}else{
			Destroy(gameObject);
		}
		
	}

    public void ValueChangeCheck()
    {
        aValue = AValue.value;
        bValue = BValue.value;
        cValue = CValue.value;
        dValue = DValue.value;
    }

}
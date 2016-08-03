using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using MoreMountains.Tools;

/// <summary>
/// Add this class to a gameObject with a Text component and it'll feed it the number of FPS in real time.
/// </summary>
public class ProgressBar : MonoBehaviour
{
	/// the healthbar's foreground bar
	public Transform ForegroundBar;


	protected Vector3 _newLocalScale = Vector3.one;
	protected float _newPercent;

	public virtual void UpdateBar(float currentValue,float minValue,float maxValue)
	{
		_newPercent = MMMaths.Remap(currentValue,minValue,maxValue,0,1);
		_newLocalScale.x = _newPercent;
		ForegroundBar.localScale = _newLocalScale;		
	}
}
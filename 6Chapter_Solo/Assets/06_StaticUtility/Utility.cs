
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO : 공부 용도의 코드로 작성한 예제입니다.

public static class Utility
{
	public static void Print<T>(T value)
	{
		Debug.Log(value.ToString());
	}

	public static void OnClick(this Button button, Action action)
	{
		button.onClick.AddListener(() =>
		{
			action();
			AudioManager.Instance.SFXSource_Button.Play();
		});
	}

}

public static class ThisMethod
{
    public static T TestMessage<T>(this T value)
    {
		Debug.Log($"{value.GetType()} 순서 테스트{value.ToString()}");
		return value;
	}
}

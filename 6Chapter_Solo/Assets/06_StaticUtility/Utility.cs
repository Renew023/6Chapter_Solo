
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utility
{
	public static void Print<T>(T value)
	{
		Debug.Log(value.ToString());
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

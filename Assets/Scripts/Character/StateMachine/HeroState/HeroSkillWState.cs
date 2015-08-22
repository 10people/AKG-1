﻿using UnityEngine;

public class HeroSkillWState : MonoBehaviour
{
	public AudioClip Clip;

	private DynamicSpawner spawner;
	private OneShotEffectController heatEffect;
	
	void OnEnable()
	{
		audio.clip = Clip;
		audio.Play();

		heatEffect.gameObject.SetActive(true);
		heatEffect.Play();
	}

	void OnDisable()
	{
		heatEffect.gameObject.SetActive(false);
	}
	
	void Awake()
	{
		spawner = transform.Find("Effect/HeatLocation").GetComponent<DynamicSpawner>();
		spawner.Generate();
		
		heatEffect = spawner.SpawnInstance.GetComponent<OneShotEffectController>();
	}
}

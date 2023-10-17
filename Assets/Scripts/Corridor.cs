using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Corridor : MonoBehaviour {
	public Transform[] sectionPrefabs;
	private readonly List<Transform> sections = new();
	private Transform RandomSection(){
		return sectionPrefabs[Random.Range(0, sectionPrefabs.Length)];
	}
	// Start is called before the first frame update
	private void Start(){
		sections.Add(Instantiate(RandomSection(), transform));
	}
// Update is called once per frame
	private void Update(){
		if (sections[0].transform.position.z < -40){
			Destroy(sections[0].gameObject);
			sections.Remove(sections[0]);
		}
		while (sections.Count < 30){
			Transform lastSection = sections[^1];
			Transform newSection = RandomSection();
			sections.Add(Instantiate(newSection, lastSection.position+new Vector3(0, 0, 20), Quaternion.identity, transform));
		}
		transform.position -= Time.deltaTime*new Vector3(0, 0, 20);
	}
}
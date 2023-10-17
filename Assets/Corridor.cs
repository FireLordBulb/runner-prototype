using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Corridor : MonoBehaviour {
	public Transform sectionPrefab;
	private List<Transform> sections = new();
	// Start is called before the first frame update
	private void Start(){
		sections.Add(Instantiate(sectionPrefab, transform));
	}
// Update is called once per frame
	private void Update(){
		if (sections[0].transform.position.z < -10){
			Destroy(sections[0].gameObject);
			sections.Remove(sections[0]);
		}
		while (sections.Count < 10){
			sections.Add(Instantiate(sectionPrefab, sections[^1].transform.position+new Vector3(0, 0, 10), Quaternion.identity, transform));
		}
		transform.position -= Time.deltaTime*new Vector3(0, 0, 20);
	}
}
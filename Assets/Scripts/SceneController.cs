using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {
	void Start() {
	}
	void Update() {
	}
	public void LoadGame() {
		Application.LoadLevel ("GameScene");
	}
	public void LoadInstructions(){
		Application.LoadLevel ("InstructionsScene");
	}
	public void LoadIntro() {
		Application.LoadLevel ("IntroScene");
	}
}

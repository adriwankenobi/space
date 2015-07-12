using UnityEngine;

/*
 * Input utils
 */

public static class InputExtensions
{

	private enum Phase {
		BEGAN,
		MOVED,
		ENDED
	};

	public class InputResult {

		public const int INIT_ID = -1;

		int _InputId;
		bool _Input;
		Vector3 _Position;

		public InputResult()
		{
			_InputId = INIT_ID;
			_Input = false;
			_Position = Vector3.zero;
		}

		public int InputId {
			get {
				return _InputId;
			}
			set {
				_InputId = value;
			}
		}

		public bool Input {
			get {
				return _Input;
			}
			set {
				_Input = value;
			}
		}

		public Vector3 Position {
			get {
				return _Position;
			}
			set {
				_Position = value;
			}
		}
	}

	private static InputResult GetInput(GameObject gameObject, Phase phase)
	{
		InputResult result = new InputResult();

		#if UNITY_ANDROID

		if (Input.touchCount > 0)
		{
			for(int i = 0; i < Input.touchCount; i++)
			{
				Touch currentTouch = Input.GetTouch(i);

				if (validateInput(gameObject, currentTouch.position))
				{
					switch (phase)
					{
					case Phase.BEGAN: 
						result.Input = currentTouch.phase == TouchPhase.Began;
						break;
					case Phase.MOVED: 
						result.Input = currentTouch.phase == TouchPhase.Moved;
						break;
					case Phase.ENDED: 
						result.Input = currentTouch.phase == TouchPhase.Ended;
						break;
					default: 
						throw new System.ArgumentException("Incorrect InputExtensions.Phase " + phase.ToString());
					}
				}

				result.InputId = currentTouch.fingerId;
				result.Position = currentTouch.position;
			}
		}

		#endif

		#if UNITY_WEBPLAYER || UNITY_EDITOR
		
		if (validateInput(gameObject, Input.mousePosition))
		{
			switch (phase)
			{
			case Phase.BEGAN: 
				result.Input = Input.GetMouseButtonDown(0);
				break;
			case Phase.MOVED: 
				result.Input = Input.GetMouseButton(0);
				break;
			case Phase.ENDED: 
				result.Input = Input.GetMouseButtonUp(0);
				break;
			default: 
				throw new System.ArgumentException("Incorrect InputExtensions.Phase " + phase.ToString());
			}
		}

		result.Position = Input.mousePosition;

		#endif

		return result;
	}

	private static bool validateInput(GameObject gameObject, Vector3 position)
	{

		bool validated = true;

		if (gameObject == null) {
			// validate it's anywhere except ButtonsPlane

			// Get all buttons in buttonsPlane
			Component[] buttons = GameObject.Find(SpaceObjects.BUTTONS_PLANE).GetComponentsInChildren<Collider2D>();
			for(int i = 0; i < buttons.Length; i++)
			{
				// If position is inside the button, skip
				if (IsObjectInPosition(buttons[i].gameObject, position))
				{
					validated = false;
					break;
				}
			}
		} 
		else {
			// Validate position is inside the object
			validated = IsObjectInPosition(gameObject, position);
		}

		return validated;
	}

	private static bool IsObjectInPosition(GameObject gameObject, Vector3 position)
	{
		// Cast a ray from input position 
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(position), Vector2.zero);

		// Hit object is the game object?
		return hit.collider != null && hit.collider.gameObject == gameObject;

	}

	public static bool IsFired(GameObject gameObject)
	{
		bool input = false;

		#if UNITY_ANDROID
		
		input = GetInput(gameObject, Phase.BEGAN).Input;
		
		#endif

		#if UNITY_WEBPLAYER || UNITY_EDITOR

		input = Input.GetKeyDown(KeyCode.F);

		#endif

		return input;
	}

	public static InputResult IsObjectClickedDown(GameObject gameObject)
	{
		return GetInput(gameObject, Phase.BEGAN);
	}

	public static InputResult IsClickedDown()
	{
		return GetInput(null, Phase.BEGAN);
	}

	public static InputResult IsObjectClicked(GameObject gameObject)
	{
		return GetInput(gameObject, Phase.MOVED);
	}

	public static InputResult IsClicked()
	{
		return GetInput(null, Phase.MOVED);
	}

	public static InputResult IsObjectClickedUp(GameObject gameObject)
	{
		return GetInput(gameObject, Phase.ENDED);
	}

	public static InputResult IsClickedUp()
	{
		return GetInput(null, Phase.ENDED);
	}
}
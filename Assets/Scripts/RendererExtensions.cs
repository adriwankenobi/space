using UnityEngine;

/// <summary>
/// Script for rendering utils
/// </summary>
public static class RendererExtensions
{
	// Checks if renderer object is visible from camera
	public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
}
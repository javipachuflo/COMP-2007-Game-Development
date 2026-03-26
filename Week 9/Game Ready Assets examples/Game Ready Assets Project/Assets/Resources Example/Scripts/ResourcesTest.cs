using UnityEngine;

/* ResourcesTest
 * an example of loading a prefab from a Resources folder in the project
 * the advantage of this is you don't have to store references to prefabs in your scene components
 * you can load files of any type - GameObjects, text files, materials, textures, sounds etc
 * NOTE: you can have multiple Resources folders in your project - these will all be searched when using the Resources class
 */
public class ResourcesTest : MonoBehaviour
{
    // file path to the prefab starting from the Resources folder
    // includes the prefabs name "Cube Prefab"
    public string path = "Cube Prefab";

    void Start()
    {
        // Resources.Load can load a specific file type (like GameObject below)
        // Resources.Load will search ALL of the folders called "Resources" in your project for the file
        // you can have hierarchies of folders in the path, like "Characters/My Character Prefab"
        GameObject item = Resources.Load<GameObject>(path);

        // if we loaded an item
        if (item != null)
        {
            // spawn the item in the scene
            Instantiate(item, Vector3.zero, Quaternion.identity);
        }
        else
        {
            // or give a warning that it could not be found
            Debug.LogWarning("Prefab not found!");
        }
    }
}

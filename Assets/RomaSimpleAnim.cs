using UnityEngine;

public class RomaSimpleAnim : MonoBehaviour
{
    SimpleAnimation sa;
    string[] name;
    int cnt = 0;

    private void Start()
    {
        sa = GetComponent<SimpleAnimation>();
        if (sa == null)
        {
            sa = gameObject.AddComponent<SimpleAnimation>();
        }

        AnimationClip[] clips = Resources.LoadAll<AnimationClip>("animation_clip");
        name = new string[clips.Length];

        for (int i = 0; i < clips.Length; i++)
        {
            var c = clips[i];
            name[i] = c.name;
            sa.AddClip(c, name[i]);
        }

        sa.Play(name[cnt]);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            cnt++;
            if (cnt > name.Length - 1)
            {
                cnt = 0;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            cnt--;
            if (cnt < 0)
            {
                cnt = name.Length - 1;
            }
        }

        if(Input.anyKeyDown)
        {
            sa.Play(name[cnt]);
        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 640, 480), name[cnt]);
    }
}
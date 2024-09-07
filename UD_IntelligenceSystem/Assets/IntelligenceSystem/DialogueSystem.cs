using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public TextAsset WordDataAsset;

    [TextArea]
    public string Message;

    [Range(0, 1)]
    public float Resolution;

    public TextMeshProUGUI MessageBox;

    private Dictionary<string, List<string>> Anagrams = new Dictionary<string, List<string>>();

    public void Awake()
    {
        Anagrams = Anagramatic.Generator.Generate(WordDataAsset.text.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries));
    }

    public void Update()
    {
        MessageBox.text = Anagramatic.Encryptor.ResolveString(Message, Anagrams, Resolution);
    }
}
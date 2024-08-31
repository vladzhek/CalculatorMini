using UnityEngine;

public class StateManager
{
    public void SaveState(string input, string history)
    {
        PlayerPrefs.SetString("LastInput", input);
        PlayerPrefs.SetString("History", history);
    }

    public (string, string) LoadState()
    {
        string input = PlayerPrefs.GetString("LastInput", string.Empty);
        string history = PlayerPrefs.GetString("History", string.Empty);
        return (input, history);
    }
}

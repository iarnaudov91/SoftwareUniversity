﻿public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

public class Dispatcher
{
    private string name;

    public event NameChangeEventHandler NameChange;

    public string Name
    {
        get
        {
            return this.name;
        }

        set
        {
            this.name = value;
            this.OnNameChange(new NameChangeEventArgs(value));
        }
    }

    private void OnNameChange(NameChangeEventArgs args)
    {
        this.NameChange?.Invoke(this, args);
    }
}

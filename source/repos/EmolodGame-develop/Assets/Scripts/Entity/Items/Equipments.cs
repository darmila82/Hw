using System;

public class Equipments
{
    protected int value = 0;
    protected string name = "";
    protected int level = 0;
    protected string resource = "";
    public Equipments(              
        int value,
        string name,
        int level,
        string resource)
    {
        this.value = value;
        this.name = name;
        this.level = level;
        this.resource = resource;
    }
}

using System;
using UnityEngine;

public class Armor : Equipments
{
    public Armor(int armor, string name, int level, string resource = "")
        : base(armor, name, level, resource)
    {
    }
    // setter & getter armor
    public void setDefence(int armor)
    {
        this.value = armor;
    }
    public int getDefence()
    {
        return value;
    }

    // getter name
    public string getName()
    {
        return name;
    }
    public void setName(string name)
    {
        this.name = name;
    }

    //setter & getter lvl
    public void setLevel(int level)
    {
        this.level = level;
    }
    public int getLevel()
    {
        return level;
    }

    //setter & getter resource
    public void setResource(string resource)
    {
        this.resource = resource;
    }
    public string getResource()
    {
        return resource;
    }
   
    //покращення броні до +5
    protected void upgradeArmor()
    {
        int index = 0;
        value += 3;
        index++;
        name = this.getName() + $"+ {index}";
    }
}

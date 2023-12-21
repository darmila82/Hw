using System;

public class Weapon : Equipments
{
    protected int critChance = 0;
    public Weapon(int damage, string name, int level, int critChance, string resource = "") 
        : base(damage, name, level, resource)
    {
        this.critChance = critChance;
    }

    // setter & getter dmg
    public void setDamage(int damage)
    {
        this.value = damage;
    }
    public int getDamage()
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

    //setter & getter crit chance
    public void setCritChance(int critChance)
    {
        this.critChance = critChance;
    }
    public int getCritChance()
    {
        return critChance;
    }

    //покращення зброї до +5
    protected void upgradeWeapon()
    {
        int index = 0;
        value += 3;
        index++;
        name = getName() + $"+ {index}";
    }
}



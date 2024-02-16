using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine;

public class Magazine
{
    public Magazine(string type, int capacity)
    {
        Type = type;
        Capacity = capacity;
        Clothes = new List<Cloth>();
    }

    public string Type { get; set; }
    public int Capacity { get; set; }
    public List<Cloth> Clothes { get; set; }
    public void AddCloth(Cloth cloth)
    {
        if (Capacity > Clothes.Count)
        {
            Clothes.Add(cloth);
        }
    }
    public bool RemoveCloth(string color)
    {
        Cloth clothToRemove = Clothes.FirstOrDefault(c => c.Color == color);
        if (clothToRemove != null)
        {
            return Clothes.Remove(clothToRemove);
        }

        return false;
    }
    public Cloth GetSmallestCloth()
    {
        Cloth smallestCloth = Clothes.OrderBy(c => c.Size).First();
        return smallestCloth;   
    }
    public Cloth GetCloth(string color)
    {
        Cloth clothWithColor = Clothes.FirstOrDefault(c => c.Color == color);
        return clothWithColor;
    }
    public int GetClothCount()
    {
        return Clothes.Count();
    }
    public string Report()
    {
        List<Cloth> orderedClothes = Clothes.OrderBy(c => c.Size).ToList();
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{Type} magazine contains:");
        foreach (Cloth cloth in orderedClothes)
        {
            sb.AppendLine(cloth.ToString());
        }

        return sb.ToString().Trim();
    }
}

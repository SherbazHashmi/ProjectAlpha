namespace MoreMountains.CorgiEngine
{
    public enum TypeOfCollectable
    {
        Skin,Horde
    }
    public class Collectable : PickableItem
    {
        private string Name;
        private int CollectableID;
        private TypeOfCollectable Type;


        Collectable(string name, int collectableID, TypeOfCollectable type)
        {
            Name = name;
            CollectableID = collectableID;
            Type = type;
        }
    }
}
namespace MoreMountains.CorgiEngine
{
    public enum TypeOfCollectable
    {
        Skin,Horde
    }
    public class Collectable : PickableItem
    {
        private string name;
        private int collectableID;
        private TypeOfCollectable type;


        Collectable(string name, int collectableId, TypeOfCollectable type)
        {
            this.name = name;
            this.collectableID = collectableId;
            this.type = type;
        }
    }
}
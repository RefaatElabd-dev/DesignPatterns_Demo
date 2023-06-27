namespace ProtoType
{
    public interface IProtoType<out T>
    {
        T DeepCopy1();
    }
}

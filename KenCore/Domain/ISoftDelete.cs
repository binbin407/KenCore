namespace KenCore.Domain
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}

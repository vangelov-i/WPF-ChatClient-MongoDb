namespace ChatSystem.Data.Contracts
{
    using ChatSystem.Model;

    public interface IChatSystemData
    {
        IRepository<Message> Messages { get; }

        IRepository<User> Users { get; }
    }
}
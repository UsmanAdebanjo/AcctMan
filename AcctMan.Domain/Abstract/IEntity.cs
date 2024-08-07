namespace AcctMan.Domain.Abstract
{
    public interface IEntity<TKey>
    {
        public Guid Id { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }

}

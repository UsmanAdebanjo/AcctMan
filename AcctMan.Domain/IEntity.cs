namespace AcctMan.Domain
{
    public interface IEntity<TKey>
    {
        public Guid Id { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }

}

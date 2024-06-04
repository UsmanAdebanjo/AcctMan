namespace AcctMan.Domain
{
    public interface IEntity<Tkey>
    {
        public Guid Id { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }

}

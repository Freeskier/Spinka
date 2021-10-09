namespace Spinka.Domain.Models
{
    public class AuthorizationsTypePermissions : BaseEntity
    {
        public virtual AuthorizationsType AuthorizationsType { get; set; }
        public int AuthorizationsTypeId { get; set; }
        public virtual Permission Permission { get; set; }
        public int PermissionId { get; set; }
    }
}
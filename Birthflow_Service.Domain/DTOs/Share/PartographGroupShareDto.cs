namespace BirthflowService.Domain.DTOs.Share
{
    public class PartographGroupShareDto
    {
        public long? Id { get; set; }
        public long PartographGroupId { get; set; }
        public Guid? UserId { get; set; }
        public long? GroupId { get; set; }
        public int? PermissionTypeId { get; set; }
    }
}

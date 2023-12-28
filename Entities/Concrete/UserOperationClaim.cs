using Core.Entities;

namespace Entities.Concrete;

public class UserOperationClaim : IEntity
{
    public int Id { get; set; }
    public int AppUserId { get; set; }
    public int OperationClaimId { get; set; }
}

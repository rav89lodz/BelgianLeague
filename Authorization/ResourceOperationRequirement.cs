using Microsoft.AspNetCore.Authorization;

namespace BelgianLeague.Authorization;

public enum ResourceOperation
{
    Create,
    Read,
    Delete
}

public class ResourceOperationRequirement : IAuthorizationRequirement
{
    public ResourceOperation ResourceOperation { get; }

    public ResourceOperationRequirement(ResourceOperation resourceOperation)
    {
        ResourceOperation = resourceOperation;
    }
}

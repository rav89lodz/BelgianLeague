using BelgianLeague.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BelgianLeague.Authorization;

public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, MyTeam>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, MyTeam myTeam)
    {
        if (requirement.ResourceOperation == ResourceOperation.Read || requirement.ResourceOperation == ResourceOperation.Create)
        {
            context.Succeed(requirement);
        }

        var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
        if (myTeam.UserId == int.Parse(userId))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
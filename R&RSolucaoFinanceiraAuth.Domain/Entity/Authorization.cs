namespace R_RSolucaoFinanceiraAuth.Domain.Entity;

public sealed class Authorization
{
    public enum Roles
    {
        Administrator,
        Moderator,
        User
    }
    public const Roles default_role = Roles.User;
}

namespace R_RSolucaoFinanceiraAuth.Domain.Entity;

public class Response
{
    private List<string>? Errors;
    private bool Success;

    public Response()
    {
        
    }

    public Response(bool success)
    {
        this.Success = success;
    }

    public Response(List<string> errors, bool success)
    {
        if (errors is null)
            this.Errors = new List<string>();

        this.Success = success;
        this.Errors = errors;
    }

    public bool GetSuccess()
    {
        return this.Success;
    }

    public List<string>? GetErrors()
    {
        return this.Errors;
    }
}

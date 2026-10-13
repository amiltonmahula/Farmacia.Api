using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Farmacia.Extensions;

public static class ModelStateExtension
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary.SelectMany(v => v.Value.Errors)
            .Select(v => v.ErrorMessage)
            .ToList();
    }
}
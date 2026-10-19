namespace Movies.Application.Common.Exceptions;

public sealed class NotFoundException(string resource, object key)
    : Exception($"{resource} with id '{key}' was not found.");

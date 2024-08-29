using NUnit.Framework;

namespace Base;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class LocalOnlyTestAttribute : CategoryAttribute
{ }

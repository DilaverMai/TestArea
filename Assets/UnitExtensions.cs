using Unity.VisualScripting;

public static class UnitExtensions
{
    public static T Get<T>(this Flow flow, ValueInput input) where T : class
    {
        return flow.GetValue(input) as T;
    }
    
    public static Flow GetFlow(this GraphReference graphReference)
    {
        return Flow.New(graphReference);
    }
}
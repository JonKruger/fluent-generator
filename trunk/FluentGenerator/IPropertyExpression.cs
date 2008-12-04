namespace FluentGenerator
{
    public interface IPropertyExpression : IGeneratable
    {
        PropertyWithBackingField GeneratePropertyWithBackingField();
    }
}
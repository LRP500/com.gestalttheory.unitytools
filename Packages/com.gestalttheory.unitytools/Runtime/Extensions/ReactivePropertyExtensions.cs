using UniRx;

namespace UnityTools.Runtime.Extensions
{
    public static class ReactivePropertyExtensions
    {
        public static void Clear<T>(this ReactiveProperty<T> property)
        {
            property.Value = default;
        }
    }
}
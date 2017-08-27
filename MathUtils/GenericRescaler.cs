namespace MathUtils
{
    public static class GenericRescaler<T>
    {
        public static T Rescale(T value, T oldMin, T oldMax, T newMin, T newMax)
        {
            dynamic dynValue = value;

            dynamic dynOldMin = oldMin;
            dynamic dynOldMax = oldMax;

            dynamic dynNewMin = newMin;
            dynamic dynNewMax = newMax;

            if (dynValue == dynOldMin)
            {
                return dynNewMin;
            }
            if (dynValue == dynOldMax)
            {
                return dynNewMax;
            }

            dynamic dynOldRange = dynOldMax - dynOldMin;
            dynamic dynNewRange = dynNewMax - dynNewMin;

            return (((dynValue - dynOldMin) * dynNewRange) / dynOldRange) + dynNewMin;
        }
    }
}

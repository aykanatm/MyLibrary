using ClassOperations.Attributes;

namespace ClassOperations
{
    public class PropertyMatcher<TParent, TChild> where TParent : class 
                                                  where TChild : class
    {
        private readonly TParent _parent;
        private readonly TChild _child;
        public PropertyMatcher(TParent parent, TChild child)
        {
            _parent = parent;
            _child = child;
        }

        public TChild GenerateMatchedObject()
        {
            var childProperties = _child.GetType().GetProperties();
            foreach (var childProperty in childProperties)
            {
                var attributesForProperty = childProperty.GetCustomAttributes(typeof(MatchParentAttribute), true);
                var isOfTypeMatchParentAttribute = false;

                MatchParentAttribute currentAttribute = null;

                foreach (var attribute in attributesForProperty)
                {
                    if (attribute.GetType() == typeof(MatchParentAttribute))
                    {
                        isOfTypeMatchParentAttribute = true;
                        currentAttribute = (MatchParentAttribute) attribute;
                        break;
                    }
                }

                if (isOfTypeMatchParentAttribute)
                {
                    var parentProperties = _parent.GetType().GetProperties();
                    object parentPropertyValue = null;
                    foreach (var parentProperty in parentProperties)
                    {
                        if (parentProperty.Name == currentAttribute.ParentPropertyName)
                        {
                            parentPropertyValue = parentProperty.GetValue(_parent);
                        }
                    }
                    childProperty.SetValue(_child, parentPropertyValue);
                }
            }

            return _child;
        }
    }
}

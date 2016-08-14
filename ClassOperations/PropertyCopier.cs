using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassOperations
{
    public class PropertyCopier<TFrom, TTo> where TFrom : class
                                            where TTo : class 
    {
        public void Copy(TFrom from, TTo to)
        {
            var fromProperties = from.GetType().GetProperties();
            var toProperties = to.GetType().GetProperties();

            foreach (var fromProperty in fromProperties)
            {
                foreach (var toProperty in toProperties)
                {
                    if (fromProperty.Name == toProperty.Name && fromProperty.PropertyType == toProperty.PropertyType)
                    {
                        toProperty.SetValue(to,fromProperty.GetValue(from));
                        break;
                    }
                }
            }
        }
    }
}

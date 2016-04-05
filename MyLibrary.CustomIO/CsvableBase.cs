namespace MyLibrary.CustomIO
{
    public abstract class CsvableBase
    {
        public virtual string ToCsv()
        {
            string output = "";

            var properties = GetType().GetProperties();

            for (var i = 0; i < properties.Length; i++)
            {
                if (i == properties.Length - 1)
                {
                    output += properties[i].GetValue(this);
                }
                else
                {
                    output += properties[i].GetValue(this) + ",";
                }
            }

            return output;
        }
    }
}

namespace MyLibrary.CustomIO
{
    public abstract class CsvableBase
    {
        public virtual string ToCsv()
        {
            string output = "";

            foreach (var property in this.GetType().GetProperties())
            {
                output += property.GetValue(this) + ", ";
            }

            return output;
        }
    }
}

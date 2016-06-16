This library is a collection of various C# helper classes and utilities I have used in my projects that I found usefull. Hopefully you will find something usefull here as well.

###ClassOperations
####GenericCloner
GenericCloner is a simple tool to clone an object to create a new instance of this object. This is useful especially in operator overloading where a completely new instance of the object is needed to perform certain operations. You can find examples of the usage in the ```Vector``` class in ```CustomMath``` project. Note that all classes involed in the cloning process must be `Serializable`.

Basic usage:

```cs
var p1 = new Person(1, "murat", "aykanat", new Address("city1", "country1"));
var gc = new GenericCloner<Person>();
var p2 = gc.Clone(p1);
Console.WriteLine("Person 1 => " + p1);
Console.WriteLine("Person 2 => " + p2);
```
Output:
```
Person 1 => murat aykanat  city1 / country1
Person 2 => murat aykanat  city1 / country1
```

####PropertyCopier
PropertyCopier copies similarly named public properties from one object to another object.

Basic usage:

```cs
var p1 = new Person(1, "murat", "aykanat", new Address("city1", "country1"));
var p2 = new PersonWithoutAddress();
var pc = new PropertyCopier<Person, PersonWithoutAddress>();
pc.Copy(p1, p2);
Console.WriteLine("Person 1 => " + p1);
Console.WriteLine("Person 2 => " + p2);
```
Output:
```
Person 1 => murat aykanat city1/country1
Person 2 => murat aykanat
```

###CustomCollections
####CircularList
As the name suggests, circular list holds a list of values or classes that the "currently selected item" can move to the next or previous index.

Basic usage:
```
var cl = new CircularList<Person>
{
    new Person(1, "person1_name", "person1_lastname", new Address("city1", "country1")),
    new Person(2, "person2_name", "person2_lastname", new Address("city2", "country2")),
    new Person(3, "person3_name", "person3_lastname", new Address("city3", "country3"))
};
cl.Initialize();
Console.WriteLine("Initial value = " + cl.CurrentItem);
cl.MoveNext();
Console.WriteLine("Next value = " + cl.CurrentItem);
cl.MoveNext();
Console.WriteLine("Next value = " + cl.CurrentItem);
cl.MovePrev();
Console.WriteLine("Previous value = " + cl.CurrentItem);
```
Output:
```
Initial value = person1_name person1_lastname city1/country1
Next value = person2_name person2_lastname city2/country2
Next value = person3_name person3_lastname city3/country3
Previous value = person2_name person2_lastname city2/country2
```
####CircularListExtensionMethods
####ToCircularList<T>()
This method transforms an existing IOrderedEnumerable<T> to CircularList<T>.
####Initialize<T>()
This method sets the `CurrentItem` to the 0 index of the list.
####ListExtensionMethods
####ToVector()
This method transforms an exiting List<double> object into a vector object.
####ShuffleFisherYates<T>()
This method shuffles the list with Fisher-Yates technique
####Shuffle<T>()
This method shuffles the list.
###CustomIO
####FolderExtensionMethods
####Empty()
This method empties a folder by deleting all files and subfolders inside it.
####CsvReader
You can read about the implementation in this [guide](http://tutorials.pluralsight.com/microsoft-net/building-a-generic-csv-writer-reader-using-reflection?status=in-review) on Pluralsight website.
####CsvWriter
You can read about the implementation in this [guide](http://tutorials.pluralsight.com/microsoft-net/building-a-generic-csv-writer-reader-using-reflection?status=in-review) on Pluralsight website.
####CsvableBase
You can read about the implementation in this [guide](http://tutorials.pluralsight.com/microsoft-net/building-a-generic-csv-writer-reader-using-reflection?status=in-review) on Pluralsight website.
####FileSerializer
This class turns a file into an array of bytes and from bytes back to file.
####GenericXmlSerializer
This class is a wrapper on top of the ```XmlSerializer``` class for ease of use.
###CustomMath
####VectorExtensionMethods
####GenericRescaler
This class rescales a value into in a range of values to another range of values. Since the code contains ```dynamic``` keyword, it can only be used with C# 4.0 and above.

Basic usage:
```
double a = 155;
Console.WriteLine(a + " is between 0 and 255");
Console.WriteLine(GenericRescaler<double>.Rescale(a, 0, 255, 0, 1) + " is between 0 and 1");
```
Output:
```
155 is between 0 and 255
0.607843137254902 is between 0 and 1
```
####Matrix
Standart matrix implementation.
Basic usage:
```
var m1 = new Matrix(new List<Vector>
{
    new Vector(new List<double> {1, 2, 3}),
    new Vector(new List<double> {4, 5, 6}),
    new Vector(new List<double> {7, 8, 9})
}, Matrix.VectorStyles.Row);

var m2 = new Matrix(new List<Vector>
{
    new Vector(new List<double> {-1, -2, -3}),
    new Vector(new List<double> {-4, 5, 6}),
    new Vector(new List<double> {7, 8, -9})
}, Matrix.VectorStyles.Row);
Console.WriteLine("M1");
Console.WriteLine(m1);
Console.WriteLine("M2");
Console.WriteLine(m2);
Console.WriteLine("M1 + M2");
Console.WriteLine(m1 + m2);
Console.WriteLine("3 * M1");
Console.WriteLine(3 * m1);
Console.WriteLine("M1 * M2");
Console.WriteLine(Matrix.MatMul(m1,m2));
```
Output:
```
M1
[(1,2,3)
 (4,5,6)
 (7,8,9)]
M2
[(-1,-2,-3)
 (-4,5,6)
 (7,8,-9)]
M1 + M2
[(0,0,0)
 (0,10,12)
 (14,16,0)]
3 * M1
[(3,6,9)
 (12,15,18)
 (21,24,27)]
M1 * M2
[(12,32,-18)
 (18,65,-36)
 (24,98,-54)]
```
####Vector
Standart vector implementation with any number of dimensions.

Basic usage:
```
var v1 = new Vector(new List<double> {1,2,3});
var v2 = new Vector(new List<double> {2,4,5});
Console.WriteLine(v1 + " + " + v2 +" = " + (v1 + v2));
Console.WriteLine(v1 + " - " + v2 + " = " + (v1 - v2));
Console.WriteLine("Dot product of v1 and v2 = " + Vector.DotProduct(v1, v2));
Console.WriteLine("Element product of v1 and v2 = " + Vector.ElementProduct(v1, v2));
```
Output:
```
Vector3(1, 2, 3) + Vector3(2, 4, 5) = Vector3(3, 6, 8)
Vector3(1, 2, 3) - Vector3(2, 4, 5) = Vector3(-1, -2, -2)
Dot product of v1 and v2 = 25
Element product of v1 and v2 = Vector3(2, 8, 15)
```
###WPF
####DependencyObjectExtensionMethod
####GetChildren<T>()
This method gets all the children dependency objects of type T. For example if you want to get all objects of type `TextBox` in a grid, you can use this method.
###StringOperations
####StringExtensionMethods
####ReplaceSpecialCharacters()
This method replaces special characters such as "ç" or "Ş" with their ASCII counterparts "c" and "S". This is usefull if you are dealing with a 3rd party library that does not read such special characters.

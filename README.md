This library is a collection of various C# helper classes and utilities I have used in my projects that I found usefull. Hopefully you will find something usefull here as well.

###ClassOperations
####GenericCloner
GenericCloner is a simple tool to clone an object to create a new instance of this object. This is useful especially in operator overloading where a completely new instance of the object is needed to perform certain operations. You can find examples of the usage in the ```Vector``` class in ```CustomMath``` project.

Basic usage:

```cs
var p1 = new Person();
var gc = GenericCloner<Person>();
var p2 = gc.Clone(p1);
```

####PropertyCopier
PropertyCopier copies similarly named public properties from one object to another object.

Basic usage:

```cs
var p1 = new Person();
var p2 = new PersonWithAddress();
var pc = new PropertyCopier<Person, PersonWithAddress>();
p2 = pc.Copy(p1,p2);
```

###CustomCollections
####CircularList
As the name suggests, circular list holds a list of values or classes that the "currently selected item" can move to the next or previous index.
####CircularListExtensionMethods
####ListExtensionMethods
###CustomIO
####FolderExtensionMethods
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
####Matrix
Standart matrix implementation.
####Vector
Standart vector implementation with any number of dimensions.
###WPF
####DependencyObjectExtensionMethod

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
####CircularListExtensionMethods
####ListExtensionMethods
###CustomIO
####FolderExtensionMethods
####CsvReader
####CsvWriter
####CsvableBase
####FileSerializer
####GenericXmlSerializer
###CustomMath
####VectorExtensionMethods
####GenericRescaler
####Matrix
####Vector
###WPF
####DependencyObjectExtensionMethod

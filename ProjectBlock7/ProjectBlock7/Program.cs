using AsyncStreamLibrary;
using AttributeLibrary;
using DynamicLibrary;
using ExtensionMethodsLibrary;
using IndicesAndRangesLibrary;
using InterfaceLibrary;
using NullableLibrary;
/*
ExtensionMethods extensionMethods = new ExtensionMethods();
extensionMethods.ExampleStringExtension();
extensionMethods.ExampleIntExtension();
extensionMethods.ExampleDictionaryExtension();
extensionMethods.ExampleDateTimeExtensions();
await extensionMethods.ExampleHttpClientExtensions();
extensionMethods.ExampleFileInfoExtensions();
*/
/*
NullableExample nullableExample = new NullableExample();
nullableExample.Example();
nullableExample.ExampleConsoleWork();
nullableExample.ExampleDataBase();
*/
/*
 *ExampleDynamic dynamicExample = new ExampleDynamic();
dynamicExample.ExampleCreateExcel();
dynamicExample.ExampleUsePython();
dynamicExample.ExampleJSON();
*/
/*
ExampleAttribute exampleAttribute = new ExampleAttribute();
exampleAttribute.SimpleMetod("Hi!");
*/
/*
ExampleReflection exampleReflection = new ExampleReflection();
exampleReflection.Example();
exampleReflection.ExampleValidate();
*/
/*
ExampleAsyncStream exampleAsyncStream = new ExampleAsyncStream();
await exampleAsyncStream.ExampleNumberAsyncStream();
await exampleAsyncStream.ExampleReadFileAsyncStream();
await exampleAsyncStream.ExampleWebApiAsyncStream();
await exampleAsyncStream.ExampleBigReadFileAsyncStream();
await exampleAsyncStream.ExampleCencellationTokenAsyncStream();
await exampleAsyncStream.ExampleLINQAsyncStream();
*/
/*ExampleIndices exampleIndices = new ExampleIndices();
exampleIndices.ExampleMetodIndices();

ExampleRanges exampleRanges = new ExampleRanges();
exampleRanges.ExampleMetodRanges();
exampleRanges.ExampleStringRanges();


exampleIndices.PractickMetod();
exampleRanges.PractickMetod();
exampleRanges.ReadLineExample();
exampleRanges.ArreyRangeExample();*/

ExampleInterface exampleInterface = new ExampleInterface();

exampleInterface.DoWork();
((IExampleInterfaceA)exampleInterface).DoWork();
((IExampleInterfaceB)exampleInterface).DoWork();



